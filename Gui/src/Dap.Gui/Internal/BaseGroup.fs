[<AutoOpen>]
module Dap.Gui.Internal.BaseGroup

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseGroup<'prefab, 'model, 'container
        when 'prefab :> IGroupPrefab
            and 'model :> IGroupProps
            and 'container :> IContainer>
            (kind, spawner, logging, container : 'container) as self =
    inherit BasePrefab<'prefab, 'model, obj> (kind, spawner, logging, container.Widget0)
    let container0 = container :> IContainer
    let mutable children : IPrefab list = []
    do (
        (container :> IContainer) .SetWrapper' self
    )
    member this.AddChild' (key : string) (child : IPrefab) =
        child.SetParent' (Some (this :> IPrefab)) key
        this._StylesOnChildAdded child
        children <- children @ [child]
        container0.AddChild (child.Widget0)

    member this.ResizeChildren'<'p when 'p :> IPrefab> (spawner : ILogging -> 'p) (size : int) =
        if size < 0 then
            failWith "Invalid_Size" (this, size)
        elif size = children.Length then
            ()
        elif size < children.Length then
            let (toKeep, toRemove) = List.splitAt size children
            children <- toKeep
            toRemove
            |> List.iter (fun child ->
                this._StylesOnChildRemoved child
                container0.RemoveChild child.Widget0
            )
        elif size > children.Length then
            [children.Length .. size - 1]
            |> List.iter (fun index ->
                spawner logging
                |> this.AddChild' (index.ToString ())
            )
    member __.Children = children
    interface IGroupPrefab<'container> with
        member __.Container = container
    interface IGroupPrefab with
        member __.Container0 = container0
        member __.Children = children
    member this.AsGroupPrefab = this :> IGroupPrefab<'container>
