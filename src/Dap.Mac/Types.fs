[<AutoOpen>]
module Dap.Mac.Types

open System

open Foundation
open AppKit

open Dap.Prelude
open Dap.Gui.App

type Color = NSColor
type Widget = NSView

type IMacPlatform =
    inherit IGuiPlatform
    abstract Param : MacParam with get
    abstract Window : NSWindow with get

and MacParam = {
    Name : string
    Title : string
    Width : float
    Height : float
    WindowStyle : NSWindowStyle
    BackingStore : NSBackingStore
    Actions : (IMacPlatform -> unit) list
} with
    static member Create
            (name : string, ?title : string, ?width : float, ?height : float,
                ?windowStyle : NSWindowStyle, ?backingStore : NSBackingStore) : MacParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280.0
            Height = defaultArg height 720.0
            WindowStyle = defaultArg windowStyle
                (NSWindowStyle.Resizable ||| NSWindowStyle.Closable ||| NSWindowStyle.Miniaturizable ||| NSWindowStyle.Titled)
            BackingStore = defaultArg backingStore NSBackingStore.Buffered
            Actions = []
        }

