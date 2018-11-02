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
    member this.AsPrefab = this :> IPrefab<'model, 'widget>

[<AbstractClass>]
type BaseGroup<'prefab, 'model, 'widget when 'prefab :> IGroup and 'prefab :> IPrefab and 'model :> GroupProps> (kind, spawner, logging, widget) =
    inherit BasePrefab<'prefab, 'model, 'widget> (kind, spawner, logging, widget)
    interface IGroup with
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            let prefab = spawner logging
            this.Model.Children.AddLink<'m> (prefab.Model, key) |> ignore
            prefab
