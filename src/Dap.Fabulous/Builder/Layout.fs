[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Layout

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Xamarin.Forms

[<AbstractClass>]
type Builder<'layout when 'layout :> Xamarin.Forms.Layout> () =
    inherit View.Builder<'layout> ()
    //SILP: FABULOUS_BUILDER_OPERATION('layout, bool, IsClippedToBounds, isClippedToBounds)
    [<CustomOperation("isClippedToBounds")>]                                                    //__SILP__
    member __.IsClippedToBounds (attributes : Attributes<'layout>, isClippedToBounds : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsClippedToBoundsAttribKey, isClippedToBounds)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('layout, Thickness, Padding, padding)
    [<CustomOperation("padding")>]                                               //__SILP__
    member __.Padding (attributes : Attributes<'layout>, padding : Thickness) =  //__SILP__
        attributes.With (ViewAttributes.PaddingAttribKey, padding)               //__SILP__
