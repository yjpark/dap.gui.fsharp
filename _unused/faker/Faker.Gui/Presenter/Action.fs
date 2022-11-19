[<RequireQualifiedAccess>]
module Faker.Gui.Presenter.Action

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Faker.App
open Faker.Gui.Prefab

type Prefab = IAction
type Model = string

type Presenter (prefab : Prefab, app : IApp, item : Model) =
    inherit BasePresenter<Model, Prefab> (prefab, item)
    do (
        app.SetGuiValue (prefab.Exec.Model.Text, item)
        app.SetGuiValue (prefab.ExecSingle.Model.Text, sprintf "%s Only" item)
    )