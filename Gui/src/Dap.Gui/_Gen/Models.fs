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

(*
 * Generated: <Combo>
 *)
type ListProps (owner : IOwner, key : Key) =
    inherit WrapProperties<ListProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let layout = target'.AddVar<(* IGroupProps *) string> (E.string, D.string, "layout", "", None)
    let itemPrefab = target'.AddVar<(* ListProps *) string> (E.string, D.string, "item_prefab", "", None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new ListProps (o, k)
    static member Create () = ListProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<ListProps> (ListProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = ListProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Layout (* IGroupProps *) : IVarProperty<string> = layout
    member __.ItemPrefab (* ListProps *) : IVarProperty<string> = itemPrefab
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface IGroupProps with
        member this.Layout (* IGroupProps *) : IVarProperty<string> = this.Layout
    member this.AsGroupProps = this :> IGroupProps

(*
 * Generated: <Combo>
 *)
type ComboProps (owner : IOwner, key : Key) =
    inherit WrapProperties<ComboProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let prefab = target'.AddVar<(* IViewProps *) string> (E.string, D.string, "prefab", "", None)
    let styles = target'.AddList<(* IViewProps *) string> (E.string, D.string, "styles", "", None)
    let layout = target'.AddVar<(* IGroupProps *) string> (E.string, D.string, "layout", "", None)
    let children = target'.AddCombo(* ComboProps *)  ("children")
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new ComboProps (o, k)
    static member Create () = ComboProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<ComboProps> (ComboProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = ComboProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Prefab (* IViewProps *) : IVarProperty<string> = prefab
    member __.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = styles
    member __.Layout (* IGroupProps *) : IVarProperty<string> = layout
    member __.Children (* ComboProps *) : IComboProperty = children
    interface IViewProps with
        member this.Prefab (* IViewProps *) : IVarProperty<string> = this.Prefab
        member this.Styles (* IViewProps *) : IListProperty<IVarProperty<string>> = this.Styles
    member this.AsViewProps = this :> IViewProps
    interface IGroupProps with
        member this.Layout (* IGroupProps *) : IVarProperty<string> = this.Layout
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
    static member Create () = LabelProps.Create (noOwner, NoKey)
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
    static member Create () = ButtonProps.Create (noOwner, NoKey)
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
    static member Create () = TextFieldProps.Create (noOwner, NoKey)
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