[<AutoOpen>]
module Faker.Console.ConsoleApp

open FSharp.Control.Tasks.V2

open Terminal.Gui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Console

open Faker.App

type HomePanel = Faker.Gui.Presenter.HomePanel.Presenter

let private buildMenu (console : IConsolePack) =
    new MenuBar ([|
        new MenuBarItem ("_File".ToUString (), [|
            MenuItem("_Quit".ToUString (), null, fun () ->
                console.Quit ()
            )
        |])
    |])


type ConsoleApp (loggingArgs : LoggingArgs, args : AppArgs) =
    inherit App (loggingArgs, args)
    let console = new ConsolePack<IApp, HomePanel>(base.AsApp, HomePanel.Create)

    member __.Console = console
    interface IKeyboardDelegate with
        member __.ProcessKey = None
        member __.ProcessHotKey =
            fun (key : KeyEvent) ->
                let ch = key.KeyValue
                if ch = int('q') then
                    console.Quit ()
                    true
                else
                    false
            |> Some
        member __.ProcessColdKey = None
    static member Run (?scope : string) =
        let (l, a) = App.CreateArgs("faker-.log", ?scope = scope)
        let app = new ConsoleApp (l.WithConsole None, a)
        app.Console.View.SetKeyboardDelegate app
        app.Console.Run ()
        0
