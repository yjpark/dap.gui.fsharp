[<AutoOpen>]
module Dap.Gui.Myra.GuiRunner

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Dap.Gui.Myra.Internal

[<Literal>]
let ContentRoot = "Content"

let mutable param : ApplicationParam =
    ApplicationParam.Create (name = "Myra Application", clearColor = Color.Black, exitKey = Keys.Escape)

let internal setParam (param' : ApplicationParam) =
    param <- param'

type GuiRunner (logging : ILogging) =
    inherit EmptyContext (logging, PlatformKind)
    let application : Application = new Application (param)
    do (
        application.Setup (ContentRoot)
    )
    member __.Application = application :> IApplication
    interface IGuiRunner with
        member __.CreateView<'presenter when 'presenter :> IPresenter> (presenter : 'presenter) : IView<'presenter> =
            application.SetRoot (presenter.Prefab0.Widget0 :?> MyraWidget)
            new View<'presenter, IApplication> (presenter, application.AsApplication)
            :> IView<'presenter>
        member __.RunGuiLoop () =
            application.Run ()
            0
    interface IFallback
