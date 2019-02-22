[<AutoOpen>]
module Dap.Gui.Mac.Util

open Foundation
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : NSView) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType widget
        for child in widget.Subviews do
            for line in calcLayoutInfo (prefix + "\t") child do
                yield line
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> NSView
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip prefab "Layout" info
