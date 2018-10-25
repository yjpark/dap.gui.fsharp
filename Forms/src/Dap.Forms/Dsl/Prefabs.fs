module Dap.Forms.Dsl.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Context.Generator
open Dap.Platform
open Dap.Gui
open Dap.Gui.Builder
open Dap.Gui.Dsl.Prefab

open Dap.Forms.Builder
open Dap.Forms.Generator

let compile segments =
    [
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "InputField.fs"],
            "Dap.Forms.Prefab.InputField", <@ InputField @>
        )
    ]
