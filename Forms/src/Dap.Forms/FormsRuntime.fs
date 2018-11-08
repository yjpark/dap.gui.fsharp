module Dap.Forms.FormsRuntime

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Forms.Feature

type FormsRuntime () =
    interface IRuntime with
        member __.Platform =
            let device = Device.RuntimePlatform
            if device = Device.iOS then
                Platform.Xamarin XamarinPlatform.IOS
            elif device = Device.Android then
                Platform.Xamarin XamarinPlatform.Android
            else
                Platform.Xamarin <| XamarinPlatform.Other (device.ToString ())
        member __.DataFolder = FileSystem.getDataFolder ()
        member __.CacheFolder = FileSystem.getCacheFolder ()
        member __.CreateLogging (args : LoggingArgs) =
            let root = Path.Combine (FileSystem.getCacheFolder (), "log")
            let newArgs = args.WithFolder(root)
            let logging = newArgs.ToSerilogLogging (consoleProvider = ConsoleSinkArgs.FormsProvider)
            logInfo logging "FormsRuntime" "CreateLogging" (encodeJson 4 newArgs)
            if newArgs.File.IsSome then
                logInfo logging "FormsRuntime" "Folder_Updated" (sprintf "%s -> %s", args.File.Value.Folder, newArgs.File.Value.Folder)
            logging :> ILogging
    interface IFallback