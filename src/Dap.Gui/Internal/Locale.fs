[<AutoOpen>]
module Dap.Gui.Internal.Locale

open System
open System.Globalization

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type internal Locale (logging : ILogging, culture : CultureInfo, param : obj) =
    inherit EmptyContext (logging, GuiLocaleKind)
    static member LanguageOfKey (key : string) =
        let index = key.IndexOf ("_")
        if index > 0 then
            key.Substring (0, index)
        else
            key
    interface ILocale with
        member __.Key = culture.Name
        member __.Param0 = param
        member __.Culture = culture
