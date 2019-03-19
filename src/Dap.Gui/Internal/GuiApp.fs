[<AutoOpen>]
module Dap.Gui.Internal.GuiApp

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type GuiApp (app : IBaseApp) =
    static let mutable instance : GuiApp option = None
    let logger = app.Env.Logging.GetLogger "GuiApp"
    let mutable state : GuiAppState = Foreground
    let onWillChangeState = new Bus<GuiAppState> (app.Env, "OnWillChangeState")
    let onDidChangeState = new Bus<unit> (app.Env, "OnDidChangeState")
    let mutable hooks : IGuiAppHook list = []
    let mutable themes : Map<string, ITheme> = Map.empty
    let mutable theme : ITheme option = None
    let onWillSwitchTheme = new Bus<ITheme> (app.Env, "OnWillSwitchTheme")
    let onDidSwitchTheme = new Bus<unit> (app.Env, "OnDidSwitchTheme")
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
    static member Instance = instance.Value
    member internal this.SetInstance () : unit =
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
    member __.App = app
    member __.State = state
    member __.Theme =
        if theme.IsNone then
            setTheme (new Theme (NoKey, null) :> ITheme)
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
    interface IGuiApp with
        member __.App = app
        member this.State = this.State
        member __.OnWillChangeState = onWillChangeState.Publish
        member __.OnDidChangeState = onDidChangeState.Publish
        member this.Theme = this.Theme
        member __.AddTheme (key : string) (param : 'param) (setup : ITheme -> 'param -> unit) =
            themes
            |> Map.tryFind key
            |> function
            | None ->
                let theme' = new Theme (key, param) :> ITheme
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
    interface ILogger with
        member __.Log m = logger.Log m
