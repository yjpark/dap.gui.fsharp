[<AutoOpen>]
module Dap.Yoga.Helper

open System.Runtime.InteropServices
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Gui

let undefined = YogaValue.Undefined ()

let point (v : float32) = YogaValue.Point v

let percent (v : float32) = YogaValue.Percent v

let auto = YogaValue.Auto ()

let yoga = new Updater.Builder ()

let rec calcLayoutInfo (prefix : string) (yoga : YogaNode) : string list =
    [
        yield sprintf "%s%A [%d] {%A, %A, %A, %A]}" prefix yoga.Data yoga.Count yoga.LayoutX yoga.LayoutY yoga.LayoutWidth yoga.LayoutHeight
        for sub in yoga do
            for line in calcLayoutInfo (prefix + "\t") sub do
                yield line
    ]

let logYoga (prefab : IPrefab) =
    prefab.TryGetYogaNode ()
    |> Option.iter (fun yoga ->
        let info =
            "" :: calcLayoutInfo "" yoga
            |> String.concat "\n"
        logWip prefab "Yoga" info
    )
