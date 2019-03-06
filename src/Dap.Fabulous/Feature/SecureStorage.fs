[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Fabulous.Feature.SecureStorage

open System.IO
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Fabulous

type Provider = Xamarin.Essentials.SecureStorage
type Fallback = Dap.Local.Feature.SecureStorage.Context

type Context (logging : ILogging) =
    inherit BaseSecureStorage<Context> (logging)
    let fallback = new Fallback (logging)
    do (
        let owner = base.Owner
        base.HasAsync.SetupHandler (fun (luid : Luid) -> task {
            if hasEssentials () then
                let! content = Provider.GetAsync (luid)
                return not (System.String.IsNullOrEmpty (content))
            else
                return! fallback.HasAsync.Handle luid
        })
        base.GetAsync.SetupHandler (fun (luid : Luid) -> task {
            if hasEssentials () then
                let! content = Provider.GetAsync (luid)
                if System.String.IsNullOrEmpty (content) then
                    return ""
                else
                    return content
            else
                return! fallback.GetAsync.Handle luid
            })
        base.SetAsync.SetupHandler (fun (req : SetTextReq) -> task {
            if hasEssentials () then
                do! Provider.SetAsync (req.Path, req.Text)
            else
                do! fallback.SetAsync.Handle req
        })
        base.Remove.SetupHandler (fun (luid : Luid) ->
            if hasEssentials () then
                Provider.Remove luid |> ignore
            else
                fallback.Remove.Handle luid
        )
        base.Clear.SetupHandler (fun () ->
            if hasEssentials () then
                Provider.RemoveAll ()
            else
                fallback.Clear.Handle ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)

