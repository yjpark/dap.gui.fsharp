[<AutoOpen>]
module Dap.UWP.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App

let getUWPParam () =
    getGuiParam ()

let setUWPParam (param : UWPParam) =
    setGuiParam param