[<AutoOpen>]
module Dap.Mac.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

// Need to call at lease one function in main()
// otherwise the dll might not be included in AppDomain

let getMacParam () =
    getParam ()

let setMacParam (param' : ApplicationParam) =
    setParam param'

let updateMacParam (update : ApplicationParam -> ApplicationParam) =
    getParam ()
    |> update
    |> setParam
