[<AutoOpen>]
module Dap.Gui.Gtk.Types

open System

open Gtk

open Dap.Prelude
open Dap.Gui

type GtkWidget = Gtk.Widget
type GtkPanel = Gtk.VBox

type IApplication =
    inherit IDisposable
    inherit ILogger
    abstract Presenter : IPresenter with get
    abstract Width : int with get
    abstract Height : int with get
    abstract Quitting : bool with get

and ApplicationParam = {
    Name : string
    Width : int
    Height : int
    Flags : GLib.ApplicationFlags
    Initializers : (IApplication -> unit) list
} with
    static member Create (name : string, ?width : int, ?height : int, ?flags : GLib.ApplicationFlags) : ApplicationParam =
        {
            Name = name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            Flags = defaultArg flags GLib.ApplicationFlags.None
            Initializers = []
        }

