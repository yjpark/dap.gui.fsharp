[<RequireQualifiedAccess>]
module Demo.Gui.Presenter.Contact

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Demo.App
open Demo.Gui.Prefab

type Prefab = IContact
type Model = Demo.App.Types.Contact

type Presenter (prefab : Prefab, app : IApp, item : Model) =
    inherit BasePresenter<Model, Prefab> (prefab, item)
    do (
        logWip prefab "Setup Contact" (item.Name, item.Phone)
        app.SetGuiValue (prefab.Name.Model.Text, item.Name)
        app.SetGuiValue (prefab.Phone.Model.Text, item.Phone)
    )