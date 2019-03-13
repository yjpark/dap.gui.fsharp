module Dap.UWP.Hook.GuiApp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Hook (logging : ILogging) =
    inherit EmptyContext(logging, "UWP.GuiApp.Hooks")
    let nativeHooks = CliHook.createAll<Dap.UWP.Cli.IGuiAppHook> (logging)
    interface IGuiAppHook with
        member this.OnInit (app : IGuiApp) =
            nativeHooks
            |> List.iter (fun hook -> hook.OnInit (app))


