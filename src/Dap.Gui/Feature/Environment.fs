[<RequireQualifiedAccess>]
module Dap.Gui.Feature.Environment

open Dap.Prelude
open Dap.Context
open Dap.Gui

type Context (logging : ILogging) =
    inherit Dap.Local.Feature.Environment.Context<Context> (logging)
    do (
        if hasEssentials () then
            base.Properties.DataDirectory.SetValue Xamarin.Essentials.FileSystem.AppDataDirectory
            base.Properties.CacheDirectory.SetValue Xamarin.Essentials.FileSystem.CacheDirectory
    )
    override this.Self = this
    override __.Spawn l = new Context (l)


