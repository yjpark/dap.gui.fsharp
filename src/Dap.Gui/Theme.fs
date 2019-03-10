[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.Theme

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Internal

let mutable private fallback : ITheme option = None
let mutable private themes : Map<string, ITheme> = Map.empty

let private getFallback () =
    if fallback.IsNone then
        fallback <- Some (new Theme (NoKey, null) :> ITheme)
        logWarn fallback.Value "Theme.getFallback" "Created" fallback.Value
    fallback.Value

let create (key : string) (param : 'param) (setup : ITheme -> 'param -> unit) =
    themes
    |> Map.tryFind key
    |> function
    | None ->
        let theme = new Theme (key, param) :> ITheme
        themes <- themes |> Map.add key theme
        logWarn theme "Theme.create" key (param, theme)
        setup theme param
        if fallback.IsNone then
            fallback <- Some theme
            logWarn theme "Theme.create" "As_Fallback" key
    | Some theme ->
        failWith ("Already_Exist: " + key) theme

let get (key : string option) =
    match key with
    | None ->
        getFallback ()
    | Some key ->
        themes
        |> Map.tryFind key
        |> Option.defaultWith (fun () ->
            let result = getFallback ()
            themes
            |> Map.map (fun k _v -> k)
            |> logError result "Theme.get" ("Not_Exist: " + key)
            result
        )

let switch (key : string) =
    let theme = get (Some key)
    fallback <- Some theme
    logWarn theme "Theme.switch" key theme