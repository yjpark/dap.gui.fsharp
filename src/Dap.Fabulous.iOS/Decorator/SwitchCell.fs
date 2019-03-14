[<RequireQualifiedAccess>]
module Dap.Fabulous.iOS.Decorator.SwitchCell

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
open Xamarin.Forms

type Decorator () =
    let logger = (getLogging ()) .GetLogger ("SwitchCell.Decorator")
    interface ISwitchCellDecorator with
        member this.SetTextColor (widget : SwitchCell, color : Color) =
            Cell.getRealCell logger widget
            |> Option.iter (fun cell ->
                cell.TextLabel.TextColor <- color.ToUIColor ()
            )
