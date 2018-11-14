[<AutoOpen>]
module Dap.Gui.Builder.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Gui
open Dap.Platform
open Dap.Gui.Builder
open Dap.Gui.Dsl.Prefabs

type InputFieldBuilder () =
    inherit ComboPrefabBuilder ("input_field", InputField.Clone (noOwner, NoKey))
    [<CustomOperation("label")>]
    member __.Label (target : ComboProps, label : LabelProps) =
        label.SyncTo <| target.Children.Get<LabelProps> "label"
        target
    [<CustomOperation("update_label")>]
    member __.UpdateLabel (target : ComboProps, update : LabelProps -> unit) =
        update <| target.Children.Get<LabelProps> "label"
        target
    [<CustomOperation("value")>]
    member __.Value (target : ComboProps, value : TextFieldProps) =
        value.SyncTo <| target.Children.Get<TextFieldProps> "value"
        target
    [<CustomOperation("update_value")>]
    member __.UpdateValue (target : ComboProps, update : TextFieldProps -> unit) =
        update <| target.Children.Get<TextFieldProps> "value"
        target

let input_field = new InputFieldBuilder ()