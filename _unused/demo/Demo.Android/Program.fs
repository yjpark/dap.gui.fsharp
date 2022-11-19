module Demo.Android.Program

open System
open Android.App

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Android

open Demo.App
open Demo.Gui

[<Activity (Label = "Gui.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () as self =
    inherit DapActivity ()
    static let mutable instance : MainActivity option = None
    do (
        instance <- Some self
    )
    static member Instance = instance.Value
    override this.DoSetup (bundle: Bundle) =
        this.SetContentView (Resources.Layout.Main)
        setAndroidParam <| AndroidParam.Create ("Demo", this)
        App.RunGui ("demo-.log")
        |> ignore


type AndroidThemeHook (logging : ILogging) =
    inherit EmptyContext(logging, "AndroidThemeHook")
    interface IGuiAppHook with
        member this.OnInit (app : IGuiApp) =
            app.OnWillSwitchTheme.AddWatcher this "OnWillSwitchTheme" (fun theme ->
                logWarn this "HOOK" "WILL_SWITCH_THEME" theme
                //MainActivity.Instance.SwitchTheme (Resource.Style.Base_Theme_AppCompat)
            )


