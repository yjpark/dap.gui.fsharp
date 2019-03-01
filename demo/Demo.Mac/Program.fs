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

let useFabulous = true

[<EntryPoint>]
[<STAThread>]
let main argv =
    if useFabulous then
        setFabulousMacParam <| MacParam.Create ("Demo")
        App.RunFabulous ("demo-.log")
    else
        setMacParam <| MacParam.Create ("Demo")
        App.RunGui ("demo-.log")
