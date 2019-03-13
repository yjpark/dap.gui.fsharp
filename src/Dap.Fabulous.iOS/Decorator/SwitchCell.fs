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

open Dap.Fabulous.Decorator
open Xamarin.Forms

type Decorator () =
    interface ISwitchCellDecorator with
        member this.SetTextColor (widget : SwitchCell, color : Color) =
            Cell.getRealCell this widget
            |> Option.iter (fun cell ->
                cell.TextLabel.TextColor <- color.ToUIColor ()
            )
