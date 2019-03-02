[<RequireQualifiedAccess>]
module Dap.iOS.Feature.IOSPlatform

open System
open Foundation
open CoreGraphics
open UIKit

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.iOS

let mutable private instance : IIOSPlatform option = None

let getInstance () =
    instance.Value

let onUnhandledException (logger : ILogger) (args : UnhandledExceptionEventArgs) =
    logError logger "CurrentDomain" "OnUnhandledException" args

[<AbstractClass>]
type Context<'appDelegate when 'appDelegate :> UIApplicationDelegate> (logging : ILogging, kind : string) =
    inherit GuiPlatform.Context<IOSParam, UIWindow option> (logging, kind)
    let mutable window : UIWindow option = None
    let mutable presenter : IPresenter option = None
    let mutable appDelegate : 'appDelegate option = None
    abstract member GetDelegateType : unit -> string
    abstract member CreateWindow : 'appDelegate -> UIWindow
    abstract member TryShow : unit -> unit
    override this.DoInit (param : IOSParam) =
        instance <- Some (this :> IIOSPlatform)
        //AppDomain.CurrentDomain.UnhandledException.Add <| onUnhandledException this
        //UIApplication.Init ()
    override this.DoShow (param : IOSParam, presenter' : IPresenter) =
        presenter <- Some presenter'
        this.TryShow ()
        window
    override this.DoRun (param : IOSParam) =
        param.Actions
        |> List.iter (fun action -> action this)
        UIApplication.Main ([| |], null, this.GetDelegateType ())
        0
    member this.Window = window
    member this.Presenter = presenter
    member this.AppDelegate = appDelegate.Value
    member this.SetAppDelegate' (delegate' : UIApplicationDelegate) =
        let delegate' = delegate' :?> 'appDelegate
        appDelegate <- Some delegate'
        window <- Some <| this.CreateWindow (delegate')
        this.TryShow ()
    interface IIOSPlatform with
        member this.Param = this.Param
        member this.Window = this.Window
        member this.Presenter = this.Presenter
        member this.AppDelegate = this.AppDelegate :> UIApplicationDelegate
        member this.SetAppDelegate' d = this.SetAppDelegate' d
    member this.AsIOSPlatform = this :> IIOSPlatform

type ViewController (param : IOSParam) =
    inherit UIViewController ()
    do (
        if base.RespondsToSelector (Selector.automaticallyAdjustsScrollViewInsets) then
            base.AutomaticallyAdjustsScrollViewInsets <- true
        if base.RespondsToSelector (Selector.extendedLayoutIncludesOpaqueBars) then
            base.ExtendedLayoutIncludesOpaqueBars <- true
        let view = base.View
        view.AutosizesSubviews <- true
        view.AutoresizingMask <- UIViewAutoresizing.FlexibleDimensions
        view.BackgroundColor <- Color.White
    )
    //TODO: Add to IOSParam
    override this.GetSupportedInterfaceOrientations () : UIInterfaceOrientationMask =
        UIInterfaceOrientationMask.All
    override this.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation : UIInterfaceOrientation) =
        true

[<Register ("IOSPlatformAppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()
    let platform : IIOSPlatform = getInstance ()
    static member Type = "IOSPlatformAppDelegate"
    override this.Window =
        platform.Window.Value
    override this.FinishedLaunching (application : UIApplication, launchOptions : NSDictionary) =
        platform.SetAppDelegate' this
        true
    override this.OnActivated (application : UIApplication) =
        let window = platform.Window.Value
        window.MakeKeyAndVisible ()
        window.BecomeFirstResponder () |> ignore

type Context (logging : ILogging) =
    inherit Context<AppDelegate> (logging, IOSPlatformKind)
    static member DoCreateWindow (logger : ILogger) (param : IOSParam) =
        //Create Window
        let window = new UIWindow (UIScreen.MainScreen.Bounds)
        window.AutosizesSubviews <- true
        window.RootViewController <- new ViewController (param)
        window
    static member DoTryShow (logger : ILogger) (param : IOSParam) (window : UIWindow option) (presenter : IPresenter option) =
        match (window, presenter) with
        | (Some window, Some presenter) ->
            //Add Widget
            let widget = presenter.Prefab0.Widget0 :?> Widget
            window.RootViewController.View.AddSubview widget
            logWidgetLayout logger window
            widget.Frame <- window.RootViewController.View.Frame
            widget.SetNeedsLayout ()
            widget.LayoutIfNeeded ()
            logWidgetLayout logger window.RootViewController.View
        | _ -> ()
    override this.GetDelegateType () = AppDelegate.Type
    override this.CreateWindow (appDelegate : AppDelegate) =
        Context.DoCreateWindow this this.Param
    override this.TryShow () =
        Context.DoTryShow this this.Param this.Window this.Presenter
    interface IFallback