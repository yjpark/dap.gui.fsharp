[<AutoOpen>]
module Dap.Gui.Gtk.GuiRunner

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Dap.Gui.Gtk.Internal

let mutable param : ApplicationParam =
    ApplicationParam.Create (name = "Gtk Application")

let internal setParam (param' : ApplicationParam) =
    param <- param'

type GuiRunner (logging : ILogging) =
    inherit EmptyContext (logging, PlatformKind)
    let application : Application = new Application ()
    do (
        application.Setup ()
    )
    member __.Application = application :> IApplication
    interface IGuiRunner with
        member __.CreateView<'presenter when 'presenter :> IPresenter> (presenter : 'presenter) : IView<'presenter> =
            application.SetPresenter (presenter :> IPresenter)
            new View<'presenter, IApplication> (presenter, application.AsApplication)
            :> IView<'presenter>
        member __.RunGuiLoop () =
            application.Run ()
            0
    interface IFallback
