[<AutoOpen>]
module Dap.Gui.Yoga.Helper

open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Gui

let undefined = YogaValue.Undefined ()

let point (v : float32) = YogaValue.Point v

let percent (v : float32) = YogaValue.Percent v

let auto = YogaValue.Auto ()

let node () = new Node.Builder ()

let yoga (kind : string) (createNode : unit -> YogaNode) =
    Styles.register<YogaStyle, IPrefab> kind [ createNode :> obj ]