[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.InputView

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Xamarin.Forms

[<AbstractClass>]
type Builder<'view when 'view :> InputView> () =
    inherit VisualElement.Builder<'view> ()
    //SILP: FABULOUS_BUILDER_OPERATION('view, Keyboard, Keyboard, keyboard)
    [<CustomOperation("keyboard")>]                                             //__SILP__
    member __.Keyboard (attributes : Attributes<'view>, keyboard : Keyboard) =  //__SILP__
        attributes.With (ViewAttributes.KeyboardAttribKey, keyboard)            //__SILP__
