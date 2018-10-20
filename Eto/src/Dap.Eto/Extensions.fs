[<AutoOpen>]
module Dap.Eto.Extensions

open System.Reflection;

open Eto.Forms
open Eto.Drawing

open Dap.Prelude
open Dap.Local

type Bitmap with
    static member FromAssembly (relPath : string, ?assembly : Assembly, ?logger : ILogger) =
        let assembly = assembly |> Option.defaultValue (Assembly.GetCallingAssembly ())
        let resourceName = EmbeddedResource.GetName (relPath, assembly)
        try
            Bitmap.FromResource (resourceName, assembly)
        with e ->
            logException logger "Bitmap.FromAssembly" "Exception_Raised" (assembly, relPath, resourceName) e
            EmbeddedResource.LogNames (logger, assembly)
            raise e

type Icon with
    static member FromAssembly (relPath : string, ?assembly : Assembly, ?logger : ILogger) =
        let assembly = assembly |> Option.defaultValue (Assembly.GetCallingAssembly ())
        let resourceName = EmbeddedResource.GetName (relPath, assembly)
        try
            Icon.FromResource (resourceName, assembly)
        with e ->
            logException logger "Icon.FromAssembly" "Exception_Raised" (assembly, relPath, resourceName) e
            EmbeddedResource.LogNames (logger, assembly)
            raise e
