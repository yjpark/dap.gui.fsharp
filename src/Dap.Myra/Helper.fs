[<AutoOpen>]
module Dap.Myra.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App
open Dap.Myra.Feature

let getMyraParam () =
    getGuiParam () :?> MyraParam

let setMyraParam (param' : MyraParam) =
    setGuiParam param'