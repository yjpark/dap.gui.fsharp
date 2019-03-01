[<AutoOpen>]
module Dap.Android.Types

open System

open Dap.Prelude
open Dap.Gui.App

[<Literal>]
let AndroidPlatformKind = "AndroidPlatform"

type Widget = Android.Views.View

type Activity = Android.App.Activity

type IAndroidPlatform =
    inherit IGuiPlatform
    abstract Param : AndroidParam with get
    abstract Window : Activity with get

and AndroidParam = {
    Name : string
    Activity : Activity
    Actions : (IAndroidPlatform -> unit) list
} with
    static member Create
            (name : string, activity : Activity) : AndroidParam =
        {
            Name = name
            Activity = activity
            Actions = []
        }

