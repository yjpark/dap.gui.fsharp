[<AutoOpen>]
module Dap.Fabulous.TextActionCell

open System

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Palette
open Dap.Fabulous.Controls

type TextActionCell with
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, EventHandler, OnAction)
    static member OnActionAttribKey = AttributeKey<EventHandler> "TextActionCell_OnAction"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, bool, ActionEnabled)
    static member ActionEnabledAttribKey = AttributeKey<bool> "TextActionCell_ActionEnabled"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, string, Action)
    static member ActionAttribKey = AttributeKey<string> "TextActionCell_Action"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, Color, ActionColor)
    static member ActionColorAttribKey = AttributeKey<Color> "TextActionCell_ActionColor"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, Color, ActionPressedColor)
    static member ActionPressedColorAttribKey = AttributeKey<Color> "TextActionCell_ActionPressedColor"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, Color, ActionDisabledColor)
    static member ActionDisabledColorAttribKey = AttributeKey<Color> "TextActionCell_ActionDisabledColor"  //__SILP__
    //SILP: FABULOUS_CONTROL_VIEW_ATTRIB_KEY(TextActionCell, Color, ActionBackgroundColor)
    static member ActionBackgroundColorAttribKey = AttributeKey<Color> "TextActionCell_ActionBackgroundColor"  //__SILP__

