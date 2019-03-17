[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.MenuItem

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'item when 'item :> MenuItem> () =
    inherit Element.Builder<'item> ()
    //SILP: FABULOUS_BUILDER_OPERATION(MenuItem, string, Text, text)
    [<CustomOperation("text")>]                                          //__SILP__
    member __.Text (attributes : Attributes<MenuItem>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(MenuItem, unit -> unit, ButtonCommand, command)
    [<CustomOperation("command")>]                                                         //__SILP__
    member __.ButtonCommand (attributes : Attributes<MenuItem>, command : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.ButtonCommandAttribKey, command)                   //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(MenuItem, obj, CommandParameter, commandParameter)
    [<CustomOperation("commandParameter")>]                                                   //__SILP__
    member __.CommandParameter (attributes : Attributes<MenuItem>, commandParameter : obj) =  //__SILP__
        attributes.With (ViewAttributes.CommandParameterAttribKey, commandParameter)          //__SILP__

type Builder () =
    inherit Builder<MenuItem> ()
    //SILP: FABULOUS_BUILDER_BUILD(MenuItem)
    override __.Build (builder : AttributesBuilder) =                                    //__SILP__
        ViewElement.Create<MenuItem>                                                     //__SILP__
            (ViewBuilders.CreateFuncMenuItem, ViewBuilders.UpdateFuncMenuItem, builder)  //__SILP__
