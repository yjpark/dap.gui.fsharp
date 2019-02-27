[<AutoOpen>]
module Dap.Fabulous.Mac.Helper

open Foundation
open CoreGraphics
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Mac

let getFabulousMacParam () =
    getMacParam ()

let setFabulousMacParam (param' : MacParam) =
    setMacParam param'
