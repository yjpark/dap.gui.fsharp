[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Feature.FabulousIOSPlatform

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous
open Dap.Fabulous.iOS
open Dap.iOS
open Dap.iOS.Feature

[<Register ("FabulousIOSPlatformAppDelegate")>]
type AppDelegate () =
    inherit FormsApplicationDelegate ()
    let platform : IIOSPlatform = IOSPlatform.getInstance ()
    static member Type = "FabulousIOSPlatformAppDelegate"
    override this.FinishedLaunching (application : UIApplication, launchOptions : NSDictionary) =
        Forms.Init ()
        let fabulousParam = getFabulousParam ()
        this.LoadApplication (fabulousParam.Application)
        platform.SetAppDelegate' this
        base.FinishedLaunching (application, launchOptions)

type ViewController = IOSPlatform.ViewController

type Context (logging : ILogging) =
    inherit IOSPlatform.Context<UIApplicationDelegate> (logging, FabulousIOSPlatformKind)
    override this.GetDelegateType () =
        if hasFabulousParam () then
            AppDelegate.Type
        else
            IOSPlatform.AppDelegate.Type
    override this.CreateWindow (appDelegate : UIApplicationDelegate) =
        if hasFabulousParam () then
            let appDelegate = appDelegate :?> AppDelegate
            appDelegate.Window
        else
            IOSPlatform.Context.DoCreateWindow this this.Param
    override this.TryShow () =
        if hasFabulousParam () then
            ()
        else
            IOSPlatform.Context.DoTryShow this this.Param this.Window this.Presenter
    interface IOverride