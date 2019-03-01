[<AutoOpen>]
module Dap.iOS.Types

open System

open Foundation
open UIKit

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

[<Literal>]
let IOSPlatformKind = "IOSPlatform"

type Color = UIColor
type Widget = UIView

type IIOSPlatform =
    inherit IGuiPlatform
    abstract Param : IOSParam with get
    abstract Window : UIWindow option with get
    abstract Presenter : IPresenter option with get
    abstract AppDelegate : UIApplicationDelegate with get
    abstract SetAppDelegate' : UIApplicationDelegate -> unit

and IOSParam = {
    Name : string
    Title : string
    Actions : (IIOSPlatform -> unit) list
} with
    static member Create
            (name : string, ?title : string) : IOSParam =
        {
            Name = name
            Title = defaultArg title name
            Actions = []
        }

