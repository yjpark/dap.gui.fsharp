[<AutoOpen>]
module Dap.Gui.Myra.Internal.Application

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude
open Dap.Gui
open Dap.Gui.Yoga
open Dap.Gui.Myra

type internal Application (param : ApplicationParam) =
    inherit Microsoft.Xna.Framework.Game ()
    let logger : ILogger = getLogger param.Name
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable desktop : Desktop option = None
    let mutable presenter : IPresenter option = None
    let guiContext = GuiSynchronizationContext.CreateAndSetup (logger)
    let inspectKey = Keys.Space
    let mutable quitting : bool = false
    let mutable inspecting : bool = false
    member __.SetPresenter (presenter' : IPresenter) =
        presenter <- Some presenter'
        if desktop.IsSome then
            desktop.Value.Widgets.Clear ()
            desktop.Value.Widgets.Add (presenter.Value.Prefab0.Widget0 :?> MyraWidget)
    member this.Setup (contentRoot : string) =
        this.Content.RootDirectory <- contentRoot
        let graphics = new GraphicsDeviceManager (this)
        graphics.PreferredBackBufferWidth <- param.Width
        graphics.PreferredBackBufferHeight <- param.Height
        graphics.HardwareModeSwitch <- true
        graphics.ApplyChanges ()
        graphicsManager <- Some graphics
    override this.Initialize () =
        base.IsMouseVisible <- true
        base.Initialize ()
        MyraEnvironment.Game <- this :> Microsoft.Xna.Framework.Game
        desktop <- Some <| new Desktop ()
        if presenter.IsSome then
            desktop.Value.Widgets.Add (presenter.Value.Prefab0.Widget0 :?> MyraWidget)
        param.Initializers
        |> List.iter (fun initializer -> initializer this)
    override this.Update (gameTime : GameTime) =
        guiContext.Execute ()
        if not quitting then
            param.ExitKey
            |> Option.iter (fun key ->
                if Keyboard.isKeyDown key then
                    quitting <- true
                    logWarn this "Myra.Application" "Quitting" (key)
                    this.Exit ()
            )
            if inspecting then
                if Keyboard.isKeyUp inspectKey then
                    inspecting <- false
            else
                if Keyboard.isKeyDown inspectKey then
                    inspecting <- true
                    presenter.Value.Prefab0.ApplyStyles ()
                    logLayout presenter.Value.Prefab0
                    logYoga presenter.Value.Prefab0
            base.Update (gameTime)
    override this.Draw (gameTime : GameTime) =
        if not quitting then
            param.ClearColor
            |> Option.iter (fun color ->
                this.GraphicsDevice.Clear (color)
            )
            if presenter.IsSome then
                desktop.Value.Bounds <- new Rectangle(0, 0, this.Width, this.Height)
                desktop.Value.Render ()
            base.Draw (gameTime)
    member __.Width = graphicsManager.Value.PreferredBackBufferWidth
    member __.Height = graphicsManager.Value.PreferredBackBufferHeight
    interface IApplication with
        member this.Xna = this :> Microsoft.Xna.Framework.Game
        member __.Param = param
        member __.GraphicsManager = graphicsManager.Value
        member this.Graphics = this.GraphicsDevice
        member __.Desktop = desktop.Value
        member __.Presenter = presenter.Value
        member this.Width = this.Width
        member this.Height = this.Height
        member __.Quitting = quitting
    member this.AsApplication = this :> IApplication
    interface ILogger with
        member __.Log evt = logger.Log evt