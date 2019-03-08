module Demo.Myra.Program

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Myra
open Dap.Gui

open Demo.App
open Demo.Gui

[<EntryPoint>]
[<STAThread>]
let main argv =
    //initYogaGtk ()
    //YogaStyles.register (Themes.getFallback ())
    setMyraParam <| MyraParam.Create ("Demo", clearColor = Color.Black)
    App.RunGui ("demo-.log")
