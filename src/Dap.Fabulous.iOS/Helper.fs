[<AutoOpen>]
module Dap.Fabulous.iOS.Helper

open Foundation
open CoreGraphics
open UIKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.iOS

let getFabulousIOSParam () =
    getIOSParam ()

let setFabulousIOSParam (param' : IOSParam) =
    setIOSParam param'
