[<AutoOpen>]
module Dap.Fabulous.Android.Util

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android

type VisualElement with
    member this.GetRenderer<'renderer when 'renderer :> IVisualElementRenderer> () =
        (Platform.GetRenderer this) :?> 'renderer

type Color with
    member this.ToAndroidArgb () =
        (this.ToAndroid ()) .ToArgb ()