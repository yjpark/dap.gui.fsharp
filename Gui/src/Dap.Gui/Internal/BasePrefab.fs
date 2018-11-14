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
