[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.Internal.Locale

open System
open System.Globalization

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

// Full list of known language tags
// https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c

[<Literal>]
let EN = "en"

[<Literal>]
let ZH_CN = "zh-CN"

let getNativeName (culture : CultureInfo) =
    let name = culture.NativeName
    if name <> culture.EnglishName then
        name
    else
        match culture.Name with
        | ZH_CN -> "简体中文"
        | _ -> name

let getSwitchText (culture : CultureInfo) =
    match culture.Name with
    | ZH_CN -> "切换"
    | _ -> "Switch"

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
