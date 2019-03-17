[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.ToolbarItem

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit MenuItem.Builder<ToolbarItem> ()
    //SILP: FABULOUS_BUILDER_BUILD(ToolbarItem)
    override __.Build (builder : AttributesBuilder) =                                          //__SILP__
        ViewElement.Create<ToolbarItem>                                                        //__SILP__
            (ViewBuilders.CreateFuncToolbarItem, ViewBuilders.UpdateFuncToolbarItem, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ToolbarItem, ToolbarItemOrder, Order, order)
    [<CustomOperation("order")>]                                                        //__SILP__
    member __.Order (attributes : Attributes<ToolbarItem>, order : ToolbarItemOrder) =  //__SILP__
        attributes.With (ViewAttributes.OrderAttribKey, order)                          //__SILP__
