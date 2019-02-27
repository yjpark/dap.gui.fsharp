[<AutoOpen>]
module Dap.Gtk.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App

let getGtkParam () =
    getGuiParam ()

let setGtkParam (param : GtkParam) =
    setGuiParam param