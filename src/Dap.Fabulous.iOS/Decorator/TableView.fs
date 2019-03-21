[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Decorator.TableView

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
    let logger = (getLogging ()) .GetLogger ("TableView.Decorator")
    interface ITableViewDecorator with
        member this.SetSeparatorColor (widget : TableView, color : Color) =
            let renderer = widget.GetRenderer<TableViewRenderer> ()
            renderer.Control.SeparatorColor <- color.ToUIColor ()
