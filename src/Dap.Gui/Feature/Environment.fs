[<RequireQualifiedAccess>]
module Dap.Gui.Feature.Environment

open Dap.Prelude
open Dap.Context
open Dap.Gui

type Context (logging : ILogging) =
    inherit Dap.Local.Feature.Environment.Context<Context> (logging)
    do (
        if hasEssentials () then
            let props = base.Properties
            props.DataDirectory.SetValue Xamarin.Essentials.FileSystem.AppDataDirectory
            props.CacheDirectory.SetValue Xamarin.Essentials.FileSystem.CacheDirectory
            logWarn base.AsEnvironment "Data_Directory" props.DataDirectory.Value ()
            logWarn base.AsEnvironment "Cache_Directory" props.CacheDirectory.Value ()
    )
    override this.Self = this
    override __.Spawn l = new Context (l)


