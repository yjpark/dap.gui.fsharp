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
    combo_h_box {
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
    list_table {
        item <@ Contact @>
        styles [ Yoga_Contacts ]
    }

let HomePanel =
    combo_v_box {
        child "title" (
            label {
                text "Address Book"
                styles [ Yoga_Leaf ]
            }
        )
        child "account" <@ Contact @>
        child "contacts_title" (
            label {
                text "Contacts:"
                styles [ Yoga_Leaf ]
            }
        )
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


