[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Feature.Decorator.Page

open System.Reflection

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

type AColor = Android.Graphics.Color
type AToolbar = Android.Support.V7.Widget.Toolbar

// Xamarin.Forms.Platform.Android/Renderers/NavigationPageRenderer.cs

type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, Page.NativeDecoratorKind)
    interface Page.INativeDecorator with
        member this.SetToolbarTextColor (widget : Page) (color : Color) =
            logWip this "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" (widget, color)
            match widget.Parent with
            | :? NavigationPage as navPage ->
                logWip this "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB" (navPage)
                (*
                MenuItem item = menu.getItem(i);
                    SpannableString spanString = new SpannableString(menu.getItem(i).getTitle().toString());
                    spanString.setSpan(new ForegroundColorSpan(Color.BLACK), 0,     spanString.length(), 0); //fix the color to white
                    item.setTitle(spanString);
                *)
            | _ ->
                logError this "SetToolbarTextColor" "Unsupported_Parent" (widget, widget.Parent)
            () //TODO
