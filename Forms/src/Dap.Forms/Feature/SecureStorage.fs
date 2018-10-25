[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Forms.Feature.SecureStorage

open System.IO
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Forms

type Provider = Xamarin.Essentials.SecureStorage
type Fallback = Dap.Local.Feature.SecureStorage.Context

type Context (logging : ILogging) =
    inherit BaseSecureStorage<Context> (logging)
    do (
        let owner = base.Owner
        base.HasAsync.SetupHandler (fun (luid : Luid) -> task {
            let! content = Provider.GetAsync (luid)
            return not (System.String.IsNullOrEmpty (content))
        })
        base.GetAsync.SetupHandler (fun (luid : Luid) -> task {
            let! content = Provider.GetAsync (luid)
            if System.String.IsNullOrEmpty (content) then
                return ""
            else
                return content
            })
        base.SetAsync.SetupHandler (fun (req : SetTextReq) -> task {
            do! Provider.SetAsync (req.Path, req.Text)
        })
        base.Remove.SetupHandler (fun (luid : Luid) ->
            Provider.Remove luid |> ignore
        )
        base.Clear.SetupHandler (fun () ->
            Provider.RemoveAll ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
    static member AddToAgent (agent : IAgent) =
        if hasEssentials () then
            new Context (agent.Env.Logging) :> ISecureStorage
        else
            Fallback.AddToAgent agent
