[<AutoOpen>]
module Dap.Mac.Helper

open Foundation
open CoreGraphics
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.App
open Dap.Mac.Feature

let getMacParam () =
    getGuiParam () :?> MacParam

let setMacParam (param' : MacParam) =
    setGuiParam param'
    NSApplication.Init ()
