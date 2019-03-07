[<RequireQualifiedAccess>]
module Dap.Gui.App.GuiApp

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let mutable private started : bool = false
let mutable private param : obj = null

let internal getParam () =
    param

let internal setParam (param' : obj) =
    if param <> null then
        failWith "Already_Set" (param, param')
    elif started then
        failWith "Already_Started" (param, param')
    else
        param <- param'
        logWarn (getLogging ()) "GuiApp" "setParam" param'

type GuiApp<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IBaseApp>
        (newPresenter : IEnv -> 'presenter, app : 'app) =
    let mutable platform : IGuiPlatform option = None
    let mutable display : IDisplay<'presenter> option = None
    member private __.Run' () =
        started <- true
        platform <- Some <| Feature.create<IGuiPlatform> (app.Env.Logging)
        platform.Value.Init app param
        setupGuiContext' platform.Value
        logWarn platform.Value "GuiApp.Run" (platform.Value.GetType() .FullName) (platform)
        app.OnSetup.AddWatcher platform.Value "OnSetup" (fun result ->
            logWarn platform.Value "GuiApp.Run" "App_OnSetup" (result)
            if result.IsOk then
                runGuiFunc (fun _ ->
                    display <- Some <| platform.Value.Show ^<| newPresenter app.Env
                    display.Value.Presenter.Attach app
                    platform.Value.OnDidAttach app
                )
        )
        platform.Value.Run ()
    member __.Platform = platform.Value
    member __.Display = display
    static member Run p a =
        let guiApp = new GuiApp<'presenter, 'app> (p, a)
        guiApp.Run' ()
