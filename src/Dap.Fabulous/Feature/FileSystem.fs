[<RequireQualifiedAccess>]
module Dap.Fabulous.Feature.FileSystem

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Fabulous

let getDataFolder () =
    if hasEssentials () then
        Xamarin.Essentials.FileSystem.AppDataDirectory
    else
        ""

let getCacheFolder () =
    if hasEssentials () then
        Xamarin.Essentials.FileSystem.CacheDirectory
    else
        ""
