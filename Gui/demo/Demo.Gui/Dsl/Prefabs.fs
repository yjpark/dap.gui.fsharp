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
    combo_h_box {
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
    list_table {
        item <@ Contact @>
    }

let HomePanel =
    combo_v_box {
        child "title" (
            label {
                text "Address Book"
            }
        )
        child "account" <@ Contact @>
        child "contacts_title" (
            label {
                text "Contacts:"
            }
        )
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
