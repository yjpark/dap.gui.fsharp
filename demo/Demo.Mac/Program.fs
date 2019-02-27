module Demo.Mac.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Mac
open Dap.Fabulous.Mac

open Demo.App
open Demo.Gui
open Demo.Fabulous

[<EntryPoint>]
[<STAThread>]
let main argv =
    //setMacParam <| MacParam.Create ("Demo")
    //App.RunGui ("demo.log")
    setFabulousMacParam <| MacParam.Create ("Demo")
    App.RunFabulous ("demo.log")
