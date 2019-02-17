[<AutoOpen>]
module Dap.Gui.GuiApp

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IGuiRunner =
    inherit IFeature
    abstract CreateView<'presenter when 'presenter :> IPresenter> : 'presenter -> IView<'presenter>
    abstract RunGuiLoop : unit -> int

type View<'presenter, 'display when 'presenter :> IPresenter> (presenter : 'presenter, display : 'display) =
    member this.AsView = this :> IView<'presenter, 'display>
    member this.AsView1 = this :> IView<'presenter>
    member this.AsView0 = this :> IView
    interface IView<'presenter, 'display> with
        member __.Display = display
    interface IView<'presenter> with
        member __.Presenter = presenter
    interface IView with
        member __.Presenter0 = presenter :> IPresenter
        member __.Display0 = display :> obj

type GuiApp<'app, 'presenter when 'app :> IPack and 'app :> INeedSetupAsync and 'presenter :> IPresenter>
        (app : 'app, newPresenter : IEnv -> 'presenter) =
    let runner : IGuiRunner = Feature.create<IGuiRunner> (app.Env.Logging)
    let view : IView<'presenter> = runner.CreateView <| newPresenter app.Env
    member private __.Run' () =
        Feature.tryStartApp app
        runner.RunGuiLoop ()
    member __.View = view
    static member Run a p =
        let guiApp = new GuiApp<'app, 'presenter> (a, p)
        guiApp.Run' ()