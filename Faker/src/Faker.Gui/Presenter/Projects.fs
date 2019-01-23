[<RequireQualifiedAccess>]
module Faker.Gui.Presenter.Projects

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Faker.App
open Faker.Gui.Prefab

type Prefab = IProjects

type Model = IListProperty<IVarProperty<Faker.App.Types.Project>>

type Presenter (prefab : Prefab, app : IApp) =
    inherit DynamicPresenter<Model, Prefab> (prefab)
    override this.OnWillAttach (items: Model) =
        prefab.ResizeItems items.Value.Length
        (items.Value, prefab.Prefabs)
        ||> List.iter2 (fun item itemPrefab ->
            new Project.Presenter(itemPrefab, app, item.Value) |> ignore
        )