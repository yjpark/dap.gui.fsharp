module Demo.Gtk.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Gtk

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    updateGtkParam id
    App.RunGui ("demo.log")
