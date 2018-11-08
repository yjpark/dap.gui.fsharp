[<AutoOpen>]
module Dap.Eto.Program

open Eto
open Eto.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type EtoPack<'app, 'presenter when 'app :> IPack and 'presenter :> IPresenter<'app>> (platform : Platform, app : 'app, newPresenter : IEnv -> 'presenter) =
    let application = new Application (platform)
    let view = new FormView<'presenter> (newPresenter app.Env)
    member __.Setup () =
        application.Invoke (fun () ->
            app.SetupGuiContext' ()
            view.Presenter.Attach app
        )
    member __.Run () =
        logWarn app "EtoPack" "Application_Running" (application.Name, view.Title)
        application.Run (view)
        logWarn app "EtoPack" "Application_Quit" (application.Name, view.Title)
    member __.App = app
    member __.Application = application
    member __.View = view