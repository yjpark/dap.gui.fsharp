module Demo.iOS.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.iOS
open Dap.Fabulous.iOS

open Demo.App
open Demo.Gui
open Demo.Fabulous

let useFabulous = true

[<EntryPoint>]
[<STAThread>]
let main argv =
    if useFabulous then
        setFabulousIOSParam <| IOSParam.Create ("Demo")
        App.RunFabulous ("demo.log")
    else
        setIOSParam <| IOSParam.Create ("Demo")
        App.RunGui ("demo.log")
