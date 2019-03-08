[<AutoOpen>]
module Dap.Fabulous.Helper

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous.Internal
open Dap.Fabulous.Theme

module ViewTypes = Dap.Fabulous.View.Types

let hasFabulousParam () =
    FabulousApp.hasParam ()

let getFabulousParam () =
    FabulousApp.getParam ()

let setFabulousParam<'app, 'model, 'msg when 'app :> IPack and 'model : not struct and 'msg :> IMsg>
        (view : ViewTypes.Args<'app, 'model, 'msg>) =
    FabulousApp.setParam view

let runFabulousApp<'app, 'model, 'msg
        when 'app :> IBaseApp
            and 'model : not struct and 'msg :> IMsg> (app : 'app) =
    let param = getFabulousParam () :?> FabulousParam<'app, 'model, 'msg>
    let newPresenter = fun (env : IEnv) ->
        new FabulousPresenter<'app, 'model, 'msg> (param, env)
    runGuiApp newPresenter app
