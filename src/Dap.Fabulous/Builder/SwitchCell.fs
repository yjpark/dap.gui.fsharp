[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.SwitchCell

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit Cell.Builder<SwitchCell> ()
    //SILP: FABULOUS_BUILDER_BUILD(SwitchCell)
    override __.Build (builder : AttributesBuilder) =                                        //__SILP__
        ViewElement.Create<SwitchCell>                                                       //__SILP__
            (ViewBuilders.CreateFuncSwitchCell, ViewBuilders.UpdateFuncSwitchCell, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(SwitchCell, bool, On, on)
    [<CustomOperation("on")>]                                         //__SILP__
    member __.On (attributes : Attributes<SwitchCell>, on : bool) =   //__SILP__
        attributes.With (ViewAttributes.OnAttribKey, on)              //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(SwitchCell, string, Text, text)
    [<CustomOperation("text")>]                                            //__SILP__
    member __.Text (attributes : Attributes<SwitchCell>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)               //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(SwitchCell, ToggledEventArgs, OnChanged, onChanged)
    [<CustomOperation("onChanged")>]                                                                   //__SILP__
    member __.OnChanged (attributes : Attributes<SwitchCell>, onChanged : ToggledEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.OnChangedAttribKey, (fun f ->                                  //__SILP__
            System.EventHandler<ToggledEventArgs> (fun _sender args -> f args)) (onChanged))           //__SILP__
