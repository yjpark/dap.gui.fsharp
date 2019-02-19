module Demo.Gui.Dsl.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Context.Generator
open Dap.Platform
open Dap.Gui
open Dap.Gui.Builder
open Dap.Gui.Generator
open Demo.Gui.StyleConst

let Contact =
    h_stack {
        child "name" (
            label {
                text "..."
                styles [ Yoga_Leaf ]
            }
        )
        child "phone" (
            label {
                text "..."
                styles [ Yoga_Leaf ]
            }
        )
        styles [ Yoga_Contact ]
    }

let Contacts =
    f_table {
        item <@ Contact @>
        styles [ Yoga_Contacts ]
    }

let HomePanel =
    v_stack {
        child "contacts" <@ Contacts @>
        styles [ Yoga_HomePanel ]
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


