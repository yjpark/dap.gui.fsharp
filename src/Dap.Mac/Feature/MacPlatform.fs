[<AutoOpen>]
module Dap.Mac.Feature.MacPlatform

open Foundation
open CoreGraphics
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Mac

type MacPlatform (logging : ILogging) =
    inherit NSApplicationDelegate ()
    let context = new EmptyContext (logging, "MacPlatform") :> IContext
    let mutable param : MacParam option = None
    let mutable window : NSWindow option = None
    let mutable display : IDisplay option = None
    static member Init () =
        NSApplication.Init ()
    override this.DidBecomeActive(notification : NSNotification) =
        window.Value.MakeKeyAndOrderFront (this)
    member private __.DoSetup (param' : obj, presenter : IPresenter) =
        param <- Some (param' :?> MacParam)
        let window' = new NSWindow (
                        new CoreGraphics.CGRect (0.0, 0.0, param.Value.Width, param.Value.Height),
                        param.Value.WindowStyle, param.Value.BackingStore, false)
        window <- Some window'
        window'.Title <- param.Value.Title
        window'.ContentView <- presenter.Prefab0.Widget0 :?> NSView
    member private this.Run () =
        NSApplication.SharedApplication.Delegate <- this
        param.Value.Actions
        |> List.iter (fun action -> action this)
        NSApplication.Main [| |]
        0
    interface IMacPlatform with
        member __.Param = param.Value
        member __.Window = window.Value
    member this.AsMacPlatform = this :> IMacPlatform
    interface IGuiPlatform with
        member __.Param0 = param :> obj
        member __.Display = display.Value
        member this.Setup param' presenter' =
            if display.IsSome then
                failWith "Already_Setup" (param, display, param', presenter')
            this.DoSetup (param', presenter')
            let display' = new Display<'presenter, NSWindow> (window.Value)
            display'.SetPresenter presenter'
            display <- Some (display' :> IDisplay)
            display' :> IDisplay<'presenter>
        member this.Run () = this.Run ()
    member this.AsGuiPlatform = this :> IGuiPlatform
    interface IContext with
        member __.Dispose () = failWith "MacPlatform" "Can_Not_Dispose"
        member __.Spec0 = context.Spec0
        member __.Properties0 = context.Properties0
        member __.Channels = context.Channels
        member __.Handlers = context.Handlers
        member __.AsyncHandlers = context.AsyncHandlers
        member __.Clone0 l = failWith "MacPlatform" "Can_Not_Clone"
    interface IOwner with
        member __.Luid = ""
        member __.Disposed = false
    interface IJson with
        member __.ToJson () = toJson context
    interface ILogger with
        member __.Log evt = context.Log evt
