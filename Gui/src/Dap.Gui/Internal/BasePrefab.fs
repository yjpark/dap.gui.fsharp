[<AutoOpen>]
module Dap.Gui.Internal.BasePrefab

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePrefab<'prefab, 'model, 'widget when 'prefab :> IPrefab and 'model :> IViewProps>
        (kind : Kind, spawner, logging : ILogging, widget : 'widget) as self =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let styles = Styles.init self base.Properties.Styles
    member this.Model = this.Properties
    member __.Widget = widget
    member __.Styles = styles
    interface IPrefab<'model, 'widget> with
        member this.Widget = this.Widget
    interface IPrefab with
        member __.Widget0 = widget :> obj
        member __.Styles = styles
        member __.ApplyStyles () =
            styles
            |> List.iter (fun s -> s.Apply ())
    member this.AsPrefab = this :> IPrefab<'model, 'widget>