type TextActionCellViewBuilder () =
    //SILP: FABULOUS_CONTROL_VIEW_BUILDER_HEAD(TextActionCell, TextCell)
    static member val CreateFunc : (unit -> TextActionCell) =                                         //__SILP__
        (fun () -> TextActionCellViewBuilder.Create()) with get, set                                  //__SILP__
    static member Create () : TextActionCell = new TextActionCell()                                   //__SILP__
    static member val UpdateFunc =                                                                    //__SILP__
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: TextActionCell) ->           //__SILP__
            TextActionCellViewBuilder.Update (prevOpt, curr, target))                                 //__SILP__
    static member Update (prevOpt: ViewElement voption, curr: ViewElement, target: TextActionCell) =  //__SILP__
        // update the inherited Cell element                                                          //__SILP__
        let baseElement =                                                                             //__SILP__
            if ViewProto.ProtoTextCell.IsNone then                                                    //__SILP__
                ViewProto.ProtoTextCell <- Some (ViewBuilders.ConstructTextCell())                    //__SILP__
            ViewProto.ProtoTextCell.Value                                                             //__SILP__
        baseElement.UpdateInherited (prevOpt, curr, target)                                           //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, EventHandler, OnAction)
        let mutable prevOnActionOpt : EventHandler voption = ValueNone  //__SILP__
        let mutable currOnActionOpt : EventHandler voption = ValueNone  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, bool, ActionEnabled)
        let mutable prevActionEnabledOpt : bool voption = ValueNone   //__SILP__
        let mutable currActionEnabledOpt : bool voption = ValueNone   //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, string, Action)
        let mutable prevActionOpt : string voption = ValueNone        //__SILP__
        let mutable currActionOpt : string voption = ValueNone        //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, Color, ActionColor)
        let mutable prevActionColorOpt : Color voption = ValueNone    //__SILP__
        let mutable currActionColorOpt : Color voption = ValueNone    //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, Color, ActionPressedColor)
        let mutable prevActionPressedColorOpt : Color voption = ValueNone  //__SILP__
        let mutable currActionPressedColorOpt : Color voption = ValueNone  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, Color, ActionDisabledColor)
        let mutable prevActionDisabledColorOpt : Color voption = ValueNone  //__SILP__
        let mutable currActionDisabledColorOpt : Color voption = ValueNone  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_VAR(TextActionCell, Color, ActionBackgroundColor)
        let mutable prevActionBackgroundColorOpt : Color voption = ValueNone  //__SILP__
        let mutable currActionBackgroundColorOpt : Color voption = ValueNone  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_HEAD(TextActionCell)
        for kvp in curr.AttributesKeyed do                            //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, EventHandler, OnAction)
            if kvp.Key = TextActionCell.OnActionAttribKey.KeyValue then    //__SILP__
                currOnActionOpt <- ValueSome (kvp.Value :?> EventHandler)  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, bool, ActionEnabled)
            if kvp.Key = TextActionCell.ActionEnabledAttribKey.KeyValue then  //__SILP__
                currActionEnabledOpt <- ValueSome (kvp.Value :?> bool)        //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, string, Action)
            if kvp.Key = TextActionCell.ActionAttribKey.KeyValue then  //__SILP__
                currActionOpt <- ValueSome (kvp.Value :?> string)      //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, Color, ActionColor)
            if kvp.Key = TextActionCell.ActionColorAttribKey.KeyValue then  //__SILP__
                currActionColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, Color, ActionPressedColor)
            if kvp.Key = TextActionCell.ActionPressedColorAttribKey.KeyValue then  //__SILP__
                currActionPressedColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, Color, ActionDisabledColor)
            if kvp.Key = TextActionCell.ActionDisabledColorAttribKey.KeyValue then  //__SILP__
                currActionDisabledColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(TextActionCell, Color, ActionBackgroundColor)
            if kvp.Key = TextActionCell.ActionBackgroundColorAttribKey.KeyValue then  //__SILP__
                currActionBackgroundColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_HEAD(TextActionCell)
        match prevOpt with                                            //__SILP__
        | ValueNone -> ()                                             //__SILP__
        | ValueSome prev ->                                           //__SILP__
            for kvp in prev.AttributesKeyed do                        //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, EventHandler, OnAction)
                if kvp.Key = TextActionCell.OnActionAttribKey.KeyValue then    //__SILP__
                    prevOnActionOpt <- ValueSome (kvp.Value :?> EventHandler)  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, bool, ActionEnabled)
                if kvp.Key = TextActionCell.ActionEnabledAttribKey.KeyValue then  //__SILP__
                    prevActionEnabledOpt <- ValueSome (kvp.Value :?> bool)        //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, string, Action)
                if kvp.Key = TextActionCell.ActionAttribKey.KeyValue then  //__SILP__
                    prevActionOpt <- ValueSome (kvp.Value :?> string)      //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, Color, ActionColor)
                if kvp.Key = TextActionCell.ActionColorAttribKey.KeyValue then  //__SILP__
                    prevActionColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, Color, ActionPressedColor)
                if kvp.Key = TextActionCell.ActionPressedColorAttribKey.KeyValue then  //__SILP__
                    prevActionPressedColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, Color, ActionDisabledColor)
                if kvp.Key = TextActionCell.ActionDisabledColorAttribKey.KeyValue then  //__SILP__
                    prevActionDisabledColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(TextActionCell, Color, ActionBackgroundColor)
                if kvp.Key = TextActionCell.ActionBackgroundColorAttribKey.KeyValue then  //__SILP__
                    prevActionBackgroundColorOpt <- ValueSome (kvp.Value :?> Color)       //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_EVENT(TextActionCell, EventHandler, OnAction)
        match prevOnActionOpt, currOnActionOpt with                                          //__SILP__
        | ValueNone, ValueNone -> ()                                                         //__SILP__
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()  //__SILP__
        | ValueSome prevValue, ValueNone ->                                                  //__SILP__
            target.OnAction.RemoveHandler prevValue                                          //__SILP__
        | ValueNone, ValueSome currValue ->                                                  //__SILP__
            target.OnAction.AddHandler currValue                                             //__SILP__
        | ValueSome prevValue, ValueSome currValue ->                                        //__SILP__
            target.OnAction.RemoveHandler prevValue                                          //__SILP__
            target.OnAction.AddHandler currValue                                             //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, bool, ActionEnabled, true)
        match prevActionEnabledOpt, currActionEnabledOpt with                        //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update ActionEnabled : bool *)                                        //__SILP__
            target.ActionEnabled <- currValue                                        //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset ActionEnabled : bool *)                                         //__SILP__
            target.ActionEnabled <- true                                             //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, string, Action, "")
        match prevActionOpt, currActionOpt with                                      //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update Action : string *)                                             //__SILP__
            target.Action <- currValue                                               //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset Action : string *)                                              //__SILP__
            target.Action <- ""                                                      //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, Color, ActionColor, Color.Black)
        match prevActionColorOpt, currActionColorOpt with                            //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update ActionColor : Color *)                                         //__SILP__
            target.ActionColor <- currValue                                          //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset ActionColor : Color *)                                          //__SILP__
            target.ActionColor <- Color.Black                                        //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, Color, ActionPressedColor, Color.Gray)
        match prevActionPressedColorOpt, currActionPressedColorOpt with              //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update ActionPressedColor : Color *)                                  //__SILP__
            target.ActionPressedColor <- currValue                                   //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset ActionPressedColor : Color *)                                   //__SILP__
            target.ActionPressedColor <- Color.Gray                                  //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, Color, ActionDisabledColor, Color.Gray)
        match prevActionDisabledColorOpt, currActionDisabledColorOpt with            //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update ActionDisabledColor : Color *)                                 //__SILP__
            target.ActionDisabledColor <- currValue                                  //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset ActionDisabledColor : Color *)                                  //__SILP__
            target.ActionDisabledColor <- Color.Gray                                 //__SILP__
        //SILP: FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(TextActionCell, Color, ActionBackgroundColor, Color.White)
        match prevActionBackgroundColorOpt, currActionBackgroundColorOpt with        //__SILP__
        | ValueNone, ValueNone -> ()                                                 //__SILP__
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()  //__SILP__
        | _, ValueSome currValue ->                                                  //__SILP__
            (* Update ActionBackgroundColor : Color *)                               //__SILP__
            target.ActionBackgroundColor <- currValue                                //__SILP__
        | ValueSome _, ValueNone ->                                                  //__SILP__
            (* Reset ActionBackgroundColor : Color *)                                //__SILP__
            target.ActionBackgroundColor <- Color.White                              //__SILP__
