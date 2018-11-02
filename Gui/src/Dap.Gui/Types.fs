[<AutoOpen>]
module Dap.Gui.Types

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IPrefab =
    inherit IFeature

type IPrefab<'model when 'model :> IViewProps> =
    inherit IPrefab
    inherit IContext<'model>

type IPrefab<'model, 'widget when 'model :> IViewProps> =
    inherit IPrefab<'model>
    abstract Widget : 'widget with get

type IPresenter =
    inherit IOwner
    abstract Prefab0 : IPrefab with get
    abstract Attached : bool

type IPresenter<'prefab, 'domain when 'prefab :> IPrefab> =
    inherit IPresenter
    abstract Prefab : 'prefab with get
    abstract Domain : 'domain option with get
    abstract Attach : 'domain -> unit

type IDynamicPresenter =
    inherit IPresenter
    abstract Seal : unit -> unit
    abstract Sealed : bool with get

type IDynamicPresenter<'prefab, 'domain when 'prefab :> IPrefab> =
    inherit IPresenter<'prefab, 'domain>
    inherit IDynamicPresenter
    abstract Detach : unit -> 'domain option
    abstract AsPresenter : IPresenter<'prefab, 'domain> with get

type ILabel =
    inherit IPrefab<LabelProps>

type IButton =
    inherit IPrefab<ButtonProps>
    abstract OnClick : IChannel<unit> with get

type ITextField =
    inherit IPrefab<TextFieldProps>

type IGroup =
    abstract Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : Key -> (ILogging -> 'p) -> 'p

type IGroup<'group when 'group :> IGroupProps> =
    inherit IPrefab<'group>
    inherit IGroup

type StackProps = GroupProps
type IStack =
    inherit IGroup<StackProps>

[<AutoOpen>]
module Extensions =
    type IPrefab<'model when 'model :> IViewProps> with
        member this.Model = this.Properties
