module Demo.Gtk.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Gtk

open Demo.App
type HomePanel = Demo.Gui.Presenter.HomePanel.Presenter

[<EntryPoint>]
[<STAThread>]
let main argv =
    App.Create ("demo.log")
    :> IApp
    |> runGtk HomePanel.Create
