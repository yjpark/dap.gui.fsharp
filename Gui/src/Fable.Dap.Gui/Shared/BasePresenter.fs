[<AutoOpen>]
module Dap.Gui.BasePresenter

open Dap.Prelude
open Dap.Context

[<AbstractClass>]
type BasePresenter<'prefab when 'prefab :> IPrefab> (prefab : 'prefab) =
    member __.Prefab = prefab
    interface IPresenter<'prefab> with
        member __.Prefab = prefab
    interface IPresenter with
        member __.Prefab0 = prefab :> IPrefab
    interface IOwner with
        member __.Luid = prefab.Luid
        member __.Disposed = prefab.Disposed
    interface ILogger with
        member __.Log m = prefab.Log m
    member this.AsPrefab = this :> IPresenter<'prefab>