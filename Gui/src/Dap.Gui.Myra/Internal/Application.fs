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
open Dap.Gui.Myra

type internal Application (param : ApplicationParam) =
    inherit Microsoft.Xna.Framework.Game ()
    let logger : ILogger = getLogger param.Name
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable desktop : Desktop option = None
    let mutable root : MyraWidget option = None
    let guiContext = GuiSynchronizationContext.CreateAndSetup (logger)
    let inspectKey = Keys.Space
    member __.SetRoot (root' : MyraWidget) =
        root <- Some root'
        if desktop.IsSome then
            desktop.Value.Widgets.Clear ()
            desktop.Value.Widgets.Add root'
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
        if root.IsSome then
            desktop.Value.Widgets.Add root.Value
        param.Initializers
        |> List.iter (fun initializer -> initializer this)
    override this.Update (gameTime : GameTime) =
        guiContext.Execute ()
        param.ExitKey
        |> Option.iter (fun key ->
            if Keyboard.isKeyDown key then
                logWarn this "Myra.Application" "Quitting" (key)
                this.Exit ()
        )
        if Keyboard.isKeyDown inspectKey then
            logLayout logger root.Value
        base.Update (gameTime)
    override this.Draw (gameTime : GameTime) =
        param.ClearColor
        |> Option.iter (fun color ->
            this.GraphicsDevice.Clear (color)
        )
        if root.IsSome then
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
        member __.Root = root.Value
        member this.Width = this.Width
        member this.Height = this.Height
    member this.AsApplication = this :> IApplication
    interface ILogger with
        member __.Log evt = logger.Log evt