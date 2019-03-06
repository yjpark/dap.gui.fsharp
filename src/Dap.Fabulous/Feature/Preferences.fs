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
    let fallback = new Fallback (logging)
    do (
        base.Has.SetupHandler (fun (luid : Luid) ->
            if hasEssentials () then
                Provider.ContainsKey luid
            else
                fallback.Has.Handle luid
        )
        base.Get.SetupHandler (fun (luid : Luid) ->
            if hasEssentials () then
                Provider.Get (luid, "")
            else
                fallback.Get.Handle luid
        )
        base.Set.SetupHandler (fun (req : SetTextReq) ->
            if hasEssentials () then
                Provider.Set (req.Path, req.Text)
            else
                fallback.Set.Handle req
        )
        base.Remove.SetupHandler (fun (luid : Luid) ->
            if hasEssentials () then
                Provider.Remove luid
            else
                fallback.Remove.Handle luid
        )
        base.Clear.SetupHandler (fun () ->
            if hasEssentials () then
                Provider.Clear ()
            else
                fallback.Clear.Handle ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
