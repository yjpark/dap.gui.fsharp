[<AutoOpen>]
module Dap.Android.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.App
open Dap.Android.Feature

let getAndroidParam () =
    getGuiParam () :?> AndroidParam

let setAndroidParam (param' : AndroidParam) =
    setGuiParam param'
