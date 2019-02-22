module Demo.Mac.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Mac

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    updateMacParam id
    App.RunGui ("demo.log")
