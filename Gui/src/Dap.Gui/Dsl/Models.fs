module Dap.Gui.Dsl.Models

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta
open Dap.Context.Generator

let IViewProps =
    combo {
        var (M.string "prefab")
        list (M.string "styles")
    }

let IControlProps =
    extend [ <@ IViewProps @> ] {
        var (M.bool "disabled")
    }

let ITextProps =
    extend [ <@ IViewProps @> ] {
        var (M.string "text")
    }

let IGroupProps =
    extend [ <@ IViewProps @> ] {
        var (M.string "layout")
    }

let ListProps =
    extend [ <@ IGroupProps @> ] {
        var (M.string "item_prefab")
    }

let ComboProps =
    extend [ <@ IGroupProps @> ] {
        prop (M.combo "children")
    }

let LabelProps =
    extend [ <@ ITextProps @> ] {
        nothing ()
    }

let ButtonProps =
    extend [ <@ IControlProps @> ; <@ ITextProps @> ] {
        nothing ()
    }

let TextFieldProps =
    extend [ <@ IControlProps @> ; <@ ITextProps @> ] {
        nothing ()
    }

let compile segments =
    [
        G.File (segments, ["_Gen" ; "Models.fs"],
            G.AutoOpenModule ("Dap.Gui.Models",
                [
                    G.ComboInterface (<@ IViewProps @>, ["ICustomProperties"])
                    G.ComboInterface (<@ IControlProps @>)
                    G.ComboInterface (<@ ITextProps @>)
                    G.ComboInterface (<@ IGroupProps @>)
                    G.Combo (<@ ListProps @>)
                    G.Combo (<@ ComboProps @>)
                    G.Combo (<@ LabelProps @>)
                    G.Combo (<@ ButtonProps @>)
                    G.Combo (<@ TextFieldProps @>)
                ]
            )
        )
        G.File (segments, ["_Gen" ; "Builder" ; "Models.fs"],
            G.BuilderModule ("Dap.Gui.Builder.Models",
                [
                    [
                        "open Dap.Gui"
                    ]
                    G.ComboBuilder <@ LabelProps @>
                    G.ComboBuilder <@ ButtonProps @>
                    G.ComboBuilder <@ TextFieldProps @>
                ]
            )
        )
        G.File (segments, ["_Gen" ; "Builder" ; "Internal" ; "Base.fs"],
            G.BuilderModule ("Dap.Gui.Builder.Internal.Base",
                [
                    [
                        "open Dap.Gui"
                    ]
                    G.ComboBuilder (<@ ListProps @>)
                    G.ComboBuilder <@ ComboProps @>
                ]
            )
        )
    ]
