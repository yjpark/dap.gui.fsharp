[<AutoOpen>]
module Dap.Fabulous.Ooui.Types

open System

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

type IOouiPlatform =
    inherit IGuiPlatform
    abstract Param : OouiParam with get

and OouiParam = {
    Name : string
    Title : string
    Port : int
    Actions : (IOouiPlatform -> unit) list
} with
    static member Create (name : string, ?title : string, ?port : int) : OouiParam =
        {
            Name = name
            Title = defaultArg title name
            Port = defaultArg port 8080
            Actions = []
        }
