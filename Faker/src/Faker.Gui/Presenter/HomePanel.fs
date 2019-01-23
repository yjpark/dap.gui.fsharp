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
    override this.OnDidAttach () =
        let prefab = this.Prefab
        let app = this.Domain.Value
        let projects = app.Builder.Context.Properties.Projects
        let projects' = new Projects.Presenter (prefab.Projects, app)
        projects.OnAdded.AddWatcher prefab "ProjectsOnAdded" (fun _ ->
            projects'.Attach projects
        )
        if projects.Count > 0 then
            projects'.Attach projects
        ()
    static member Create e = new Presenter (e)