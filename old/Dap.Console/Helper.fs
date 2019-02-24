[<AutoOpen>]
module Dap.Console.Helper

open Terminal.Gui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (view : View) : string list =
    let viewType = (view.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType view.Frame
        for sub in view.Subviews do
            for line in calcLayoutInfo (prefix + "\t") sub do
                yield line
    ]

let logLayout (prefab : IPrefab) =
    let view = prefab.Widget0 :?> View
    let info =
        calcLayoutInfo "" view
        |> String.concat "\n"
    logWip prefab "Layout" info
