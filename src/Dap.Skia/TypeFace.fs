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
        EmbeddedResource.TryCreateFromStream (relPath, SKTypeface.FromStream, ?logger = logger, ?assembly = assembly)
