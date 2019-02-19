module Dap.Gui.Gtk.Internal.Application

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui.Gtk
open GLib

type Application (param : ApplicationParam) =
    inherit Gtk.Application (param.Name, param.Flags)
    let logger : ILogger = getLogger param.Name
    member this.Setup () =
        this.Register (GLib.Cancellable.Current)