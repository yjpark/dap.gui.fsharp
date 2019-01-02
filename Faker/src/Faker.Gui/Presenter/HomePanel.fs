[<RequireQualifiedAccess>]
module Faker.Gui.Presenter.HomePanel

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Faker.App
open Faker.Gui.Prefab

type Prefab = IHomePanel

type Presenter (env : IEnv) =
    inherit BasePresenter<IApp, Prefab> (Feature.create<Prefab> env.Logging)

    override this.OnAttached () =
        let prefab = this.Prefab
        let app = this.Domain.Value
        (*
        let linkStatus = new LinkStatus.Presenter (prefab.LinkStatus, app)
        let history = new Clips.Presenter (prefab.History, app)
        app.History.Actor.OnEvent.AddWatcher prefab "OnHistory" (fun _ ->
            history.Attach (app.History.Actor.State.RecentItems)
        )
        *)
        ()

    static member Create e = new Presenter (e)