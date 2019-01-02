[<AutoOpen>]
module Faker.App.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<Literal>]
let Scope = "Faker"

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
                app.AsCorePack.Builder.Context.Reload.Handle ()
            )
        (loggingArgs, args)
