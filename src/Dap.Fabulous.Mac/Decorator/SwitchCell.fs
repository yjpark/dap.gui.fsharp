[<RequireQualifiedAccess>]
module Dap.Fabulous.Mac.Decorator.SwitchCell

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
open Xamarin.Forms

type Decorator () =
    interface ISwitchCellDecorator with
        member this.SetTextColor (widget : SwitchCell, color : Color) =
            () //TODO
            (*
            Cell.getRealCell this widget
            |> Option.iter (fun cell ->
                let cell = cell :?> CellNSView
                cell.TextLabel.TextColor <- color.ToUIColor ()
            )
            *)
