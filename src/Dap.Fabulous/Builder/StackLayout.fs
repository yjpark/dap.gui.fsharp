[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.StackLayout

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Xamarin.Forms

type Builder () =
    inherit Layout.Builder<StackLayout> ()
    //SILP: FABULOUS_BUILDER_BUILD(StackLayout)
    override __.Build (builder : AttributesBuilder) =                                          //__SILP__
        ViewElement.Create<StackLayout>                                                        //__SILP__
            (ViewBuilders.CreateFuncStackLayout, ViewBuilders.UpdateFuncStackLayout, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_ARRAY(StackLayout, ViewElement, Children, children)
    [<CustomOperation("children")>]                                                           //__SILP__
    member __.Children (attributes : Attributes<StackLayout>, children : ViewElement list) =  //__SILP__
        attributes.With (ViewAttributes.ChildrenAttribKey, Array.ofList children)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(StackLayout, StackOrientation, StackOrientation, orientation)
    [<CustomOperation("orientation")>]                                                                   //__SILP__
    member __.StackOrientation (attributes : Attributes<StackLayout>, orientation : StackOrientation) =  //__SILP__
        attributes.With (ViewAttributes.StackOrientationAttribKey, orientation)                          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(StackLayout, double, Spacing, spacing)
    [<CustomOperation("spacing")>]                                                //__SILP__
    member __.Spacing (attributes : Attributes<StackLayout>, spacing : double) =  //__SILP__
        attributes.With (ViewAttributes.SpacingAttribKey, spacing)                //__SILP__
