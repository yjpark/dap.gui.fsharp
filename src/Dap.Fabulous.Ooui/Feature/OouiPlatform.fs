[<RequireQualifiedAccess>]
module Dap.Fabulous.Ooui.Feature.OouiPlatform

open System
open System.Threading

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous
open Dap.Fabulous.Ooui

let private onExit (logging : ILogging) (logger : ILogger) (exited : AutoResetEvent) =
    fun (_sender : obj) (cancelArgs : ConsoleCancelEventArgs) ->
        logWarn logger OouiPlatformKind "Quitting ..." cancelArgs
        logging.Close ()
        exited.Set() |> ignore

let private waitForExit (logging : ILogging) (logger : ILogger) =
    let exited = new AutoResetEvent(false)
    let onExit' = new ConsoleCancelEventHandler (onExit logging logger exited)
    Console.CancelKeyPress.AddHandler onExit'
    exited.WaitOne() |> ignore

type Context (logging : ILogging) =
    inherit GuiPlatform.Context<OouiParam, int> (logging, OouiPlatformKind)
    override this.DoInit (param : OouiParam) =
        Ooui.UI.Port <- param.Port
        Xamarin.Forms.Forms.Init ()
        let fabulousParam = getFabulousParam ()
        Xamarin.Forms.Forms.LoadApplication fabulousParam.Application
    override this.DoShow (param : OouiParam, presenter : IPresenter) =
        param.Port
    override this.DoRun (param : OouiParam) =
        waitForExit logging this
        0
    interface IOouiPlatform with
        member this.Param = this.Param
    member this.AsOouiPlatform = this :> IOouiPlatform
