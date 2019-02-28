module Demo.Ooui.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous.Ooui

open Demo.App
open Demo.Fabulous

[<EntryPoint>]
[<STAThread>]
let main argv =
    setFabulousOouiParam <| OouiParam.Create ("Demo", port = 6000)
    App.RunFabulous ("demo.log")
