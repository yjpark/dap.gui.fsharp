[<AutoOpen>]
module Faker.App.Helper

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<Literal>]
let Scope = "Faker"

[<Literal>]
let AllProjects = "All Projects"

type IApp with
    member this.Gui = this.AsGuiPack.AppGui.Context

type App with
    static member CreateArgs (logFile, ?scope : string, ?consoleMinLevel : LogLevel) =
        let scope = defaultArg scope Scope
        let loggingArgs = LoggingArgs.CreateBoth (logFile, ?consoleMinLevel = consoleMinLevel)
        let args =
            AppArgs.Create ()
            |> fun a -> a.WithScope scope
            |> fun a -> a.WithSetup (fun app ->
                app.RunTask ignoreOnFailed (fun _runner -> task {
                    do! app.AsCorePack.Builder.Context.ReloadAsync.Handle ()
                    app.AsCorePack.Builder.Context.Properties.Projects.Value
                    |> List.iter (fun p ->
                        logInfo app "Load" "Project" (p.Value.Name, p.Value.Actions)
                    )
                    return ()
                })
            )
        (loggingArgs, args)
