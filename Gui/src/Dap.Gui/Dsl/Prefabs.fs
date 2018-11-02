[<AutoOpen>]
module Dap.Gui.Dsl.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Context.Generator
open Dap.Platform
open Dap.Gui
open Dap.Gui.Builder
open Dap.Gui.Generator

let inputField labelText =
    h_stack {
        prefab "input_field"
        styles ["style3"]
        child "label" (
            label {
                text labelText
            }
        )
        child "value" (
            text_field {
                text ""
            }
        )
    }

let InputField = inputField "Label"

let compile segments =
    [
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "InputField.fs"],
            "Dap.Gui.Prefab.InputField", <@ InputField @>
        )
    ]

