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
    override this.DidBecomeActive(notification : NSNotification) =
        window.Value.MakeKeyAndOrderFront (this)
    member private __.DoInit (param' : obj) =
        param <- Some (param' :?> MacParam)
    member private __.DoSetup (presenter : IPresenter) =
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
    //SILP: GUI_PLATFORM_FOOTER(MacPlatform, NSWindow, window.Value)
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
            let display' = new Display<'presenter, NSWindow> (window.Value)  //__SILP__
            display'.SetPresenter presenter'                                 //__SILP__
            display <- Some (display' :> IDisplay)                           //__SILP__
            display' :> IDisplay<'presenter>                                 //__SILP__
        member this.Run () = this.Run ()                                     //__SILP__
    member this.AsGuiPlatform = this :> IGuiPlatform                         //__SILP__
    interface IContext with                                                  //__SILP__
        member __.Dispose () = failWith "MacPlatform" "Can_Not_Dispose"      //__SILP__
        member __.Spec0 = context.Spec0                                      //__SILP__
        member __.Properties0 = context.Properties0                          //__SILP__
        member __.Channels = context.Channels                                //__SILP__
        member __.Handlers = context.Handlers                                //__SILP__
        member __.AsyncHandlers = context.AsyncHandlers                      //__SILP__
        member __.Clone0 l = failWith "MacPlatform" "Can_Not_Clone"          //__SILP__
    interface IOwner with                                                    //__SILP__
        member __.Luid = ""                                                  //__SILP__
        member __.Disposed = false                                           //__SILP__
    interface IJson with                                                     //__SILP__
        member __.ToJson () = toJson context                                 //__SILP__
    interface ILogger with                                                   //__SILP__
        member __.Log evt = context.Log evt                                  //__SILP__
