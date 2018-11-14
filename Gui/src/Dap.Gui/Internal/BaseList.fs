[<AutoOpen>]
module Dap.Gui.Internal.BaseList

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseList'<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BasePrefab<'layout, 'model, 'widget> (kind, spawner, logging, widget)
    let mutable prefabs : IPrefab list = []
    abstract member SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : 'm list -> (ILogging -> 'p) -> unit
    abstract member OnSetItems<'m when 'm :> IViewProps> : 'm list -> unit
    default __.OnSetItems<'m when 'm :> IViewProps> (_items : 'm list) = ()
    member internal __.SetPrefabs' (prefabs' : IPrefab list) =
        prefabs <- prefabs'
    member __.Prefabs : IPrefab list = prefabs
    interface ILayout with
        member this.Widget1 = this.Widget :> obj
    interface IListLayout with
        member this.Prefabs0 = prefabs
        member this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) =
            this.SetItems<'p, 'm> items spawner
            this.OnSetItems items

[<AbstractClass>]
type BaseList<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BaseList'<'layout, 'model, 'widget, 'child> (kind, spawner, logging, widget)
    abstract member CalcPrefabsSize : int -> int
    override this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) : unit =
        let size = this.CalcPrefabsSize items.Length
        if size < this.Prefabs.Length then
            this.SetPrefabs' <| List.truncate size this.Prefabs
        elif items.Length > size then
            let newPrefabs =
                [this.Prefabs.Length .. size - 1]
                |> List.map (fun _ ->
                    let prefab = spawner logging
                    prefab :> IPrefab
                )
            this.SetPrefabs' <| this.Prefabs @ newPrefabs
