[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Decorator.SwitchCell

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Controls
open Dap.Fabulous.Decorator
open Dap.Fabulous.Android

// Xamarin.Forms.Platform.Android/Cells/SwitchCellRenderer.cs

let getSwitchCellView (logger : ILogger) (cell : SwitchCell) : SwitchCellView option =
    Cell.getRenderer<SwitchCellRenderer> logger cell
    |> Option.bind (fun renderer ->
        Util.getInstanceValue<SwitchCellRenderer, SwitchCellView> logger "_view" renderer
    )

type Decorator () =
    let logger = (getLogging ()) .GetLogger "SwitchCellDecorator"
    interface ISwitchCellDecorator with
        member this.SetTextColor (widget : SwitchCell, color : Color) =
            getSwitchCellView logger widget
            |> Option.iter (fun view ->
                if view =? null then
                    logError logger "SetTextColor" "SwitchCellView_Not_Found" (widget, color)
                else
                    view.SetMainTextColor (color)
            )
