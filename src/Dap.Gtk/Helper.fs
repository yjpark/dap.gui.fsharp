[<AutoOpen>]
module Dap.Gtk.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

// Need to call at lease one function in main()
// otherwise the dll might not be included in AppDomain

let getGtkParam () =
    getParam ()

let setGtkParam (param' : ApplicationParam) =
    setParam param'

let updateGtkParam (update : ApplicationParam -> ApplicationParam) =
    getParam ()
    |> update
    |> setParam