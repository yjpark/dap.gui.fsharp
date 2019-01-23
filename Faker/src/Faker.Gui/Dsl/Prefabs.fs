module Faker.Gui.Dsl.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Context.Generator
open Dap.Platform
open Dap.Gui
open Dap.Gui.Builder
open Dap.Gui.Generator
open Dap.Gui.Prefab.Dsl

let Action =
    h_stack {
        child "exec" (
            button {
                text "Exec"
            }
        )
        child "execSingle" (
            button {
                text "Single"
            }
        )
    }

let Actions =
    f_table {
        item <@ Action @>
    }

let Project =
    v_stack {
        child "name" (
            label {
                text "..."
            }
        )
        child "actions" <@ Actions @>
    }

let Projects =
    f_table {
        item <@ Project @>
    }

let HomePanel =
    h_stack {
        child "projects" <@ Projects @>
    }

let compile segments =
    [
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Action.fs"],
            "Faker.Gui.Prefab.Action", <@ Action @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Actions.fs"],
            "Faker.Gui.Prefab.Actions", <@ Actions @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Project.fs"],
            "Faker.Gui.Prefab.Clip", <@ Project @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Projects.fs"],
            "Faker.Gui.Prefab.Clips", <@ Projects @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "HomePanel.fs"],
            "Faker.Gui.Prefab.HomePanel", <@ HomePanel @>
        )
    ]


