[<AutoOpen>]
module Dap.Console.ConsolePack

open Terminal.Gui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type IConsolePack =
    abstract Top : Toplevel with get
    abstract Quit : unit -> unit


type ConsolePack<'app, 'presenter when 'app :> IPack and 'app :> INeedSetupAsync and 'presenter :> IPresenter<'app>> (app : 'app, newPresenter : IEnv -> 'presenter) =
    let view = new ConsoleView<'presenter> (newPresenter app.Env)
    member __.Setup () =
        Application.MainLoop.Invoke (fun () ->
            app.SetupGuiContext' ()
            view.Presenter.Attach app
        )
    member __.Run (?menu : MenuBar) =
        Application.Init ()
        Feature.tryStartApp app
        menu
        |> Option.iter (fun menu ->
            Application.Top.Add menu
            view.Y <- Pos.At(1)
        )
        Application.Top.Add (view)
        logWarn app "EtoPack" "Application_Running" (view.Title.ToString ())
        Application.Run ()
        logWarn app "EtoPack" "Application_Quit" (view.Title.ToString ())
    member __.App = app
    member __.View = view
    member __.Top = Terminal.Gui.Application.Top
    member __.Quit () = Terminal.Gui.Application.Top.Running <- false
    interface IConsolePack with
        member this.Top = this.Top
        member this.Quit () = this.Quit ()
