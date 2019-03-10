[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Feature.Decorator.Page

open System
open System.Reflection

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, Page.NativeDecoratorKind)
    interface Page.INativeDecorator with
        member this.SetToolbarTextColor (widget : Page) (color : Color) =
            logWip this "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" (widget, color)
            match widget.Parent with
            | :? NavigationPage as navPage ->
                let statusBarColorMode = navPage.OnThisPlatform() .GetStatusBarTextColorMode ()
                logWip this "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB" (navPage, statusBarColorMode, UIApplication.SharedApplication.StatusBarStyle)
            | _ ->
                logError this "SetToolbarTextColor" "Unsupported_Parent" (widget, widget.Parent)
            () //TODO
