[<AutoOpen>]
module Dap.Gui.Gtk.Util

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : GtkWidget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType widget
        match widget with
        | :? GtkPanel as panel ->
            for sub in panel.Children do
                for line in calcLayoutInfo (prefix + "\t") sub do
                    yield line
        | _ -> ()
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> GtkWidget
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip prefab "Layout" info
