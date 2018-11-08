[<AutoOpen>]
module Dap.Gui.Types

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IPrefab =
    inherit IFeature
    abstract Widget0 : obj with get

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

type IPresenter<'domain> =
    inherit IPresenter
    abstract Domain : 'domain option with get
    abstract Attach : 'domain -> unit

type IPresenter<'domain, 'prefab when 'prefab :> IPrefab> =
    inherit IPresenter<'domain>
    abstract Prefab : 'prefab with get

type IDynamicPresenter =
    inherit IPresenter
    abstract Seal : unit -> unit
    abstract Sealed : bool with get

type IDynamicPresenter<'domain> =
    inherit IDynamicPresenter
    abstract Detach : unit -> 'domain option

type IDynamicPresenter<'domain, 'prefab when 'prefab :> IPrefab> =
    inherit IPresenter<'domain, 'prefab>
    inherit IDynamicPresenter<'domain>
    abstract AsPresenter : IPresenter<'domain, 'prefab> with get

type IView =
    abstract Display0 : obj with get
    abstract Presenter0 : IPresenter with get

type IView<'presenter when 'presenter :> IPresenter> =
    inherit IView
    abstract Presenter : 'presenter with get

type IView<'presenter, 'display when 'presenter :> IPresenter> =
    inherit IView<'presenter>
    abstract Display : 'display with get

[<AutoOpen>]
module Extensions =
    type IPrefab<'model when 'model :> IViewProps> with
        member this.Model = this.Properties
    type IView with
        member this.Attached = this.Presenter0.Attached
        member this.Prefab0 = this.Presenter0.Prefab0
        member this.Widget0 = this.Presenter0.Prefab0.Widget0

type ILabel =
    inherit IPrefab<LabelProps>

type IButton =
    inherit IPrefab<ButtonProps>
    abstract OnClick : IChannel<unit> with get

type ITextField =
    inherit IPrefab<TextFieldProps>

type IGroup =
    abstract Widget1 : obj with get
    abstract Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : Key -> (ILogging -> 'p) -> 'p

type IGroup<'group when 'group :> IGroupProps> =
    inherit IPrefab<'group>
    inherit IGroup

type StackProps = GroupProps
type IStack =
    inherit IGroup<StackProps>
