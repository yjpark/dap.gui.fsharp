[<AutoOpen>]
module Dap.Forms.Helper

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Platform
open Dap.Local
open Dap.Forms.Feature

type ConsoleSinkArgs with
    static member FormsCreate (?minLevel : LogLevel) =
        minLevel
        |> Option.bind (fun minLevel ->
            if isRealForms () then
                let device = Device.RuntimePlatform
                not (device = Device.macOS || device = Device.iOS || device = Device.Android)
            else
                true
            |> function
                | true -> Some <| ConsoleSinkArgs.Create (minLevel = minLevel)
                | false -> None
        )

type LoggingArgs with
    static member FormsCreate (?consoleLogLevel : LogLevel, ?filename : string, ?fileLogLevel : LogLevel, ?rolling : RollingInterval) =
        let consoleSink = ConsoleSinkArgs.FormsCreate (?minLevel = consoleLogLevel)
        let fileSink =
            filename
            |> Option.map (fun filename ->
                let root = Path.Combine (FileSystem.getCacheFolder (), "log")
                FileSinkArgs.LocalCreate (root, filename, ?minLevel = fileLogLevel, ?rolling = rolling)
            )
        LoggingArgs.Create (?console = consoleSink, ?file = fileSink)