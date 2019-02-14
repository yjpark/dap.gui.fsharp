[<AutoOpen>]
module Dap.Gui.Internal.BaseFullList

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseFullList<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BaseList'<'layout, 'model, 'widget, 'child> (kind, spawner, logging, widget)
    abstract member AddChild : 'child -> unit
    abstract member RemoveChild : 'child -> unit
    override this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) : unit =
        if items.Length < this.Prefabs.Length then
            let (toKeep, toRemove) = List.splitAt items.Length this.Prefabs
            this.SetPrefabs' toKeep
            toRemove
            |> List.iter (fun prefab ->
                this._StylesOnChildRemoved prefab
                this.RemoveChild (prefab.Widget0 :?> 'child)
            )
        elif items.Length > this.Prefabs.Length then
            let newPrefabs =
                [this.Prefabs.Length .. items.Length - 1]
                |> List.map (fun _ ->
                    let prefab = spawner logging
                    this.AddChild (prefab.Widget0 :?> 'child)
                    this._StylesOnChildAdded prefab
                    prefab :> IPrefab
                )
            this.SetPrefabs' <| this.Prefabs @ newPrefabs