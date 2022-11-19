[<AutoOpen>]
module Dap.iOS.Helper

open Foundation
open CoreGraphics
open UIKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.App
open Dap.iOS.Feature

let getIOSParam () =
    getGuiParam () :?> IOSParam

let setIOSParam (param' : IOSParam) =
    setGuiParam param'
