[<AutoOpen>]
module Demo.App.Helper

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<Literal>]
let Scope = "Demo"

type App with
    static member Create (logFile, ?scope : string, ?consoleMinLevel : LogLevel) =
        let scope = defaultArg scope Scope
        let loggingArgs = LoggingArgs.CreateBoth (logFile, ?consoleMinLevel = consoleMinLevel)
        let args =
            AppArgs.Create ()
            |> fun a -> a.WithScope scope
            |> fun a -> a.WithSetup (fun app ->
                app.RunTask ignoreOnFailed (fun _runner -> task {
                    do! app.AsCorePack.AddressBook.Context.ReloadAsync.Handle ()
                    app.AsCorePack.AddressBook.Context.Properties.Contacts.Value
                    |> List.iter (fun p ->
                        logInfo app "Load" "Contact" (p.Value.Name, p.Value.Phone)
                    )
                    return ()
                })
            )
        new App (loggingArgs, args)
