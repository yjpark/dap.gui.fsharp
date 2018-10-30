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

type IPresenter<'prefab when 'prefab :> IPrefab> =
    inherit IPresenter
    abstract Prefab : 'prefab with get
