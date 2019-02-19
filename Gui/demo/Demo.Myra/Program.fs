module Demo.Myra.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Myra

open Demo.App
type HomePanel = Demo.Gui.Presenter.HomePanel.Presenter

[<EntryPoint>]
[<STAThread>]
let main argv =
    Demo.Gui.YogaStyles.register ()
    App.Create ("demo.log")
    :> IApp
    |> runMyra HomePanel.Create
