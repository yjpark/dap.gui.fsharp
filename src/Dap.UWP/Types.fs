[<AutoOpen>]
module Dap.UWP.Types

open System

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

type UWPParam = {
    Name : string
    Title : string
    Width : int
    Height : int
    //Actions : (IUWPPlatform -> unit) list
} with
    static member Create (name : string, ?title : string, ?width : int, ?height : int) : UWPParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            //Actions = []
        }

