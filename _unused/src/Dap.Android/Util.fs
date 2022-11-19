[<AutoOpen>]
module Dap.Android.Util

open Android.Graphics

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : Widget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        let mutable rect = new Rect (widget.Left, widget.Top, widget.Width, widget.Height)
        yield sprintf "%s%s %A %A" prefix viewType rect widget
        match widget with
        | :? Android.Views.ViewGroup as group ->
            for i in [0 .. group.ChildCount - 1] do
                let child = group.GetChildAt i
                for line in calcLayoutInfo (prefix + "\t") child do
                    yield line
        | _ -> ()
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> Widget
    let info =
        "" :: calcLayoutInfo "\t" widget
        |> String.concat "\n"
    logWip prefab "Layout" info
