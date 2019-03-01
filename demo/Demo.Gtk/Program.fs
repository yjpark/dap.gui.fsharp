module Demo.Gtk.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gtk

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    setGtkParam <| GtkParam.Create ("Gui.Demo")
    App.RunGui ("demo-.log")
