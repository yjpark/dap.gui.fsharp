module Demo.Myra.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Myra

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    initMyra ()
    App.RunGui ("demo.log")
