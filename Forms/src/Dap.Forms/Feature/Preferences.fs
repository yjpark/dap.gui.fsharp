[<RequireQualifiedAccess>]
module Dap.Forms.Feature.Preferences

open System.IO
open FSharp.Control.Tasks.V2
open Xamarin.Essentials

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Forms

type Provider = Xamarin.Essentials.Preferences
type Fallback = Dap.Local.Feature.Preferences.Context

type Context (logging : ILogging) =
    inherit BasePreferences<Context> (logging)
    do (
        base.Has.SetupHandler (fun (luid : Luid) ->
            Provider.ContainsKey luid
        )
        base.Get.SetupHandler (fun (luid : Luid) ->
            Provider.Get (luid, "")
        )
        base.Set.SetupHandler (fun (req : SetTextReq) ->
            Provider.Set (req.Path, req.Text)
        )
        base.Remove.SetupHandler (fun (luid : Luid) ->
            Provider.Remove luid
        )
        base.Clear.SetupHandler (fun () ->
            Provider.Clear ()
        )
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
