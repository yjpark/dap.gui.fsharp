[<AutoOpen>]
module Dap.Gui.Myra.Util

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : MyraWidget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType widget.Bounds
        match widget with
        | :? MyraPanel as panel ->
            for sub in panel.Widgets do
                for line in calcLayoutInfo (prefix + "\t") sub do
                    yield line
        | _ -> ()
    ]

let logLayout (logger : ILogger) (widget : MyraWidget) =
    //let widget = prefab.Widget0 :?> MyraWidget
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip logger "Layout" info
