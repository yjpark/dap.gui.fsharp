[<RequireQualifiedAccess>]
module Dap.Android.Feature.AndroidPlatform

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Android

(*
[<AbstractClass>]
type Context<'appDelegate when 'appDelegate :> NSApplicationDelegate> (logging : ILogging, kind : string) =
    inherit GuiPlatform.Context<AndroidParam, NSWindow> (logging, kind)
    let mutable appDelegate : 'appDelegate option = None
    let mutable window : NSWindow option = None
    abstract member CreateDelegate : AndroidParam -> NSWindow -> 'appDelegate
    override this.DoInit (param : AndroidParam) =
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
    override this.DoShow (param : AndroidParam, presenter : IPresenter) =
        window.Value.ContentView <- presenter.Prefab0.Widget0 :?> Widget
        window.Value
    override this.DoRun (param : AndroidParam) =
        param.Actions
        |> List.iter (fun action -> action this)
        NSApplication.Main [| |]
        0
    member this.Window = window.Value
    interface IAndroidPlatform with
        member this.Param = this.Param
        member this.Window = this.Window
    member this.AsAndroidPlatform = this :> IAndroidPlatform

type Context (logging : ILogging) =
    inherit Context<AppDelegate> (logging, AndroidPlatformKind)
    override this.CreateDelegate (param : AndroidParam) (window : NSWindow) =
        new AppDelegate (param, window)
    interface IFallback
*)
