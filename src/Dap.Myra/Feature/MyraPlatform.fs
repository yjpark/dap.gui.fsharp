[<RequireQualifiedAccess>]
module Dap.Myra.Feature.MyraPlatform

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App
open Dap.Myra

[<Literal>]
let ContentRoot = "Content"

type MyraWindow (platform : IMyraPlatform, param : MyraParam) =
    inherit Microsoft.Xna.Framework.Game ()
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable desktop : Desktop option = None
    let inspectKey = Keys.Space
    let mutable quitting : bool = false
    member this.Init () =
        base.Content.RootDirectory <- ContentRoot
        let graphics = new GraphicsDeviceManager (this)
        graphics.PreferredBackBufferWidth <- param.Width
        graphics.PreferredBackBufferHeight <- param.Height
        graphics.HardwareModeSwitch <- true
        graphics.ApplyChanges ()
        graphicsManager <- Some graphics
        MyraEnvironment.Game <- this :> Microsoft.Xna.Framework.Game
        desktop <- Some <| new Desktop ()
    member __.SetRoot (widget : Widget) =
        desktop.Value.Widgets.Clear ()
        desktop.Value.Widgets.Add (widget)
    override this.Initialize () =
        base.IsMouseVisible <- true
        base.Initialize ()
        param.Actions
        |> List.iter (fun action -> action platform)
    override this.Update (gameTime : GameTime) =
        executeGuiActions' ()
        if not quitting then
            param.ExitKey
            |> Option.iter (fun key ->
                if Keyboard.isKeyDown key then
                    quitting <- true
                    logWarn platform "MyraWindow" "Quitting" (key)
                    this.Exit ()
            )
            (*
            if inspecting then
                if Keyboard.isKeyUp inspectKey then
                    inspecting <- false
            else
                if Keyboard.isKeyDown inspectKey then
                    inspecting <- true
                    display.Value.Presenter0.Prefab0.ApplyStyles ()
                    logLayout display.Value.Presenter0.Prefab0
                    //logYoga presenter.Value.Prefab0
            *)
        base.Update (gameTime)
    override this.Draw (gameTime : GameTime) =
        if not quitting then
            param.ClearColor
            |> Option.iter (fun color ->
                this.GraphicsDevice.Clear (color)
            )
            desktop.Value.Bounds <- new Rectangle(0, 0, this.Width, this.Height)
            desktop.Value.Render ()
            base.Draw (gameTime)
    member __.Desktop = desktop.Value
    member __.Width = graphicsManager.Value.PreferredBackBufferWidth
    member __.Height = graphicsManager.Value.PreferredBackBufferHeight
    interface IMyraWindow with
        member this.Xna = this :> Microsoft.Xna.Framework.Game
        member __.GraphicsManager = graphicsManager.Value
        member this.Graphics = this.GraphicsDevice
        member this.Desktop = this.Desktop
        member this.Width = this.Width
        member this.Height = this.Height
        member __.Quitting = quitting

type Context (logging : ILogging) =
    inherit GuiPlatform.Context<MyraParam, IMyraWindow> (logging, DotNetCore_Myra)
    let mutable window : MyraWindow option = None
    override this.DoInit (param : MyraParam) =
        let window' = new MyraWindow (this, param)
        window'.Init ()
        window <- Some window'
    override this.DoShow (param : MyraParam, presenter : IPresenter) =
        window.Value.SetRoot (presenter.Prefab0.Widget0 :?> Widget)
        window.Value :> IMyraWindow
    override this.DoRun (param : MyraParam) =
        window.Value.Run ()
        0
    interface IMyraPlatform with
        member this.Param = this.Param
        member __.Window = window.Value :> IMyraWindow
    member this.AsMyraPlatform = this :> IMyraPlatform
    interface IFallback
