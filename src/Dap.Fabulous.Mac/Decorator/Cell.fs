[<RequireQualifiedAccess>]
module Dap.Fabulous.Mac.Decorator.Cell

open Foundation
open CoreGraphics
open AppKit

open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

// Xamarin.Forms.Platform.MacOS/Cells/CellRenderer.cs

let getRealCell (logger : ILogger) (cell : Cell) =
    Util.getBindableValue<CellRenderer, NSView> logger "s_realCellProperty" cell
    |> Option.bind (fun cell ->
        if cell <> null then
            Some cell
        else
            logError logger "Cell.getRealCell" "RealCell_Is_Null" (cell)
            None
    )
