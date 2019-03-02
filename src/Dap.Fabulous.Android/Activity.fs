[<AutoOpen>]
module Dap.Fabulous.Android.Activity

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Android

let getFabulousAndroidParam () =
    getAndroidParam ()

let setFabulousAndroidParam (param' : AndroidParam) =
    setAndroidParam param'

[<AbstractClass>]
type FabulousActivity() =
    inherit FormsAppCompatActivity ()
    abstract member UseFabulous : unit -> bool
    default __.UseFabulous () = true
    abstract member DoSetup : Bundle -> unit
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        Xamarin.Essentials.Platform.Init (this, bundle)
        logWip (getLogging ()) "1 BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB" (this.UseFabulous ())
        if this.UseFabulous () then
            Xamarin.Forms.Forms.Init (this, bundle)
        this.DoSetup bundle
        logWip (getLogging ()) "2 BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB" (hasFabulousParam ())
        if hasFabulousParam () then
            let fabulousParam = getFabulousParam ()
            this.LoadApplication (fabulousParam.Application)
    override this.OnRequestPermissionsResult (requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
