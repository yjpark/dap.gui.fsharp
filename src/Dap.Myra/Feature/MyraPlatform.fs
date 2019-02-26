[<AutoOpen>]
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

type MyraPlatform (logging : ILogging) =
    inherit Microsoft.Xna.Framework.Game ()
    let context = new EmptyContext (logging, "MyraPlatform") :> IContext
    let mutable param : MyraParam option = None
    let mutable graphicsManager : GraphicsDeviceManager option = None
    let mutable desktop : Desktop option = None
    let mutable display : IDisplay option = None
    let inspectKey = Keys.Space
    let mutable quitting : bool = false
    let mutable inspecting : bool = false
    member private this.DoInit (param' : obj) =
        param <- Some (param' :?> MyraParam)
        base.Content.RootDirectory <- ContentRoot
        let graphics = new GraphicsDeviceManager (this)
        graphics.PreferredBackBufferWidth <- param.Value.Width
        graphics.PreferredBackBufferHeight <- param.Value.Height
        graphics.HardwareModeSwitch <- true
        graphics.ApplyChanges ()
        graphicsManager <- Some graphics
        MyraEnvironment.Game <- this :> Microsoft.Xna.Framework.Game
    member private this.DoSetup (presenter' : IPresenter) =
        desktop <- Some <| new Desktop ()
        desktop.Value.Widgets.Clear ()
        desktop.Value.Widgets.Add (presenter'.Prefab0.Widget0 :?> MyraWidget)
    member private this.Run () =
        base.Run ()
        0
    override this.Initialize () =
        base.IsMouseVisible <- true
        base.Initialize ()
        param.Value.Actions
        |> List.iter (fun action -> action this)
    override this.Update (gameTime : GameTime) =
        executeGuiActions' ()
        if not quitting then
            param.Value.ExitKey
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
                    display.Value.Presenter0.Prefab0.ApplyStyles ()
                    logLayout display.Value.Presenter0.Prefab0
                    //logYoga presenter.Value.Prefab0
            base.Update (gameTime)
    override this.Draw (gameTime : GameTime) =
        if not quitting then
            param.Value.ClearColor
            |> Option.iter (fun color ->
                this.GraphicsDevice.Clear (color)
            )
            desktop.Value.Bounds <- new Rectangle(0, 0, this.Width, this.Height)
            desktop.Value.Render ()
            base.Draw (gameTime)
    member __.Width = graphicsManager.Value.PreferredBackBufferWidth
    member __.Height = graphicsManager.Value.PreferredBackBufferHeight
    interface IMyraPlatform with
        member __.Param = param.Value
        member this.Xna = this :> Microsoft.Xna.Framework.Game
        member __.GraphicsManager = graphicsManager.Value
        member this.Graphics = this.GraphicsDevice
        member __.Desktop = desktop.Value
        member this.Width = this.Width
        member this.Height = this.Height
        member __.Quitting = quitting
    member this.AsMyraPlatform = this :> IMyraPlatform
    //SILP: GUI_PLATFORM_FOOTER(MyraPlatform, Desktop, desktop.Value)
    interface IGuiPlatform with                                              //__SILP__
        member __.Param0 = param :> obj                                      //__SILP__
        member __.Display = display.Value                                    //__SILP__
        member this.Init param' =                                            //__SILP__
            if param.IsSome then                                             //__SILP__
                failWith "Already_Init" (param, param')                      //__SILP__
            this.DoInit param'                                               //__SILP__
        member this.Setup presenter' =                                       //__SILP__
            if display.IsSome then                                           //__SILP__
                failWith "Already_Setup" (display, presenter')               //__SILP__
            this.DoSetup presenter'                                          //__SILP__
            let display' = new Display<'presenter, Desktop> (desktop.Value)  //__SILP__
            display'.SetPresenter presenter'                                 //__SILP__
            display <- Some (display' :> IDisplay)                           //__SILP__
            display' :> IDisplay<'presenter>                                 //__SILP__
        member this.Run () = this.Run ()                                     //__SILP__
    member this.AsGuiPlatform = this :> IGuiPlatform                         //__SILP__
    interface IContext with                                                  //__SILP__
        member __.Dispose () = failWith "MyraPlatform" "Can_Not_Dispose"     //__SILP__
        member __.Spec0 = context.Spec0                                      //__SILP__
        member __.Properties0 = context.Properties0                          //__SILP__
        member __.Channels = context.Channels                                //__SILP__
        member __.Handlers = context.Handlers                                //__SILP__
        member __.AsyncHandlers = context.AsyncHandlers                      //__SILP__
        member __.Clone0 l = failWith "MyraPlatform" "Can_Not_Clone"         //__SILP__
    interface IOwner with                                                    //__SILP__
        member __.Luid = ""                                                  //__SILP__
        member __.Disposed = false                                           //__SILP__
    interface IJson with                                                     //__SILP__
        member __.ToJson () = toJson context                                 //__SILP__
    interface ILogger with                                                   //__SILP__
        member __.Log evt = context.Log evt                                  //__SILP__
