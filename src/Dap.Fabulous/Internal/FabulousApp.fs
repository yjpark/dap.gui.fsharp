[<RequireQualifiedAccess>]
module Dap.Fabulous.Internal.FabulousApp

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous

module ViewTypes = Dap.Fabulous.View.Types

let mutable param : IFabulousParam option = None

let internal hasParam () =
    param.IsSome

let internal getParam () =
    param.Value

let internal setParam<'app, 'model, 'msg when 'app :> IPack and 'model : not struct and 'msg :> IMsg>
        (view : ViewTypes.Args<'app, 'model, 'msg>) =
    if param.IsSome then
        failWith "Already_Set" (param.Value, view)
    else
        let param' = new FabulousParam<'app, 'model, 'msg> (view)
        param <- Some (param' :> IFabulousParam)
        logWarn (getLogging ()) "FabulousApp" "setParam" param'
