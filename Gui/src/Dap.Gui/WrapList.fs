[<AutoOpen>]
module Dap.Gui.WrapList

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type WrapList<'prefab, 'model, 'item_prefab, 'item_model, 'layout
        when 'prefab :> IPrefab
            and 'model :> ListProps<'item_model>
            and 'item_prefab :> IPrefab<'item_model>
            and 'item_model :> IViewProps
            and 'layout :> IListLayout
            and 'layout :> IFeature> (kind : Kind, spawner, logging : ILogging) =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let target = Feature.create<'layout> logging
    let batching : bool = false
    do (
        let owner = base.AsOwner
        let items = base.Properties.Items
        items.OnAdded.AddWatcher owner kind (fun evt ->
            target.SetItems items.Value Feature.create<'item_prefab>
        )
        items.OnRemoved.AddWatcher owner kind (fun evt ->
            target.SetItems items.Value Feature.create<'item_prefab>
        )
        items.OnMoved.AddWatcher owner kind (fun evt ->
            target.SetItems items.Value Feature.create<'item_prefab>
        )
    )
    member __.Target = target
    member this.Model = this.Properties
    interface IPrefab with
        member __.Widget0 = target.Widget1
    interface ILayout with
        member __.Widget1 = target.Widget1
    interface IListLayout with
        member __.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) =
            target.SetItems<'p, 'm> items spawner
    interface IListLayout<'model>
    member this.AsLayout = this :> ILayout
    member this.AsListLayout = this :> IListLayout
    member this.AsPrefab = this.Self
