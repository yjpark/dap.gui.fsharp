[<AutoOpen>]
module Dap.Gui.GuiHelper

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

let mutable private didSetupGuiContext : bool = false
let mutable private guiContext : SynchronizationContext option = None

let setupGuiContext' (logger : ILogger) =
    match guiContext with
    | Some guiContext' ->
        logError logger "setupGuiContext'" "Already_Setup" guiContext'
    | None ->
        let guiContext' = SynchronizationContext.Current
        if guiContext' =? null then
            logError logger "setupGuiContext'" "Failed" guiContext'
        else
            guiContext <- Some guiContext'
            logInfo logger "setupGuiContext'" "Succeed" guiContext'
    didSetupGuiContext <- true

let getGuiContext () = guiContext |> Option.get

let getGuiTask (getTask : unit -> Task<'res>) : Task<'res> = task {
    return! async {
        while not didSetupGuiContext do
            do! Async.Sleep 50
        (*
        while guiContext.IsNone do
            do! Async.Sleep 50
        *)
        if guiContext.IsSome then
            do! Async.SwitchToContext (getGuiContext ())
        return! Async.AwaitTask (getTask ())
    }
}

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
    member this.RunGuiFunc (func : Func<'runner, unit>) : unit =
        this.RunGuiTask ignoreOnFailed (fun _ -> task {
            runFunc' this.Runner func |> ignore
        })

type IRunner with
    member this.GetGuiTask0 (getTask : GetTask<IRunner, 'res>) : Task<'res> =
        getGuiTask (fun () -> getTask this)
    member this.RunGuiTask0 (onFailed : OnFailed<IRunner>) (getTask : GetTask<IRunner, unit>) : unit =
        this.RunTask0 onFailed (fun _ -> this.GetGuiTask0 getTask)
    member this.RunGuiFunc0 (func : Func<IRunner, unit>) : unit =
        this.RunGuiTask0 ignoreOnFailed (fun _ -> task {
            runFunc' this func |> ignore
        })

type IRunner with
    member this.SetupGuiContext' () = setupGuiContext' this
    member this.SetGuiValue (setter : 'v -> unit, v : 'v) =
        let guiTask = getGuiTask (fun () -> task {
                setter v
            })
        this.RunTask0 ignoreOnFailed (fun _ -> guiTask)
    member this.SetGuiValue (prop : IVarProperty<'v>, v : 'v) =
        this.SetGuiValue (prop.SetValue, v)


