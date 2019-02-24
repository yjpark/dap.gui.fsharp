[<RequireQualifiedAccess>]
module Faker.Gui.Presenter.Actions

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Faker.App
open Faker.Gui.Prefab

type Prefab = IActions

type Model = string list

type Presenter (prefab : Prefab, app : IApp, items : Model) =
    inherit BasePresenter<Model, Prefab> (prefab, items)
    do (
        prefab.ResizeItems items.Length
        (items, prefab.Prefabs)
        ||> List.iter2 (fun item itemPrefab ->
            new Action.Presenter(itemPrefab, app, item) |> ignore
        )
    )