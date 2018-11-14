[<AutoOpen>]
module Dap.Gui.Internal.BaseList

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseList'<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BasePrefab<'layout, 'model, 'widget> (kind, spawner, logging, widget)
    abstract member SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : 'm list -> (ILogging -> 'p) -> unit
    abstract member OnSetItems<'m when 'm :> IViewProps> : 'm list -> unit
    default __.OnSetItems<'m when 'm :> IViewProps> (_items : 'm list) = ()
    interface ILayout with
        member this.Widget1 = this.Widget :> obj
    interface IListLayout with
        member this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) =
            this.SetItems<'p, 'm> items spawner
            this.OnSetItems items

[<AbstractClass>]
type BaseList<'layout, 'model, 'widget, 'child
        when 'layout :> IListLayout and 'model :> IGroupProps> (kind, spawner, logging, widget) =
    inherit BaseList'<'layout, 'model, 'widget, 'child> (kind, spawner, logging, widget)
    let mutable prefabs : IPrefab list = []
    abstract member CalcPrefabsSize : int -> int
    override this.SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (items : 'm list) (spawner : ILogging -> 'p) : unit =
        let size = this.CalcPrefabsSize items.Length
        if size < prefabs.Length then
            prefabs <- List.truncate size prefabs
        elif items.Length > size then
            prefabs <-
                let newPrefabs =
                    [prefabs.Length .. size]
                    |> List.map (fun _ ->
                        let prefab = spawner logging
                        prefab :> IPrefab
                    )
                prefabs @ newPrefabs
    member __.Prefabs : IPrefab list = prefabs
