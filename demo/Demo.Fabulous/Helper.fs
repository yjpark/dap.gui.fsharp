[<AutoOpen>]
module Demo.Fabulous.Helper

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous

open Demo.App
module ViewTypes = Demo.Fabulous.View.Types
module ViewLogic = Demo.Fabulous.View.Logic

type App with
    static member RunFabulous (logFile, ?scope : string, ?consoleMinLevel : LogLevel) : int =
        setFabulousParam <| ViewLogic.newArgs ()
        App.Create (logFile, ?scope = scope, ?consoleMinLevel = consoleMinLevel)
        :> IApp
        |> runFabulousApp<IApp, ViewTypes.Model, ViewTypes.Msg>