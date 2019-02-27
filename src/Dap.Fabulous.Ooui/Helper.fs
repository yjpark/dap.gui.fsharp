[<AutoOpen>]
module Dap.Fabulous.Ooui.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App

let getFabulousOouiParam () =
    getGuiParam ()

let setFabulousOouiParam (param : OouiParam) =
    setGuiParam param