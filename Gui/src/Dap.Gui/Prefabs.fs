[<AutoOpen>]
module Dap.Gui.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Platform

type ILabel =
    inherit IPrefab<LabelProps>

type IButton =
    inherit IPrefab<ButtonProps>
    abstract OnClick : IChannel<unit> with get

type ITextField =
    inherit IPrefab<TextFieldProps>
