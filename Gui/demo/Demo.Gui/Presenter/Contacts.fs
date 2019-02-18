[<RequireQualifiedAccess>]
module Demo.Gui.Presenter.Contacts

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Demo.App
open Demo.Gui.Prefab

type Prefab = IContacts

type Model = IListProperty<IVarProperty<Demo.App.Types.Contact>>

type Presenter (prefab : Prefab, app : IApp) =
    inherit DynamicPresenter<Model, Prefab> (prefab)
    override this.OnWillAttach (items: Model) =
        prefab.ResizeItems items.Value.Length
        (items.Value, prefab.Prefabs)
        ||> List.iter2 (fun item itemPrefab ->
            new Contact.Presenter(itemPrefab, app, item.Value) |> ignore
        )