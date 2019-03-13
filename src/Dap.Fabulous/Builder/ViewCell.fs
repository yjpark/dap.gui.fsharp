[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.ViewCell

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit Cell.Builder<ViewCell> ()
    //SILP: FABULOUS_BUILDER_BUILD(ViewCell)
    override __.Build (builder : AttributesBuilder) =                                    //__SILP__
        ViewElement.Create<ViewCell>                                                     //__SILP__
            (ViewBuilders.CreateFuncViewCell, ViewBuilders.UpdateFuncViewCell, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ViewCell, ViewElement, View, view)
    [<CustomOperation("view")>]                                               //__SILP__
    member __.View (attributes : Attributes<ViewCell>, view : ViewElement) =  //__SILP__
        attributes.With (ViewAttributes.ViewAttribKey, view)                  //__SILP__
