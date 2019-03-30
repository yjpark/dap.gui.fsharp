module Demo.iOS.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.iOS

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    setIOSParam <| IOSParam.Create ("Demo")
    App.RunGui ("demo-.log")
