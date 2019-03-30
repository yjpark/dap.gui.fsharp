module Demo.Android.Program

open System
open Android.App

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android

open Demo.App
open Demo.Gui

[<Activity (Label = "Gui.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () =
    inherit Activity ()
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        this.SetContentView (Resources.Layout.Main)
        setAndroidParam <| AndroidParam.Create ("Demo", this)
        App.RunGui ("demo-.log")
        |> ignore
