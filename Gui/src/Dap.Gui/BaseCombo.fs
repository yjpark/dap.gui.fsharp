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
    member this.LoadJson' (json : Json) =
        this.Model.AsProperty.LoadJson json
        //logWip this "LoadJson_Model" (encodeJson 4 this.Model)
        this.Children
        |> List.iter (fun child ->
            //logWip this "LoadJson_Child" (encodeJson 4 child.Properties0)
            this._StylesOnChildAdded child
        )
    interface IComboPrefab with
        member this.Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> (key : Key) (spawner : ILogging -> 'p) =
            let prefab = spawner logging
            this.Model.Children.AddLink<'m> (prefab.Model, key)
            |> ignore
            this.AddChild' prefab
            prefab
    interface IComboPrefab<'model>
    member this.AsComboPrefab = this :> IComboPrefab<'model>
