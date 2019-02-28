[<RequireQualifiedAccess>]
module Dap.Fabulous.Mac.Feature.FabulousMacPlatform

open Foundation
open CoreGraphics
open AppKit

open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous
open Dap.Fabulous.Mac
open Dap.Mac
open Dap.Mac.Feature

type AppDelegate (param : MacParam, window : NSWindow) =
    inherit FormsApplicationDelegate ()
    override this.MainWindow = window
    override this.DidFinishLaunching (notification : NSNotification) =
        let fabulousParam = getFabulousParam ()
        this.LoadApplication (fabulousParam.Application)
        base.DidFinishLaunching (notification)

type Context (logging : ILogging) =
    inherit MacPlatform.Context<NSApplicationDelegate> (logging, FabulousMacPlatformKind)
    override this.CreateDelegate (param : MacParam) (window : NSWindow) =
        if hasFabulousParam () then
            Forms.Init ()
            new AppDelegate (param, window)
            :> NSApplicationDelegate
        else
            new MacPlatform.AppDelegate (param, window)
            :> NSApplicationDelegate
    override this.DoShow (param : MacParam, presenter : IPresenter) =
        if hasFabulousParam () then
            this.Window
        else
            base.DoShow (param, presenter)
    interface IOverride