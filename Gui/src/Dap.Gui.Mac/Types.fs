[<AutoOpen>]
module Dap.Gui.Mac.Types

open System

open Foundation
open AppKit

open Dap.Prelude
open Dap.Gui

type IApplication =
    inherit IDisposable
    inherit ILogger
    abstract Param : ApplicationParam with get
    abstract Window : NSWindow with get
    abstract Presenter : IPresenter with get

and ApplicationParam = {
    Name : string
    Title : string
    Width : float
    Height : float
    WindowStyle : NSWindowStyle
    BackingStore : NSBackingStore
    Initializers : (IApplication -> unit) list
} with
    static member Create
            (name : string, ?title : string, ?width : float, ?height : float,
                ?windowStyle : NSWindowStyle, ?backingStore : NSBackingStore) : ApplicationParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280.0
            Height = defaultArg height 720.0
            WindowStyle = defaultArg windowStyle
                (NSWindowStyle.Resizable ||| NSWindowStyle.Closable ||| NSWindowStyle.Miniaturizable ||| NSWindowStyle.Titled)
            BackingStore = defaultArg backingStore NSBackingStore.Buffered
            Initializers = []
        }

