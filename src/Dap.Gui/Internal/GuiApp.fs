[<AutoOpen>]
module Dap.Gui.Internal.GuiApp

open System
open System.Globalization

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type GuiApp (app : IBaseApp) =
    static let mutable instance : GuiApp option = None
    let mutable runtime : GuiRuntime option = None
    let logger = app.Env.Logging.GetLogger "GuiApp"
    let mutable state : GuiAppState = Foreground
    let onWillChangeState = new Bus<GuiAppState> (app.Env, "OnWillChangeState")
    let onDidChangeState = new Bus<unit> (app.Env, "OnDidChangeState")
    let mutable hooks : IGuiAppHook list = []
    let mutable themes : Map<string, ITheme> = Map.empty
    let mutable theme : ITheme option = None
    let onWillSwitchTheme = new Bus<ITheme> (app.Env, "OnWillSwitchTheme")
    let onDidSwitchTheme = new Bus<unit> (app.Env, "OnDidSwitchTheme")
    let mutable locales : Map<string, ILocale> = Map.empty
    let mutable locale : ILocale option = None
    let onWillSwitchLocale = new Bus<ILocale> (app.Env, "OnWillSwitchLocale")
    let onDidSwitchLocale = new Bus<unit> (app.Env, "OnDidSwitchLocale")
    let setTheme (theme' : ITheme) =
        if theme.IsNone || theme.Value.Key <> theme'.Key then
            if theme.IsSome then
                onWillSwitchTheme.Trigger theme'
                logWarn logger "SetTheme" theme'.Key (theme, theme')
            else
                logWarn logger "SetTheme" theme'.Key (theme')
            theme <- Some theme'
            onDidSwitchTheme.Trigger ()
        else
            ()
    let setLocale (locale' : ILocale) =
        if locale.IsNone || locale.Value.Key <> locale'.Key then
            if locale.IsSome then
                onWillSwitchLocale.Trigger locale'
                logWarn logger "SetLocale" locale'.Key (locale, locale')
            else
                logWarn logger "SetLocale" locale'.Key (locale')
            locale <- Some locale'
            onDidSwitchLocale.Trigger ()
        else
            ()
    static member Instance = instance.Value
    member internal this.SetInstance (runtime' : GuiRuntime) : unit =
        runtime <- Some runtime'
        if instance.IsSome then
            logError logger "Singleton_Violated" "Instance_Exist" (instance.Value, this)
        else
            let instance' = this :> IGuiApp
            instance <- Some this
            hooks <- Hook.createAll<IGuiAppHook> app.Env.Logging
            hooks
            |> List.iter (fun x -> x.OnInit instance')
    member __.SetState' (state' : GuiAppState) =
        if state <> state' then
            onWillChangeState.Trigger state'
            logWarn logger "SetState" (state'.ToString ()) (state)
            state <- state'
            onDidChangeState.Trigger ()
    member __.Theme =
        if theme.IsNone then
            setTheme (new Theme (app.Env.Logging, NoKey, null) :> ITheme)
        theme.Value
    member this.GetTheme (key : string option) =
        match key with
        | None ->
            this.Theme
        | Some key ->
            themes
            |> Map.tryFind key
            |> Option.defaultWith (fun () ->
                themes
                |> Map.map (fun k _v -> k)
                |> logError logger "GetTheme" ("Not_Exist: " + key)
                this.Theme
            )
    member __.Locale =
        if locale.IsNone then
            setLocale (new Locale (app.Env.Logging, CultureInfo.InvariantCulture, null) :> ILocale)
        locale.Value
    member this.GetLocale (key : string option) =
        match key with
        | None ->
            this.Locale
        | Some key ->
            locales
            |> Map.tryFind key
            |> Option.defaultWith (fun () ->
                locales
                |> Map.map (fun k _v -> k)
                |> logError logger "GetLocale" ("Not_Exist: " + key)
                this.Locale
            )
    interface IGuiApp with
        member __.App = app
        member __.Runtime = runtime.Value
        member __.State = state
        member __.OnWillChangeState = onWillChangeState.Publish
        member __.OnDidChangeState = onDidChangeState.Publish
        member this.Theme = this.Theme
        member __.Themes = themes
        member __.AddTheme (key : string) (param : 'param) (setup : ITheme -> 'param -> unit) =
            themes
            |> Map.tryFind key
            |> function
            | None ->
                let theme' = new Theme (app.Env.Logging, key, param) :> ITheme
                themes <- themes |> Map.add key theme'
                logWarn logger "AddTheme" key (theme')
                setup theme' param
                if theme.IsNone then
                    setTheme theme'
            | Some theme' ->
                logError logger "AddTheme" "Already_Exist" (key, theme')
        member this.GetTheme key = this.GetTheme key
        member this.SwitchTheme (key : string) =
            if this.Theme.Key <> key then
                let theme' = this.GetTheme (Some key)
                setTheme theme'
        member __.OnWillSwitchTheme = onWillSwitchTheme.Publish
        member __.OnDidSwitchTheme = onDidSwitchTheme.Publish
        member this.Locale = this.Locale
        member this.Locales = locales
        member __.AddLocale (key : string) (param : 'param) =
            locales
            |> Map.tryFind key
            |> function
            | None ->
                try
                    Some (new CultureInfo (key))
                with e ->
                    logException logger "Invalid_Locale_Key" key (param) e
                    None
                |> Option.iter (fun culture ->
                    let locale' = new Locale (app.Env.Logging, culture, param) :> ILocale
                    locales <- locales |> Map.add key locale'
                    logWarn logger "AddLocale" key (locale')
                    if locale.IsNone then
                        setLocale locale'
                )
            | Some locale' ->
                logError logger "AddLocale" "Already_Exist" (key, locale')
        member this.GetLocale key = this.GetLocale key
        member this.SwitchLocale (key : string) =
            if this.Locale.Key <> key then
                let locale' = this.GetLocale (Some key)
                setLocale locale'
        member __.OnWillSwitchLocale = onWillSwitchLocale.Publish
        member __.OnDidSwitchLocale = onDidSwitchLocale.Publish
    interface ILogger with
        member __.Log m = logger.Log m
