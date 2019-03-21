[<AutoOpen>]
module Dap.Gui.Helper

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Internal

type IGuiApp with
    static member Instance = GuiApp.Instance :> IGuiApp


type IRunner<'runner when 'runner :> IRunner> with
    member this.RunGuiFunc (func : Func<'runner, unit>) : unit =
        runGuiFunc (fun () -> func this.Runner)

type IRunner with
    member this.RunGuiFunc0 (func : Func<IRunner, unit>) : unit =
        runGuiFunc (fun () -> func this)

type IRunner with
    member this.SetGuiValue (setter : 'v -> unit, v : 'v) =
        runGuiFunc (fun () -> setter v)
    member this.SetGuiValue (prop : IVarProperty<'v>, v : 'v) =
        this.SetGuiValue (prop.SetValue, v)

type IAsyncHandler<'req, 'res>  with
    member this.SetupGuiHandler' (handler' : 'req -> Task<'res>) =
        fun (req : 'req) ->
            getGuiTask (fun () -> handler' req)
        |> this.SetupHandler'
    member this.SetupGuiHandler (handler : 'req -> Task<'res>) =
        this.SetupGuiHandler' handler
        this.Seal ()

type IRunner<'runner when 'runner :> IRunner> with
    member this.GetGuiTask (getTask : GetTask<'runner, 'res>) : Task<'res> =
        getGuiTask (fun () -> getTask this.Runner)
    member this.RunGuiTask (onFailed : OnFailed<'runner>) (getTask : GetTask<'runner, unit>) : unit =
        this.RunTask onFailed (fun _ -> this.GetGuiTask getTask)

type IRunner with
    member this.GetGuiTask0 (getTask : GetTask<IRunner, 'res>) : Task<'res> =
        getGuiTask (fun () -> getTask this)
    member this.RunGuiTask0 (onFailed : OnFailed<IRunner>) (getTask : GetTask<IRunner, unit>) : unit =
        this.RunTask0 onFailed (fun _ -> this.GetGuiTask0 getTask)

