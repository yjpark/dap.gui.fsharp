[<RequireQualifiedAccess>]
module Faker.Gui.Presenter.Project

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Faker.App
open Faker.Gui.Prefab

type Prefab = IProject
type Model = Faker.App.Types.Project

type Presenter (prefab : Prefab, app : IApp, item : Model) =
    inherit BasePresenter<Model, Prefab> (prefab, item)
    do (
        logWip prefab "Setup Project" (item.Name, item.Actions)
        app.SetGuiValue (prefab.Name.Model.Text, item.Name)
        let actions = new Actions.Presenter (prefab.Actions, app, item.Actions)
        ()
    )