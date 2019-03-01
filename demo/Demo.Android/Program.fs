module Demo.Android.Program

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android
open Dap.Fabulous.Android

open Demo.App
open Demo.Gui
open Demo.Fabulous

let useFabulous = false

[<Activity (Label = "Gui.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () =
    inherit FabulousActivity ()
    override this.UseFabulous () = useFabulous
    override this.DoSetup (bundle : Bundle) =
        if useFabulous then
            setFabulousAndroidParam <| AndroidParam.Create ("Demo", this)
            App.RunFabulous ("demo-.log")
        else
            this.SetContentView (Resources.Layout.Main)
            setAndroidParam <| AndroidParam.Create ("Demo", this)
            App.RunGui ("demo-.log")
        |> ignore