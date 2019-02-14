[<AutoOpen>]
module Dap.Gui.WrapCombo

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type WrapCombo<'prefab, 'model, 'layout when 'prefab :> IPrefab and 'model :> ComboProps and 'layout :> IComboLayout and 'layout :> IFeature> (kind : Kind, spawner, logging : ILogging) =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let target = Feature.create<'layout> logging
    member __.Target = target
    member this.Model = this.Properties
    interface IPrefab with
        member __.Widget0 = target.Widget1
        member __.Styles = target.Styles
        member __.ApplyStyles () = target.ApplyStyles ()
    interface ILayout with
        member __.Widget1 = target.Widget1
    interface IComboLayout with
        member __.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            target.Add<'p, 'm> key spawner
    interface IComboLayout<'model>
    member this.AsLayout = this :> ILayout
    member this.AsComboLayout = this :> IComboLayout
    member this.AsPrefab = this.Self
