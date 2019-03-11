[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Feature.Decorator.SwitchCell

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

// Xamarin.Forms.Platform.Android/Cells/SwitchCellRenderer.cs

let getSwitchCellView (logger : ILogger) (cell : SwitchCell) : SwitchCellView option =
    Cell.getRenderer<SwitchCellRenderer> logger cell
    |> Option.bind (fun renderer ->
        Util.getInstanceValue<SwitchCellRenderer, SwitchCellView> logger "_view" renderer
    )

type Decorator (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.NativeDecoratorKind)
    interface SwitchCell.INativeDecorator with
        member this.SetTextColor (widget : SwitchCell) (color : Color) =
            getSwitchCellView this widget
            |> Option.iter (fun view ->
                if view =? null then
                    logError this "SetTextColor" "SwitchCellView_Not_Found" (widget, color)
                else
                    view.SetMainTextColor (color)
            )
