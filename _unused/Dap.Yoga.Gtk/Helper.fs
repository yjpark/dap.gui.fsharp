[<AutoOpen>]
module Dap.Yoga.Gtk.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

// Need to call at lease one function in main()
// otherwise the dll might not be included in AppDomain

let initYogaGtk () =
    ()
