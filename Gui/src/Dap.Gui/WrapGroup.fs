[<AutoOpen>]
module Dap.Gui.WrapGroup

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type WrapGroup<'prefab, 'model, 'group when 'prefab :> IPrefab and 'model :> IGroupProps and 'group :> IGroup and 'group :> IFeature> (kind : Kind, spawner, logging : ILogging) =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let target = Feature.create<'group> logging
    member this.Target = target
    member this.Model = this.Properties
    interface IGroup with
        member this.Widget1 = target.Widget1
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            target.Add<'p, 'm> key spawner
    interface IPrefab<'model>
    interface IPrefab with
        member this.Widget0 = target.Widget1
    member this.AsGroup = this :> IGroup
    member this.AsPrefab = this.Self
