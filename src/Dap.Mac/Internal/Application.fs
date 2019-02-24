[<AutoOpen>]
module Dap.Mac.Internal.AppDelegate

open Foundation
open CoreGraphics
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Mac

type Application (param : ApplicationParam) =
    inherit NSApplicationDelegate ()
    let logger : ILogger = getLogger param.Name
    let window = new NSWindow (new CoreGraphics.CGRect (0.0, 0.0, param.Width, param.Height),
                    param.WindowStyle, NSBackingStore.Buffered, false)
    do (
        window.Title <- param.Title
    )
    let mutable presenter : IPresenter option = None
    static member Init p =
        NSApplication.Init ()
        let app = new Application (p)
        setupGuiContext' app
        app.Setup ()
        app
    member private this.Setup () =
        ()
    member __.SetPresenter (presenter' : IPresenter) =
        presenter <- Some presenter'
        window.ContentView <- presenter'.Prefab0.Widget0 :?> NSView
    member this.Run () =
        NSApplication.SharedApplication.Delegate <- this
        NSApplication.Main [| |]
    override this.DidBecomeActive(notification : NSNotification) =
        window.MakeKeyAndOrderFront (this)
    interface IApplication with
        member __.Param = param
        member __.Window = window
        member __.Presenter = presenter.Value
    member this.AsApplication = this :> IApplication
    interface ILogger with
        member __.Log evt = logger.Log evt
