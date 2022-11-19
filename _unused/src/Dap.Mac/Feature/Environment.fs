[<RequireQualifiedAccess>]
module Dap.Mac.Feature.Environment

open System.IO
open Foundation

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Mac

type Context (logging : ILogging) =
    inherit Dap.Local.Feature.Environment.Context<Context> (logging)
    do (
        let props = base.Properties
        props.DataDirectory.SetValue <| getAppDirectory NSSearchPathDirectory.ApplicationSupportDirectory
        props.CacheDirectory.SetValue <| getAppDirectory NSSearchPathDirectory.CachesDirectory
        logWarn base.AsEnvironment "Data_Directory" props.DataDirectory.Value ()
        logWarn base.AsEnvironment "Cache_Directory" props.CacheDirectory.Value ()
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
    interface IOverride
