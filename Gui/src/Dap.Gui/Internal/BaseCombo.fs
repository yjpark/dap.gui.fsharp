[<AutoOpen>]
module Dap.Gui.Internal.BaseCombo

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseCombo<'layout, 'model, 'widget, 'child when 'layout :> IComboLayout and 'model :> ComboProps> (kind, spawner, logging, widget) =
    inherit BasePrefab<'layout, 'model, 'widget> (kind, spawner, logging, widget)
    let mutable children : IPrefab list = []
    abstract member AddChild : 'child -> unit
    member __.Children = children
    interface ILayout with
        member this.Widget1 = this.Widget :> obj
    interface IComboLayout with
        member __.Children = children
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            let prefab = spawner logging
            this.Model.Children.AddLink<'m> (prefab.Model, key) |> ignore
            this.AddChild (prefab.Widget0 :?> 'child)
            children <- children @ [ prefab ]
            this._StylesOnChildAdded prefab
            prefab