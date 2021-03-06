[<AutoOpen>]
module Dap.Gui.Internal.Helper

open Dap.Prelude
open Dap.Context
open Dap.Gui

type IButton with
    static member AddChannels (channels : IChannels) =
        channels.AddUnit "on_click"