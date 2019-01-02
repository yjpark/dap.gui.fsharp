module Faker.App.Dsl

open Dap.Context
open Dap.Context.Meta
open Dap.Context.Generator
open Dap.Platform
open Dap.Platform.Meta
open Dap.Platform.Generator
open Dap.Platform.Dsl.Packs

let Target =
    combo {
        var (M.string "project")
        var (M.string "action")
    }

let BuilderProps =
    combo {
        var (M.list (M.custom (<@ Target @>, "targets")))
    }

let Builder =
    context <@ BuilderProps @> {
        kind "Builder"
        handler (M.unit "reload") (M.unit response)
    }

let ICorePack =
    pack [] {
        add (M.feature (<@ Builder @>))
    }

let AppGui =
    emptyContext {
        kind "AppGui"
        handler (M.unit "do_dummy") (M.unit response)
    }

let IGuiPack =
    pack [] {
        add (M.feature ("IAppGui"))
    }

let App =
    live {
        has <@ ICorePack @>
        has <@ IGuiPack @>
    }

let compile segments =
    [
        G.File (segments, ["_Gen" ; "Types.fs"],
            G.AutoOpenModule ("Faker.App.Types",
                [
                    G.PackOpens
                    G.JsonRecord (<@ Target @>)
                    G.Combo (<@ BuilderProps @>)
                    G.Feature (<@ Builder @>)
                    G.Feature <@ AppGui @>
                    G.PackInterface <@ ICorePack @>
                    G.PackInterface <@ IGuiPack @>
                ]
            )
        )
        G.File (segments, ["_Gen1"; "IApp.fs"],
            G.AutoOpenModule ("Faker.App.IApp",
                [
                    G.PackOpens
                    G.AppInterface <@ App @>
                ]
            )
        )
        G.File (segments, ["_Gen1"; "App.fs"],
            G.AutoOpenModule ("Faker.App.App",
                [
                    G.PackOpens
                    G.AppClass <@ App @>
                ]
            )
        )
    ]
