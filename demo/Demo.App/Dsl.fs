module Demo.App.Dsl

open Dap.Context
open Dap.Context.Meta
open Dap.Context.Meta.Net
open Dap.Context.Generator
open Dap.Platform
open Dap.Platform.Meta
open Dap.Platform.Generator
open Dap.Platform.Dsl.Packs

let Contact =
    combo {
        var (M.string "name")
        var (M.string "phone")
    }

let AddressBookProps =
    combo {
        var (M.list (M.custom (<@ Contact @>, "contacts")))
    }

let AddressBook =
    context <@ AddressBookProps @> {
        kind "AddressBook"
        async_handler (M.unit "reload") (M.unit response)
    }

let ICorePack =
    pack [] {
        add (M.feature (<@ AddressBook @>))
    }

let App =
    live {
        has <@ ICorePack @>
    }

let compile segments =
    [
        G.File (segments, ["_Gen" ; "Types.fs"],
            G.AutoOpenModule ("Demo.App.Types",
                [
                    G.PackOpens
                    G.JsonRecord (<@ Contact @>)
                    G.Combo (<@ AddressBookProps @>)
                    G.Feature (<@ AddressBook @>)
                    G.PackInterface <@ ICorePack @>
                ]
            )
        )
        G.File (segments, ["_Gen1"; "IApp.fs"],
            G.AutoOpenModule ("Demo.App.IApp",
                [
                    G.PackOpens
                    G.AppInterface <@ App @>
                ]
            )
        )
        G.File (segments, ["_Gen1"; "App.fs"],
            G.AutoOpenModule ("Demo.App.App",
                [
                    G.PackOpens
                    G.AppClass <@ App @>
                ]
            )
        )
    ]
