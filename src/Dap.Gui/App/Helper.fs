[<AutoOpen>]
module Dap.Gui.App.Helper

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let getGuiParam () =
    GuiApp.getParam ()

let setGuiParam<'obj> (param : 'obj) =
    GuiApp.setParam param

let runGuiApp<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IPack and 'app :> INeedSetupAsync>
    (newPresenter : IEnv -> 'presenter) (app : 'app) =
    GuiApp.GuiApp<'presenter, 'app>.Run newPresenter app