[<AutoOpen>]
module Dap.Gtk.Util

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : Gtk.Widget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType widget
        match widget with
        | :? Gtk.Container as container ->
            for child in container.Children do
                for line in calcLayoutInfo (prefix + "\t") child do
                    yield line
        | _ -> ()
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> Gtk.Widget
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip prefab "Layout" info
