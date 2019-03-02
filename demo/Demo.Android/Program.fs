module Demo.Android.Program

open System
open Android.App

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android
open Dap.Fabulous.Android

open Demo.App
open Demo.Gui
open Demo.Fabulous

let useFabulous = true

[<Activity (Label = "Gui.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () =
    inherit FabulousActivity ()
    override this.UseFabulous () = useFabulous
    override this.DoSetup (bundle : Bundle) =
        let param = AndroidParam.Create ("Demo", this, backgroundColor = Android.Graphics.Color.Black)
        if useFabulous then
            setFabulousAndroidParam param
            App.RunFabulous ("demo-.log")
        else
            this.SetContentView (Resources.Layout.Main)
            setAndroidParam param
            App.RunGui ("demo-.log")
        |> ignore

(*
[<Activity (Label = "Gui.Demo", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")>]
type MainActivity () =
    inherit Activity ()
    override this.OnCreate (bundle: Bundle) =
        base.OnCreate (bundle)
        this.SetContentView (Resources.Layout.Main)
        setAndroidParam <| AndroidParam.Create ("Demo", this, backgroundColor = Android.Graphics.Color.Black)
        App.RunGui ("demo-.log")
        |> ignore
*)
