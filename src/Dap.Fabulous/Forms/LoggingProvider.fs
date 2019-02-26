module Dap.Fabulous.Forms.LoggingProvider

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Fabulous

//TODO: Delete this file after all platform got their own provider
type LoggingProvider (logging : ILogging) =
    inherit BaseLoggingProvider (logging)
    override this.CreateLogging (args : LoggingArgs) =
        let root = Path.Combine (FileSystem.getCacheFolder (), "log")
        let newArgs = args.WithFolder(root)
        let logging = newArgs.ToSerilogLogging (consoleProvider = ConsoleSinkArgs.FormsProvider)
        logInfo logging "FormsLoggingProvider" "CreateLogging" (encodeJson 4 newArgs)
        if newArgs.File.IsSome then
            logInfo logging "FormsLoggingProvider" "Folder_Updated" (sprintf "%s -> %s", args.File.Value.Folder, newArgs.File.Value.Folder)
        logging :> ILogging