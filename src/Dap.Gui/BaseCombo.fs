[<AutoOpen>]
module Dap.Gui.BaseCombo

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui.Internal

[<AbstractClass>]
type BaseCombo<'prefab, 'model, 'container
        when 'prefab :> IComboPrefab
            and 'model :> ComboProps
            and 'container :> IContainer>
            (kind : Kind, spawner, logging : ILogging) =
    inherit BaseGroup<'prefab, 'model, 'container>
        (kind, spawner, logging, (Feature.create<'container> logging))
    interface IComboPrefab with
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            let prefab = spawner logging
            this.Model.Children.AddLink<'m> (prefab.Model, key)
            |> ignore
            this.AddChild' key prefab
            prefab
    interface IComboPrefab<'model>
    member this.AsComboPrefab = this :> IComboPrefab<'model>
