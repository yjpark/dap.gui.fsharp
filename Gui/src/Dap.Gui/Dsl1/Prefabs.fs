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

let InputField =
    h_stack {
        styles ["style3"]
        child "label" (
            label {
                text "Label"
            }
        )
        child "value" (
            text_field {
                text ""
            }
        )
    }

let compile segments =
    [
        G.PrefabFile (segments, ["_Gen1" ; "Prefab" ; "InputField.fs"],
            "Dap.Gui.Prefab.InputField", <@ InputField @>
        )
        G.File (segments, ["_Gen1" ; "Builder" ; "Prefabs.fs"],
            G.BuilderModule ("Dap.Gui.Builder.Prefabs",
                [
                    [
                        "open Dap.Gui"
                    ]
                    G.PrefabBuilder (<@ InputField @>)
                ]
            )
        )
    ]
