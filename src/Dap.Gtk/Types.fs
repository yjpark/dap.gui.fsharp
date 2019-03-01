[<AutoOpen>]
module Dap.Gtk.Types

open System

open Gtk

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

[<Literal>]
let GtkPlatformKind = "GtkPlatform"

type Widget = Gtk.Widget

type IGtkPlatform =
    inherit IGuiPlatform
    abstract Param : GtkParam with get
    abstract Application : Gtk.Application with get
    abstract Window : Gtk.Window with get

and GtkParam = {
    Name : string
    Title : string
    Width : int
    Height : int
    Flags : GLib.ApplicationFlags
    Actions : (IGtkPlatform -> unit) list
} with
    static member Create (name : string, ?title : string, ?width : int, ?height : int, ?flags : GLib.ApplicationFlags) : GtkParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            Flags = defaultArg flags GLib.ApplicationFlags.None
            Actions = []
        }

