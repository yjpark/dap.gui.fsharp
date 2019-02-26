[<AutoOpen>]
module Dap.Mac.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.App
open Dap.Mac.Feature

// Need to call at lease one function in main()
// otherwise the dll might not be included in AppDomain

let initMacPlatform () =
    MacPlatform.Init ()

let getMacParam () =
    getGuiParam () :?> MacParam

let setMacParam (param' : MacParam) =
    setGuiParam param'

let updateMacParam (update : MacParam -> MacParam) =
    getMacParam ()
    |> update
    |> setMacParam
