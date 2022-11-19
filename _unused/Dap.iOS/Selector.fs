[<RequireQualifiedAccess>]
module Dap.iOS.Selector

open ObjCRuntime
open Foundation
open UIKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let automaticallyAdjustsScrollViewInsets = new Selector ("automaticallyAdjustsScrollViewInsets")
let extendedLayoutIncludesOpaqueBars = new Selector ("extendedLayoutIncludesOpaqueBars")