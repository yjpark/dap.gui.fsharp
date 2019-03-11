[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Feature.Decorator.NavigationPage

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Dap.Fabulous.iOS

// Xamarin.Forms.Platform.iOS/Renderers/NavigationRenderer.cs


type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.NativeDecoratorKind)
    interface NavigationPage.INativeDecorator with
        member this.SetBarActionColor (widget : NavigationPage) (color : Color) =
            let renderer = widget.GetRenderer<NavigationRenderer> ()
            renderer.NavigationBar.TintColor <- color.ToUIColor ()
        member this.UpdateBarStyle (widget : NavigationPage) =
            let renderer = widget.GetRenderer<NavigationRenderer> ()
            let barStyle =
                if widget.BarTextColor.Luminosity <= 0.5 then
                    UIBarStyle.Default
                else
                    UIBarStyle.Black
            renderer.NavigationBar.BarStyle <- barStyle


