[<AutoOpen>]
namespace Demo.Fabulous.Helper

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Demo.App
module ViewTypes = SuperClip.Forms.View.Types
module ViewLogic = SuperClip.Forms.View.Logic

type App with
    static member RunFabulous (logFile, ?scope : string, ?consoleMinLevel : LogLevel) : int =
        App.Create (logFile, ?scope = scope, ?consoleMinLevel = consoleMinLevel)
        :> IApp
        |> runGuiApp ^<| newPresenter<IApp> ^<| ViewLogic.newArgs ()