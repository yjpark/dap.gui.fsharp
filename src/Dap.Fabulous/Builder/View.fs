[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.View

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Xamarin.Forms

[<AbstractClass>]
type Builder<'view when 'view :> Xamarin.Forms.View> () =
    inherit VisualElement.Builder<'view> ()
    //SILP: FABULOUS_BUILDER_OPERATION('view, LayoutOptions, HorizontalOptions, horizontalOptions)
    [<CustomOperation("horizontalOptions")>]                                                           //__SILP__
    member __.HorizontalOptions (attributes : Attributes<'view>, horizontalOptions : LayoutOptions) =  //__SILP__
        attributes.With (ViewAttributes.HorizontalOptionsAttribKey, horizontalOptions)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('view, LayoutOptions, VerticalOptions, verticalOptions)
    [<CustomOperation("verticalOptions")>]                                                         //__SILP__
    member __.VerticalOptions (attributes : Attributes<'view>, verticalOptions : LayoutOptions) =  //__SILP__
        attributes.With (ViewAttributes.VerticalOptionsAttribKey, verticalOptions)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('view, Thickness, Margin, margin)
    [<CustomOperation("margin")>]                                            //__SILP__
    member __.Margin (attributes : Attributes<'view>, margin : Thickness) =  //__SILP__
        attributes.With (ViewAttributes.MarginAttribKey, margin)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_ARRAY('view, ViewElement, GestureRecognizers, gestureRecognizers)
    [<CustomOperation("gestureRecognizers")>]                                                               //__SILP__
    member __.GestureRecognizers (attributes : Attributes<'view>, gestureRecognizers : ViewElement list) =  //__SILP__
        attributes.With (ViewAttributes.GestureRecognizersAttribKey, Array.ofList gestureRecognizers)       //__SILP__
