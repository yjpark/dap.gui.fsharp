[<AutoOpen>]
module Dap.Gui.Myra.Util

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : MyraWidget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        match widget with
        | :? MyraPanel as panel ->
            yield sprintf "%s%s [%d] %A" prefix viewType panel.Widgets.Count widget.Bounds
            for sub in panel.Widgets do
                for line in calcLayoutInfo (prefix + "\t") sub do
                    yield line
        | _ ->
            yield sprintf "%s%s [0] %A" prefix viewType widget.Bounds
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> MyraWidget
    let info =
        "" :: calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip prefab "Layout" info
