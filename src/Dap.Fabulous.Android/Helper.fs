[<AutoOpen>]
module Dap.Fabulous.Android.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android

let getFabulousAndroidParam () =
    getAndroidParam ()

let setFabulousAndroidParam (param' : AndroidParam) =
    setAndroidParam param'
