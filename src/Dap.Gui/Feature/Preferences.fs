[<RequireQualifiedAccess>]
module Dap.Gui.Feature.Preferences

open Microsoft.Maui.Essentials

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Gui

type Provider = Microsoft.Maui.Essentials.Preferences
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
        logInfo owner "SecureStorage" "hasEssentials" (hasEssentials (), fallback)
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
                let content = Provider.Get (luid, "")
                if System.String.IsNullOrEmpty (content) then
                    None
                else
                    Some content
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
