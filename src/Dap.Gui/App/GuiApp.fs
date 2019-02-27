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

type GuiApp<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IPack and 'app :> INeedSetupAsync>
        (newPresenter : IEnv -> 'presenter, app : 'app) =
    let mutable platform : IGuiPlatform option = None
    let mutable display : IDisplay<'presenter> option = None
    member private __.Run' () =
        started <- true
        platform <- Some <| Feature.create<IGuiPlatform> (app.Env.Logging)
        platform.Value.Init param
        setupGuiContext' platform.Value
        display <- Some <| platform.Value.Setup ^<| newPresenter app.Env
        logWarn platform.Value "GuiApp.Run" (platform.Value.GetType() .FullName) (platform, display)
        app.OnSetup.AddWatcher platform.Value "OnSetup" (fun result ->
            if result.IsOk then
                runGuiFunc (fun _ ->
                    display.Value.Presenter.Attach app
                    platform.Value.OnDidAttach app
                )
        )
        Feature.tryStartApp app
        platform.Value.Run ()
    member __.Platform = platform.Value
    member __.Display = display.Value
    static member Run p a =
        let guiApp = new GuiApp<'presenter, 'app> (p, a)
        guiApp.Run' ()
