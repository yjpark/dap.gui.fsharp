[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Decorator.Entry

open System

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Controls
open Dap.Fabulous.Decorator
open Dap.Fabulous.iOS

type Decorator () =
    let logger = (getLogging ()) .GetLogger ("Entry.Decorator")
    interface IEntryDecorator with
        member this.SetTextBorderColor (widget : Entry, color : Color) =
            let renderer = widget.GetRenderer<EntryRenderer> ()
            // https://stackoverflow.com/questions/1861527/uitextfield-border-color
            let layer = renderer.Control.Layer
            layer.CornerRadius <- nfloat (2.0f)
            layer.MasksToBounds <- true
            layer.BorderWidth <- nfloat (0.5f)
            layer.BorderColor <- color.ToCGColor ()
        member this.SetTextBackgroundColor (widget : Entry, color : Color) =
            let renderer = widget.GetRenderer<EntryRenderer> ()
            renderer.Control.BackgroundColor <- color.ToUIColor ()
