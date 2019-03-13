[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.TextCell

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'cell when 'cell :> TextCell> () =
    inherit Cell.Builder<'cell> ()
    //SILP: FABULOUS_BUILDER_OPERATION('cell, string, Text, text)
    [<CustomOperation("text")>]                                       //__SILP__
    member __.Text (attributes : Attributes<'cell>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, string, TextDetail, detail)
    [<CustomOperation("detail")>]                                             //__SILP__
    member __.TextDetail (attributes : Attributes<'cell>, detail : string) =  //__SILP__
        attributes.With (ViewAttributes.TextDetailAttribKey, detail)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, Color, TextColor, textColor)
    [<CustomOperation("textColor")>]                                           //__SILP__
    member __.TextColor (attributes : Attributes<'cell>, textColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.TextColorAttribKey, textColor)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, Color, TextDetailColor, detailColor)
    [<CustomOperation("detailColor")>]                                                 //__SILP__
    member __.TextDetailColor (attributes : Attributes<'cell>, detailColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.TextDetailColorAttribKey, detailColor)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, unit -> unit, TextCellCommand, command)
    [<CustomOperation("command")>]                                                        //__SILP__
    member __.TextCellCommand (attributes : Attributes<'cell>, command : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.TextCellCommandAttribKey, command)                //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, bool, TextCellCanExecute, canExecute)
    [<CustomOperation("canExecute")>]                                                   //__SILP__
    member __.TextCellCanExecute (attributes : Attributes<'cell>, canExecute : bool) =  //__SILP__
        attributes.With (ViewAttributes.TextCellCanExecuteAttribKey, canExecute)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('cell, obj, CommandParameter, commandParameter)
    [<CustomOperation("commandParameter")>]                                                //__SILP__
    member __.CommandParameter (attributes : Attributes<'cell>, commandParameter : obj) =  //__SILP__
        attributes.With (ViewAttributes.CommandParameterAttribKey, commandParameter)       //__SILP__

type Builder () =
    inherit Builder<TextCell> ()
    //SILP: FABULOUS_BUILDER_BUILD(TextCell)
    override __.Build (builder : AttributesBuilder) =                                    //__SILP__
        ViewElement.Create<TextCell>                                                     //__SILP__
            (ViewBuilders.CreateFuncTextCell, ViewBuilders.UpdateFuncTextCell, builder)  //__SILP__
