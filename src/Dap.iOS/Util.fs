[<AutoOpen>]
module Dap.iOS.Util

open Foundation
open UIKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : UIView) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A %A" prefix viewType widget.Frame widget
        for child in widget.Subviews do
            for line in calcLayoutInfo (prefix + "\t") child do
                yield line
    ]

let logWidgetLayout (logger : ILogger) (widget : UIView) =
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip logger "Layout" info

let logLayout (prefab : IPrefab) =
    prefab.Widget0 :?> UIView
    |> logWidgetLayout prefab

