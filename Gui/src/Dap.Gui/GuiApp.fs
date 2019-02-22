[<AutoOpen>]
module Dap.Gui.GuiApp

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IGuiRunner =
    inherit IFeature
    abstract CreateView<'presenter when 'presenter :> IPresenter> : 'presenter -> IView<'presenter>
    abstract RunGuiLoop : unit -> int

type View<'presenter, 'display when 'presenter :> IPresenter> (presenter : 'presenter, display : 'display) =
    member this.AsView = this :> IView<'presenter, 'display>
    member this.AsView1 = this :> IView<'presenter>
    member this.AsView0 = this :> IView
    interface IView<'presenter, 'display> with
        member __.Display = display
    interface IView<'presenter> with
        member __.Presenter = presenter
    interface IView with
        member __.Presenter0 = presenter :> IPresenter
        member __.Display0 = display :> obj

type GuiApp<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IPack and 'app :> INeedSetupAsync>
        (newPresenter : IEnv -> 'presenter, app : 'app) =
    let mutable runner : IGuiRunner option = None
    let mutable view : IView<'presenter> option = None
    member private __.Run' () =
        runner <- Some <| Feature.create<IGuiRunner> (app.Env.Logging)
        view <- Some <| runner.Value.CreateView ^<| newPresenter app.Env
        logWarn runner.Value "GuiApp.Run" (runner.Value.GetType() .FullName) (view)
        Feature.tryStartApp app
        app.OnSetup.AddWatcher runner.Value "OnSetup" (fun result ->
            if result.IsOk then
                app.Env.RunGuiFunc0 (fun _ ->
                    view.Value.Presenter.Attach app
                )
        )
        if not <| hasGuiContext () then
            logError runner.Value "GuiApp.Run" "GuiContext_Not_Created" ()
        runner.Value.RunGuiLoop ()
    member __.Runner = runner.Value
    member __.View = view.Value
    static member Run p a =
        let guiApp = new GuiApp<'presenter, 'app> (p, a)
        guiApp.Run' ()

type GuiSynchronizationContext (logger : ILogger) =
    inherit SynchronizationContext ()
    let mainThread = Thread.CurrentThread.ManagedThreadId;
    let pendingCallbacks = new System.Collections.Generic.Queue<SendOrPostCallback * obj> ()
    static member Create l =
        let context = new GuiSynchronizationContext (l)
        SynchronizationContext.SetSynchronizationContext context
        context
    static member CreateAndSetup l =
        let context = GuiSynchronizationContext.Create l
        setupGuiContext' l
        context
    override this.Send (callback : SendOrPostCallback, state : obj) =
        if mainThread = Thread.CurrentThread.ManagedThreadId then
            this.Invoke (callback, state)
        else
            this.Post (callback, state)
    override __.Post (callback : SendOrPostCallback, state : obj) =
        lock pendingCallbacks (fun () ->
            pendingCallbacks.Enqueue (callback, state)
        )
    member __.Invoke (callback : SendOrPostCallback, state : obj) =
        try
            callback.Invoke (state)
        with e ->
            logError logger "GuiSynchronizationContext" "Exception_Raised" (callback, state, e)
    member this.Execute (?maxActionCount : int) =
        let maxActionCount = defaultArg maxActionCount -1
        lock pendingCallbacks (fun () ->
            let mutable count = 0
            while pendingCallbacks.Count > 0 && (maxActionCount < 0 || count <= maxActionCount) do
                let (callback, state) = pendingCallbacks.Dequeue ()
                this.Invoke (callback, state)
                count <- count + 1
        )

let runGuiApp<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IPack and 'app :> INeedSetupAsync>
    (newPresenter : IEnv -> 'presenter) (app : 'app) =
    GuiApp<'presenter, 'app>.Run newPresenter app