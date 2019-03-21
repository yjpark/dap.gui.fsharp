[<AutoOpen>]
module Dap.Android.Types

open System
open Android.Graphics
open Android.App

open Dap.Prelude
open Dap.Gui.App

type Widget = Android.Views.View

type Activity = Android.App.Activity
type Bundle = Android.OS.Bundle

type JavaObject = Java.Lang.Object

type IAndroidPlatform =
    inherit IGuiPlatform
    abstract Param : AndroidParam with get
    abstract Window : Activity with get

and AndroidParam = {
    Name : string
    Activity : Activity
    BackgroundColor : Color option
    Actions : (IAndroidPlatform -> unit) list
} with
    static member Create
            (name : string, activity : Activity, ?backgroundColor : Color) : AndroidParam =
        {
            Name = name
            Activity = activity
            BackgroundColor = backgroundColor
            Actions = []
        }

