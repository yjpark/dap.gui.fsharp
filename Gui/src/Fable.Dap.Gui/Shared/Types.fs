[<AutoOpen>]
module Dap.Gui.Types

open Dap.Prelude
open Dap.Context

type IPrefab =
    inherit IContext

type IPrefab<'model when 'model :> IWidget> =
    inherit IPrefab
    abstract Model : 'model with get

type IPrefab<'model, 'widget when 'model :> IWidget> =
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
