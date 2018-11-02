[<AutoOpen>]
module Dap.Gui.Models

open Dap.Prelude
open Dap.Context

(*
 * Generated: <ComboInterface>
 *     ICustomProperties
 *)
type IViewProps =
    inherit ICustomProperties
    abstract Prefab : IVarProperty<string> with get
    abstract Styles : IListProperty<IVarProperty<string>> with get

(*
 * Generated: <ComboInterface>
 *)
type IControlProps =
    inherit IViewProps
    abstract Disabled : IVarProperty<bool> with get

(*
 * Generated: <ComboInterface>
 *)
type ITextProps =
    inherit IViewProps
    abstract Text : IVarProperty<string> with get

(*
 * Generated: <ComboInterface>
 *)
type IGroupProps =
    inherit IViewProps
    abstract Layout : IVarProperty<string> with get
    abstract Children : IComboProperty with get

(*
 * Generated: <Combo>
 *)
type GroupProps (owner : IOwner, key : Key) =
    inherit WrapProperties<GroupProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let layout = target'.AddVar<(* IGroupProps *) string> (E.string, D.string, "layout", "", None)
    let children = target'.AddCombo(* IGroupProps *)  ("children")
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new GroupProps (o, k)
    static member Default () = GroupProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<GroupProps> (GroupProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = GroupProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Layout (* IGroupProps *) : IVarProperty<string> = layout
    member __.Children (* IGroupProps *) : IComboProperty = children
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface IGroupProps with
        member this.Layout (* IGroupProps *) : IVarProperty<string> = this.Layout
        member this.Children (* IGroupProps *) : IComboProperty = this.Children
    member this.AsGroupProps = this :> IGroupProps

(*
 * Generated: <Combo>
 *)
type LabelProps (owner : IOwner, key : Key) =
    inherit WrapProperties<LabelProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let text = target'.AddVar<(* ITextProps *) string> (E.string, D.string, "text", "", None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new LabelProps (o, k)
    static member Default () = LabelProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<LabelProps> (LabelProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = LabelProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Text (* ITextProps *) : IVarProperty<string> = text
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface ITextProps with
        member this.Text (* ITextProps *) : IVarProperty<string> = this.Text
    member this.AsTextProps = this :> ITextProps

(*
 * Generated: <Combo>
 *)
type ButtonProps (owner : IOwner, key : Key) =
    inherit WrapProperties<ButtonProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let disabled = target'.AddVar<(* IControlProps *) bool> (E.bool, D.bool, "disabled", false, None)
    let text = target'.AddVar<(* ITextProps *) string> (E.string, D.string, "text", "", None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new ButtonProps (o, k)
    static member Default () = ButtonProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<ButtonProps> (ButtonProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = ButtonProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Disabled (* IControlProps *) : IVarProperty<bool> = disabled
    member __.Text (* ITextProps *) : IVarProperty<string> = text
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface IControlProps with
        member this.Disabled (* IControlProps *) : IVarProperty<bool> = this.Disabled
    member this.AsControlProps = this :> IControlProps
    interface ITextProps with
        member this.Text (* ITextProps *) : IVarProperty<string> = this.Text
    member this.AsTextProps = this :> ITextProps

(*
 * Generated: <Combo>
 *)
type TextFieldProps (owner : IOwner, key : Key) =
    inherit WrapProperties<TextFieldProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let disabled = target'.AddVar<(* IControlProps *) bool> (E.bool, D.bool, "disabled", false, None)
    let text = target'.AddVar<(* ITextProps *) string> (E.string, D.string, "text", "", None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new TextFieldProps (o, k)
    static member Default () = TextFieldProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<TextFieldProps> (TextFieldProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = TextFieldProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Disabled (* IControlProps *) : IVarProperty<bool> = disabled
    member __.Text (* ITextProps *) : IVarProperty<string> = text
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface IControlProps with
        member this.Disabled (* IControlProps *) : IVarProperty<bool> = this.Disabled
    member this.AsControlProps = this :> IControlProps
    interface ITextProps with
        member this.Text (* ITextProps *) : IVarProperty<string> = this.Text
    member this.AsTextProps = this :> ITextProps