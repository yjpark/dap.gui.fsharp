[<AutoOpen>]
module Faker.App.App

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
    let mutable (* ICorePack *) builder : Context.Agent<IBuilder> option = None
    let mutable (* IGuiPack *) appGui : Context.Agent<IAppGui> option = None
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
            let! (* ICorePack *) builder' = env |> Env.addServiceAsync (Dap.Platform.Context.spec args.Builder) AppKinds.Builder AppKeys.Builder
            builder <- Some builder'
            let! (* IGuiPack *) appGui' = env |> Env.addServiceAsync (Dap.Platform.Context.spec args.AppGui) AppKinds.AppGui AppKeys.AppGui
            appGui <- Some appGui'
            do! this.SetupAsync' ()
            logInfo env "App.setupAsync" "Setup_Succeed" (encodeJson 4 args)
            args.Setup this.AsApp
            setupResult <- Some (Ok true)
        with e ->
            setupResult <- Some (Error e)
            logException env "App.setupAsync" "Setup_Failed" (encodeJson 4 args) e
            raise e
    }
    abstract member SetupAsync' : unit -> Task<unit>
    default __.SetupAsync' () = task {
        return ()
    }
    member __.Args : AppArgs = args
    member __.Env : IEnv = env
    member __.SetupResult : Result<bool, exn> option = setupResult
    interface IApp<IApp>
    interface INeedSetupAsync with
        member this.SetupResult = this.SetupResult
        member this.SetupAsync () = this.SetupAsync ()
    interface IRunner<IApp> with
        member this.Runner = this.AsApp
        member this.RunFunc func = runFunc' this func
        member this.AddTask onFailed getTask = addTask' this onFailed getTask
        member this.RunTask onFailed getTask = runTask' this onFailed getTask
    interface IRunner with
        member __.Clock = env.Clock
        member __.Console0 = env.Console0
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
        member __.Builder (* ICorePack *) : Context.Agent<IBuilder> = builder |> Option.get
    member this.AsCorePack = this :> ICorePack
    interface IGuiPack with
        member this.Args = this.Args.AsGuiPackArgs
        member __.AppGui (* IGuiPack *) : Context.Agent<IAppGui> = appGui |> Option.get
    member this.AsGuiPack = this :> IGuiPack
    interface IApp with
        member this.Args : AppArgs = this.Args
        member this.AsCorePack = this.AsCorePack
        member this.AsGuiPack = this.AsGuiPack
    member this.AsApp = this :> IApp