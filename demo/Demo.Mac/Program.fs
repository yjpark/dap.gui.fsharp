module Demo.Mac.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Mac

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    setMacParam <| MacParam.Create ("Demo")
    App.RunGui ("demo.log")
