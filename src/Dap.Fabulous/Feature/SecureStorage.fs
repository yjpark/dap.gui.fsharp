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
    let fallback : Fallback option =
        if hasEssentials () then
            None
        else
            Some <| new Fallback (logging)
    do (
        let owner = base.Owner
        logInfo owner "SecureStorage" "hasEssentials" (Dap.Fabulous.Util.hasEssentials (), fallback)
        base.HasAsync.SetupHandler (fun (luid : Luid) -> task {
            match fallback with
            | Some fallback ->
                return! fallback.HasAsync.Handle luid
            | None ->
                let! content = Provider.GetAsync (luid)
                return not (System.String.IsNullOrEmpty (content))
        })
        base.GetAsync.SetupHandler (fun (luid : Luid) -> task {
            match fallback with
            | Some fallback ->
                return! fallback.GetAsync.Handle luid
            | None ->
                let! content = Provider.GetAsync (luid)
                if System.String.IsNullOrEmpty (content) then
                    return ""
                else
                    return content
            })
        base.SetAsync.SetupHandler (fun (req : SetTextReq) -> task {
            match fallback with
            | Some fallback ->
                do! fallback.SetAsync.Handle req
            | None ->
                do! Provider.SetAsync (req.Path, req.Text)
        })
        base.Remove.SetupHandler (fun (luid : Luid) ->
            match fallback with
            | Some fallback ->
                fallback.Remove.Handle luid
            | None ->
                Provider.Remove luid |> ignore
        )
        base.Clear.SetupHandler (fun () ->
            match fallback with
            | Some fallback ->
                fallback.Clear.Handle ()
            | None ->
                Provider.RemoveAll ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)

