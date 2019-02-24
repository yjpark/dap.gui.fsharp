[<AutoOpen>]
module Dap.Gtk.Types

open System

open Gtk

open Dap.Prelude
open Dap.Gui

type IApplication =
    inherit IDisposable
    inherit ILogger
    abstract Param : ApplicationParam with get
    abstract Window : Gtk.Window with get
    abstract Presenter : IPresenter with get

and ApplicationParam = {
    Name : string
    Title : string
    Width : int
    Height : int
    Flags : GLib.ApplicationFlags
    Initializers : (IApplication -> unit) list
} with
    static member Create (name : string, ?title : string, ?width : int, ?height : int, ?flags : GLib.ApplicationFlags) : ApplicationParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            Flags = defaultArg flags GLib.ApplicationFlags.None
            Initializers = []
        }

