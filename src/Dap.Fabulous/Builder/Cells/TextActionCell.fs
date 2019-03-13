[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.TextActionCell

open System

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous
open Dap.Fabulous.Builder
open Dap.Fabulous.Controls

type ViewAttributes = TextActionCell

type Builder () =
    inherit TextCell.Builder<TextActionCell> ()
    //SILP: FABULOUS_BUILDER_CONTROL_BUILD(TextActionCell)
    override __.Build (builder : AttributesBuilder) =                                              //__SILP__
        ViewElement.Create<TextActionCell>                                                         //__SILP__
            (TextActionCellViewBuilder.CreateFunc, TextActionCellViewBuilder.UpdateFunc, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT(TextActionCell, OnAction, onAction)
    [<CustomOperation("onAction")>]                                                          //__SILP__
    member __.OnAction (attributes : Attributes<TextActionCell>, onAction : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.OnActionAttribKey, (fun f ->                         //__SILP__
            System.EventHandler (fun _sender _args -> f ())) (onAction))                     //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, bool, ActionEnabled, actionEnabled)
    [<CustomOperation("actionEnabled")>]                                                       //__SILP__
    member __.ActionEnabled (attributes : Attributes<TextActionCell>, actionEnabled : bool) =  //__SILP__
        attributes.With (ViewAttributes.ActionEnabledAttribKey, actionEnabled)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, string, Action, action)
    [<CustomOperation("action")>]                                                  //__SILP__
    member __.Action (attributes : Attributes<TextActionCell>, action : string) =  //__SILP__
        attributes.With (ViewAttributes.ActionAttribKey, action)                   //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, Color, ActionColor, actionColor)
    [<CustomOperation("actionColor")>]                                                      //__SILP__
    member __.ActionColor (attributes : Attributes<TextActionCell>, actionColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.ActionColorAttribKey, actionColor)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, Color, ActionPressedColor, actionPressedColor)
    [<CustomOperation("actionPressedColor")>]                                                             //__SILP__
    member __.ActionPressedColor (attributes : Attributes<TextActionCell>, actionPressedColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.ActionPressedColorAttribKey, actionPressedColor)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, Color, ActionDisabledColor, actionDisabledColor)
    [<CustomOperation("actionDisabledColor")>]                                                              //__SILP__
    member __.ActionDisabledColor (attributes : Attributes<TextActionCell>, actionDisabledColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.ActionDisabledColorAttribKey, actionDisabledColor)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TextActionCell, Color, ActionBackgroundColor, actionBackgroundColor)
    [<CustomOperation("actionBackgroundColor")>]                                                                //__SILP__
    member __.ActionBackgroundColor (attributes : Attributes<TextActionCell>, actionBackgroundColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.ActionBackgroundColorAttribKey, actionBackgroundColor)                  //__SILP__
