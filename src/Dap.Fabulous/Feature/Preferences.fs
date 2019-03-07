[<RequireQualifiedAccess>]
module Dap.Fabulous.Feature.Preferences

open System.IO
open FSharp.Control.Tasks.V2
open Xamarin.Essentials

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Fabulous

type Provider = Xamarin.Essentials.Preferences
type Fallback = Dap.Local.Feature.Preferences.Context

type Context (logging : ILogging) =
    inherit BasePreferences<Context> (logging)
    let fallback : Fallback option =
        if hasEssentials () then
            None
        else
            Some <| new Fallback (logging)
    do (
        let owner = base.Owner
        logInfo owner "SecureStorage" "hasEssentials" (Dap.Fabulous.Util.hasEssentials (), fallback)
        base.Has.SetupHandler (fun (luid : Luid) ->
            match fallback with
            | Some fallback ->
                fallback.Has.Handle luid
            | None ->
                Provider.ContainsKey luid
        )
        base.Get.SetupHandler (fun (luid : Luid) ->
            match fallback with
            | Some fallback ->
                fallback.Get.Handle luid
            | None ->
                Provider.Get (luid, "")
        )
        base.Set.SetupHandler (fun (req : SetTextReq) ->
            match fallback with
            | Some fallback ->
                fallback.Set.Handle req
            | None ->
                Provider.Set (req.Path, req.Text)
        )
        base.Remove.SetupHandler (fun (luid : Luid) ->
            match fallback with
            | Some fallback ->
                fallback.Remove.Handle luid
            | None ->
                Provider.Remove luid
        )
        base.Clear.SetupHandler (fun () ->
            match fallback with
            | Some fallback ->
                fallback.Clear.Handle ()
            | None ->
                Provider.Clear ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
