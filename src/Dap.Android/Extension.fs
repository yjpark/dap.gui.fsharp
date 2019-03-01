[<AutoOpen>]
module Dap.Android.Extension

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type IPrefab with
    static member CreateLabel () =
        new Android.Widget.TextView (Android.App.Application.Context)
    static member CreateButton () =
        new Android.Widget.Button (Android.App.Application.Context)
    static member CreateTextField () =
        new Android.Widget.EditText (Android.App.Application.Context)

type IContainer with
    static member CreatePanel () =
        new Android.Widget.FrameLayout (Android.App.Application.Context)
    static member CreateHBox () =
        new Android.Widget.LinearLayout (Android.App.Application.Context)
    static member CreateVBox () =
        new Android.Widget.LinearLayout (Android.App.Application.Context)
    static member CreateTable () =
        new Android.Widget.LinearLayout (Android.App.Application.Context)

