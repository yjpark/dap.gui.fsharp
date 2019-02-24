[<AutoOpen>]
module Dap.Mac.GuiRunner

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Dap.Mac.Internal

let mutable private param : ApplicationParam =
    ApplicationParam.Create (name = "Dap.Mac", title = "Mac Application")

let internal getParam () =
    param

let internal setParam (param' : ApplicationParam) =
    param <- param'

type GuiRunner (logging : ILogging) =
    inherit EmptyContext (logging, PlatformKind)
    let application : Application = Application.Init (param)
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
