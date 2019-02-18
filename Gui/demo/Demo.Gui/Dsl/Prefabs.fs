module Demo.Gui.Dsl.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Context.Generator
open Dap.Platform
open Dap.Gui
open Dap.Gui.Builder
open Dap.Gui.Generator

let Contact =
    h_stack {
        child "name" (
            label {
                text "..."
            }
        )
        child "phone" (
            label {
                text "..."
            }
        )
    }

let Contacts =
    f_table {
        item <@ Contact @>
    }

let HomePanel =
    h_stack {
        child "contacts" <@ Contacts @>
    }

let compile segments =
    [
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Contact.fs"],
            "Demo.Gui.Prefab.Clip", <@ Contact @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "Contacts.fs"],
            "Demo.Gui.Prefab.Clips", <@ Contacts @>
        )
        G.PrefabFile (segments, ["_Gen" ; "Prefab" ; "HomePanel.fs"],
            "Demo.Gui.Prefab.HomePanel", <@ HomePanel @>
        )
    ]


