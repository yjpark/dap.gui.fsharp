[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Feature.Decorator.SwitchCell

open System
open System.Reflection

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.NativeDecoratorKind)
    interface SwitchCell.INativeDecorator with
        member this.SetTextColor (widget : SwitchCell) (textColor : Color) =
            Cell.getRealCell this widget
            |> Option.iter (fun cell ->
                cell.TextLabel.TextColor <- textColor.ToUIColor ()
            )
