[<AutoOpen>]
module Dap.Android.Types

open System

open Android

open Dap.Prelude
open Dap.Gui.App

[<Literal>]
let AndroidPlatformKind = "AndroidPlatform"

type Widget = Android.Views.View

type IAndroidPlatform =
    inherit IGuiPlatform
    abstract Param : AndroidParam with get
    abstract Window : App.Activity with get

and AndroidParam = {
    Name : string
    Title : string
    Actions : (IAndroidPlatform -> unit) list
} with
    static member Create
            (name : string, ?title : string) : AndroidParam =
        {
            Name = name
            Title = defaultArg title name
            Actions = []
        }

