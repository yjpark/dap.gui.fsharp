[<AutoOpen>]
module Dap.Fabulous.iOS.Util

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.iOS

type VisualElement with
    member this.GetRenderer<'renderer when 'renderer :> IVisualElementRenderer> () =
        (Platform.GetRenderer this) :?> 'renderer