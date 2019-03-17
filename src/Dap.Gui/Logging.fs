module Dap.Gui.Logging

open System
open System.IO

open Serilog.Core
open Serilog.Events
open Serilog.Formatting

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Local.Feature

type GuiConsoleSink (textFormatter : ITextFormatter) =
    interface ILogEventSink with
        member __.Emit (evt : Serilog.Events.LogEvent) =
            let output = new StringWriter ()
            textFormatter.Format (evt, output)
            Console.WriteLine (output.ToString ())

type ConsoleSinkArgs with
    static member GuiConsoleProvider (this : ConsoleSinkArgs) : AddSink =
        fun config ->
            let formatter = new Serilog.Formatting.Display.MessageTemplateTextFormatter (TextOutputTemplate, null)
            let sink = new GuiConsoleSink (formatter)
            config.WriteTo.Sink(sink, this.MinLevel.ToSerilogLevel)

type GuiLoggingProvider (logging : ILogging) =
    inherit BaseLoggingProvider (logging)
    override this.CreateLogging (args : LoggingArgs) =
        let cacheDirectory = IEnvironment.Instance.Properties.CacheDirectory.Value
        let root = Path.Combine (cacheDirectory, "log")
        let newArgs = args.WithFolder(root)
        let logging = newArgs.ToSerilogLogging (consoleProvider = ConsoleSinkArgs.GuiConsoleProvider)
        logInfo logging "GuiLoggingProvider" "CreateLogging" (encodeJson 4 newArgs)
        if newArgs.File.IsSome then
            logInfo logging "GuiLoggingProvider" "Folder_Updated" (sprintf "%s -> %s", args.File.Value.Folder, newArgs.File.Value.Folder)
        logging :> ILogging
