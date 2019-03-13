[<RequireQualifiedAccess>]
module Dap.Fabulous.Mac.Decorator.NavigationPage

open Foundation
open CoreGraphics
open AppKit

open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Controls
open Dap.Fabulous.Decorator
open Dap.Fabulous.Mac

// Xamarin.Forms.Platform.MacOS/Renderers/NavigationRenderer.cs


type Decorator () =
    interface INavigationPageDecorator with
        member this.SetBarActionColor (widget : NavigationPage, color : Color) =
            () //TODO
            (*
            let renderer = widget.GetRenderer<NavigationRenderer> ()
            renderer.NavigationBar.TintColor <- color.ToUIColor ()
            *)
        member this.UpdateBarStyle (widget : NavigationPage) =
            () //TODO
            (*
            let renderer = widget.GetRenderer<NavigationRenderer> ()
            let barStyle =
                if widget.BarTextColor.Luminosity <= 0.5 then
                    UIBarStyle.Default
                else
                    UIBarStyle.Black
            renderer.NavigationBar.BarStyle <- barStyle
            *)


