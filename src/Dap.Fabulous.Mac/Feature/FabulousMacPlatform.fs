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

[<Literal>]
let FabulousMacPlatformKind = "FabulousMacPlatform"

type AppDelegate (param : MacParam, window : NSWindow) =
    inherit FormsApplicationDelegate ()
    override this.MainWindow = window
    override this.DidFinishLaunching (notification : NSNotification) =
        let fabulousParam = getFabulousParam ()
        this.LoadApplication (fabulousParam.Application)
        base.DidFinishLaunching (notification)

type Context (logging : ILogging) =
    inherit MacPlatform.Context<AppDelegate> (logging, FabulousMacPlatformKind)
    override this.CreateDelegate (param : MacParam) (window : NSWindow) =
        Forms.Init ()
        new AppDelegate (param, window)
    override this.DoSetup (param : MacParam) (presenter : IPresenter) =
        this.Window
    interface IOverride