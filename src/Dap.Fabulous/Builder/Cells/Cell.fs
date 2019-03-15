[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Cell

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'cell when 'cell :> Cell> () =
    inherit Element.Builder<'cell> ()
    //SILP: FABULOUS_BUILDER_OPERATION('cell, double, Height, height)
    [<CustomOperation("height")>]                                         //__SILP__
    member __.Height (attributes : Attributes<'cell>, height : double) =  //__SILP__
        attributes.With (ViewAttributes.HeightAttribKey, height)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, bool, IsEnabled, isEnabled)
    [<CustomOperation("isEnabled")>]                                          //__SILP__
    member __.IsEnabled (attributes : Attributes<'cell>, isEnabled : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsEnabledAttribKey, isEnabled)        //__SILP__
