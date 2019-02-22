[<AutoOpen>]
module Dap.Gui.Myra.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

// Need to call at lease one function in main()
// otherwise the dll might not be included in AppDomain

let getMyraParam () =
    getParam ()

let setMyraParam (param' : ApplicationParam) =
    setParam param'

let updateMyraParam (update : ApplicationParam -> ApplicationParam) =
    getParam ()
    |> update
    |> setParam
