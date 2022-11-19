[<AutoOpen>]
module Demo.App.App

open System.Threading
open System.Threading.Tasks
open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform

module Context = Dap.Platform.Context

(*
 * Generated: <App>
 *)
type App (param : EnvParam, args : AppArgs) =
    let env = Env.create param
    let mutable setupResult : Result<bool, exn> option = None
    let onSetup = new Bus<Result<bool, exn>> (env, "App.OnSetup")
    let mutable (* ICorePack *) addressBook : Context.Agent<IAddressBook> option = None
    new (logging : ILogging, a : AppArgs) =
        let platform = Feature.create<IPlatform> logging
        let clock = new RealClock ()
        App (Env.param platform logging a.Scope clock, a)
    new (loggingArgs : LoggingArgs, a : AppArgs) =
        App (Feature.createLogging loggingArgs, a)
    new (a : AppArgs) =
        App (getLogging (), a)
    member this.SetupAsync () : Task<unit> = task {
        if setupResult.IsSome then
            failWith "Already_Setup" setupResult.Value
        try
            setupResult <- Some (Ok false)
            let! (* ICorePack *) addressBook' = env |> Env.addServiceAsync (Dap.Platform.Context.spec args.AddressBook) AppKinds.AddressBook AppKeys.AddressBook
            addressBook <- Some addressBook'
            do! this.SetupAsync' ()
            logInfo env "App.setupAsync" "Setup_Succeed" (encodeJson 4 args)
            args.Setup this.AsApp
            setupResult <- Some (Ok true)
            onSetup.Trigger setupResult.Value
        with e ->
            setupResult <- Some (Error e)
            logException env "App.setupAsync" "Setup_Failed" (encodeJson 4 args) e
            onSetup.Trigger setupResult.Value
            raise e
    }
    abstract member SetupAsync' : unit -> Task<unit>
    default __.SetupAsync' () = task {
        return ()
    }
    member __.Args : AppArgs = args
    member __.Env : IEnv = env
    member __.SetupResult : Result<bool, exn> option = setupResult
    member __.OnSetup : IBus<Result<bool, exn>> = onSetup.Publish
    interface IBaseApp
    interface INeedSetupAsync with
        member this.SetupResult = this.SetupResult
        member this.SetupAsync () = this.SetupAsync ()
        member this.OnSetup = this.OnSetup
    interface IRunner<IApp> with
        member this.Runner = this.AsApp
        member this.RunFunc func = runFunc' this func
        member this.AddTask onFailed getTask = addTask' this onFailed getTask
        member this.RunTask onFailed getTask = runTask' this onFailed getTask
    interface IRunner with
        member __.Clock = env.Clock
        member __.Dash0 = env.Dash0
        member this.RunFunc0 func = runFunc' this func
        member this.AddTask0 onFailed getTask = addTask' this onFailed getTask
        member this.RunTask0 onFailed getTask = runTask' this onFailed getTask
    interface ITaskManager with
        member __.StartTask task = env.StartTask task
        member __.ScheduleTask task = env.ScheduleTask task
        member __.PendingTasksCount = env.PendingTasksCount
        member __.StartPendingTasks () = env.StartPendingTasks ()
        member __.ClearPendingTasks () = env.ClearPendingTasks ()
        member __.RunningTasksCount = env.RunningTasksCount
        member __.CancelRunningTasks () = env.CancelRunningTasks ()
    interface IPack with
        member __.Env : IEnv = env
    interface ILogger with
        member __.Log m = env.Log m
    interface ICorePack with
        member this.Args = this.Args.AsCorePackArgs
        member __.AddressBook (* ICorePack *) : Context.Agent<IAddressBook> = addressBook |> Option.get
    member this.AsCorePack = this :> ICorePack
    interface IApp with
        member this.Args : AppArgs = this.Args
        member this.AsCorePack = this.AsCorePack
    member this.AsApp = this :> IApp