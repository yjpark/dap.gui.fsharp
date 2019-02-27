[<RequireQualifiedAccess>]
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

[<AbstractClass>]
type Context<'appDelegate when 'appDelegate :> NSApplicationDelegate> (logging : ILogging, kind : string) =
    inherit GuiPlatform.Context<MacParam, NSWindow> (logging, kind)
    let mutable appDelegate : 'appDelegate option = None
    let mutable window : NSWindow option = None
    abstract member CreateDelegate : MacParam -> NSWindow -> 'appDelegate
    override this.DoInit (param : MacParam) =
        NSApplication.Init ()
        window <-
            Some (
                new NSWindow (
                    new CoreGraphics.CGRect (0.0, 0.0, param.Width, param.Height),
                    param.WindowStyle, param.BackingStore, false)
            )
        window.Value.Title <- param.Title
        appDelegate <- Some <| this.CreateDelegate param window.Value
        NSApplication.SharedApplication.Delegate <- (appDelegate.Value :> NSApplicationDelegate)
    override this.DoSetup (param : MacParam) (presenter : IPresenter) =
        window.Value.ContentView <- presenter.Prefab0.Widget0 :?> NSView
        window.Value
    override this.DoRun (param : MacParam) =
        param.Actions
        |> List.iter (fun action -> action this)
        NSApplication.Main [| |]
        0
    member this.Window = window.Value
    interface IMacPlatform with
        member this.Param = this.Param
        member this.Window = this.Window
    member this.AsMacPlatform = this :> IMacPlatform

type AppDelegate (param : MacParam, window : NSWindow) =
    inherit NSApplicationDelegate ()
    override this.DidBecomeActive(notification : NSNotification) =
        window.MakeKeyAndOrderFront (this)

type Context (logging : ILogging) =
    inherit Context<AppDelegate> (logging, MacPlatformKind)
    override this.CreateDelegate (param : MacParam) (window : NSWindow) =
        new AppDelegate (param, window)
    interface IFallback