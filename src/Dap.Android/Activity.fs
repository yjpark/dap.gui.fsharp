[<AutoOpen>]
module Dap.Android.Activity

open System
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Internal

[<AbstractClass>]
type DapActivity () =
    inherit Activity ()
    abstract member DoSetup : Bundle -> unit
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        Xamarin.Essentials.Platform.Init (this, bundle)
        logWarn (getLogging ()) "DapActivity.OnCreated" (this.GetType() .FullName) (this)
        this.DoSetup bundle
    override this.OnRequestPermissionsResult (requestCode: int, permissions: string[], [<GeneratedEnum>] grantResults: Android.Content.PM.Permission[]) =
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults)
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults)
    override this.OnResume () =
        base.OnResume ()
        if GuiApp.HasInstance then
            GuiApp.Instance.SetState' GuiAppState.Foreground
    override this.OnPause () =
        base.OnPause ()
        if GuiApp.HasInstance then
            GuiApp.Instance.SetState' GuiAppState.Background
    member this.SwitchTheme (theme : int32) =
        this.SetTheme (theme)
    (*
    member this.SwitchDarkTheme () =
        this.SwitchTheme (Resource.Style.Base_Theme_AppCompat)
    member this.SwitchLightTheme () =
        this.SwitchTheme (Resource.Style.Base_Theme_AppCompat_Light)
    *)
