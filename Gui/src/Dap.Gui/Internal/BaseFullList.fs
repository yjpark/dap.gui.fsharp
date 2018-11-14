[<AutoOpen>]
module Dap.Gui.Internal.BaseFullList

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseFullList<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BaseList'<'layout, 'model, 'widget, 'child> (kind, spawner, logging, widget)
    let mutable prefabs : IPrefab list = []
    abstract member AddChild : 'child -> unit
    abstract member RemoveChild : 'child -> unit
    override this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) : unit =
        if items.Length < prefabs.Length then
            let (toKeep, toRemove) = List.splitAt items.Length prefabs
            prefabs <- toKeep
            toRemove
            |> List.iter (fun prefab ->
                this.RemoveChild (prefab.Widget0 :?> 'child)
            )
        elif items.Length > prefabs.Length then
            prefabs <-
                let newPrefabs =
                    [prefabs.Length .. items.Length]
                    |> List.map (fun _ ->
                        let prefab = spawner logging
                        this.AddChild (prefab.Widget0 :?> 'child)
                        prefab :> IPrefab
                    )
                prefabs @ newPrefabs
    member __.Prefabs : IPrefab list = prefabs