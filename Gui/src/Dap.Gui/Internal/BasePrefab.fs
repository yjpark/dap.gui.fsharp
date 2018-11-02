[<AutoOpen>]
module Dap.Gui.Internal.BasePrefab

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePrefab<'prefab, 'model, 'widget when 'prefab :> IPrefab and 'model :> IViewProps>
        (kind : Kind, spawner, logging : ILogging, widget : 'widget) =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    member this.Model = this.Properties
    member __.Widget = widget
    interface IPrefab<'model, 'widget> with
        member this.Widget = this.Widget
    interface IPrefab with
        member this.Widget0 = this.Widget :> obj
    member this.AsPrefab = this :> IPrefab<'model, 'widget>

[<AbstractClass>]
type BaseGroup<'prefab, 'model, 'widget, 'child when 'prefab :> IGroup and 'prefab :> IPrefab and 'model :> GroupProps> (kind, spawner, logging, widget) =
    inherit BasePrefab<'prefab, 'model, 'widget> (kind, spawner, logging, widget)
    abstract member AddChild : 'child -> unit
    interface IGroup with
        member this.Widget1 = this.Widget :> obj
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            let prefab = spawner logging
            this.Model.Children.AddLink<'m> (prefab.Model, key) |> ignore
            this.AddChild (prefab.Widget0 :?> 'child)
            prefab
