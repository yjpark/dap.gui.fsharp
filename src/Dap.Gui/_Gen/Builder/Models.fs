[<AutoOpen>]
module Dap.Gui.Builder.Models

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Gui

(*
 * Generated: <ComboBuilder>
 *)
type LabelPropsBuilder () =
    inherit ObjBuilder<LabelProps> ()
    override __.Zero () = LabelProps.Create ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : LabelProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("theme")>]
    member __.Theme (target : LabelProps, (* IViewProps *) theme : string option) =
        target.Theme.SetValue theme
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : LabelProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("text")>]
    member __.Text (target : LabelProps, (* ITextProps *) text : string) =
        target.Text.SetValue text
        target

let label_props = new LabelPropsBuilder ()

(*
 * Generated: <ComboBuilder>
 *)
type ButtonPropsBuilder () =
    inherit ObjBuilder<ButtonProps> ()
    override __.Zero () = ButtonProps.Create ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : ButtonProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("theme")>]
    member __.Theme (target : ButtonProps, (* IViewProps *) theme : string option) =
        target.Theme.SetValue theme
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : ButtonProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("disabled")>]
    member __.Disabled (target : ButtonProps, (* IControlProps *) disabled : bool) =
        target.Disabled.SetValue disabled
        target
    [<CustomOperation("text")>]
    member __.Text (target : ButtonProps, (* ITextProps *) text : string) =
        target.Text.SetValue text
        target

let button_props = new ButtonPropsBuilder ()

(*
 * Generated: <ComboBuilder>
 *)
type TextFieldPropsBuilder () =
    inherit ObjBuilder<TextFieldProps> ()
    override __.Zero () = TextFieldProps.Create ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : TextFieldProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("theme")>]
    member __.Theme (target : TextFieldProps, (* IViewProps *) theme : string option) =
        target.Theme.SetValue theme
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : TextFieldProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("disabled")>]
    member __.Disabled (target : TextFieldProps, (* IControlProps *) disabled : bool) =
        target.Disabled.SetValue disabled
        target
    [<CustomOperation("text")>]
    member __.Text (target : TextFieldProps, (* ITextProps *) text : string) =
        target.Text.SetValue text
        target

let text_field_props = new TextFieldPropsBuilder ()