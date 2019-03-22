[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Skia.Typeface

open System.Reflection

open SkiaSharp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local

type EmbeddedResource with
    static member TryCreateTypeface (relPath : string, ?logger : ILogger, ?assembly : Assembly) =
        let assembly = assembly |> Option.defaultValue (Assembly.GetCallingAssembly ())
        //Note:
        //Can NOT use EmbeddedResource.TryCreateFromStream, which caused the
        //Returned typeface not drawing anything on Android and UWP (works on iOS)
        EmbeddedResource.TryOpenStream (relPath, ?logger = logger, assembly = assembly)
        |> Option.map (fun stream ->
            SKTypeface.FromStream (stream)
        )