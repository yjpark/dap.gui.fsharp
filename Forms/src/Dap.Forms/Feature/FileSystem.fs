[<RequireQualifiedAccess>]
module Dap.Forms.Feature.FileSystem

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Forms

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
