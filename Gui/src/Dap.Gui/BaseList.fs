[<AutoOpen>]
module Dap.Gui.BaseList

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui.Internal

[<AbstractClass>]
type BaseList<'prefab, 'model, 'item_prefab, 'item_model, 'container
        when 'prefab :> IListPrefab
            and 'model :> ListProps
            and 'item_prefab :> IPrefab<'item_model>
            and 'item_model :> IViewProps
            and 'container :> IContainer>
            (kind : Kind, spawner, logging : ILogging) =
    inherit BaseGroup<'prefab, 'model, 'container>
        (kind, spawner, logging, (Feature.create<'container> logging))
    (*
    let mutable batching : bool = false
    let setTargetItems (items : 'item_model list) =
        target.SetItems items Feature.create<'item_prefab>
    do (
        let owner = base.AsOwner
        let items = base.Properties.Items
        items.OnAdded.AddWatcher owner kind (fun evt ->
            if not batching then setTargetItems items.Value
        )
        items.OnRemoved.AddWatcher owner kind (fun evt ->
            if not batching then setTargetItems items.Value
        )
        items.OnMoved.AddWatcher owner kind (fun evt ->
            if not batching then setTargetItems items.Value
        )
    )
    member this.SetItems (itemsModel : 'm list) (spawner : ILogging -> 'item_prefab) : unit =
        this.ResizeChildren' itemsModel.Length
        (items.Value, prefab.Prefabs)
        ||> List.iter2 (fun item itemPrefab ->
            new Contact.Presenter(itemPrefab, app, item.Value) |> ignore
        )
    *)
    member this.LoadJson' (json : Json) =
        this.Model.AsProperty.LoadJson json
    interface IListPrefab with
        member this.ResizeItems size =
            this.ResizeChildren' Feature.create<'item_prefab> size
    interface IListPrefab<'model>
    interface IListPrefab<'model, 'item_prefab> with
        member this.Items =
            this.Children
            |> List.map (fun item -> item :?> 'item_prefab)
    member this.AsListPrefab = this :> IListPrefab<'model>
