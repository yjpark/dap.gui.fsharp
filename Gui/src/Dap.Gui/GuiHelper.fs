[<AutoOpen>]
module Dap.Gui.GuiHelper

open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IText with
    member this.SetGuiText (runner : IRunner) (v : string) =
        let guiTask = getGuiTask (fun () -> task {
                this.Text.SetValue v
            })
        runner.RunTask0 ignoreOnFailed (fun _ -> guiTask)

type IControl with
    member this.SetGuiDisabled (runner : IRunner) (v : bool) =
        let guiTask = getGuiTask (fun () -> task {
                this.Disabled.SetValue v
            })
        runner.RunTask0 ignoreOnFailed (fun _ -> guiTask)
