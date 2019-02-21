[<AutoOpen>]
module Dap.Gui.Yoga.Helper

open System.Runtime.InteropServices
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Gui

let undefined = YogaValue.Undefined ()

let point (v : float32) = YogaValue.Point v

let percent (v : float32) = YogaValue.Percent v

let auto = YogaValue.Auto ()

let node = new Node.Builder ()

let yoga (kind : string) (createNode : unit -> YogaNode) =
    Styles.register<YogaStyle, IPrefab> kind [ createNode :> obj ]

let rec calcLayoutInfo (prefix : string) (yoga : YogaNode) : string list =
    [
        yield sprintf "%s%A [%d] {%A, %A, %A, %A]}" prefix yoga.Data yoga.Count yoga.LayoutX yoga.LayoutY yoga.LayoutWidth yoga.LayoutHeight
        for sub in yoga do
            for line in calcLayoutInfo (prefix + "\t") sub do
                yield line
    ]

let logYoga (prefab : IPrefab) =
    prefab.TryFindStyle<IYogaStyle> ()
    |> Option.iter (fun yoga ->
        let info =
            "" :: calcLayoutInfo "" yoga.Node
            |> String.concat "\n"
        logWip prefab "Yoga" info
    )

//TODO: after got yoga supported on all platform, this can be removed
let registerYoga (register : unit -> unit) =
    fun () ->
        if RuntimeInformation.IsOSPlatform (OSPlatform.OSX) then
            register ()
        else
            ()
