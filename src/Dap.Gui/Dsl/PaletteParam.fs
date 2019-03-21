module Dap.Gui.Dsl.PaletteParam

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta
open Dap.Context.Generator

let Black = "\"#000000\""
let White = "\"#FFFFFF\""

type M with
    static member color_hex (key, ?value : Kind, ?validator : string) =
        let value = value |> Option.defaultValue Black
        M.basic ("string", key, value, ?validator=validator)
        |> fun m -> m.ToAlias "ColorHex"

let SurfaceColorParam =
    combo {
        var (M.color_hex ("brush", Black))
        var (M.color_hex "normal")
        option (M.color_hex "variant")
    }

let BrushColorParam =
    combo {
        var (M.color_hex "normal")
        option (M.color_hex "dimmed")
        option (M.color_hex "accent")
        option (M.color_hex ("surface", White))
    }

let ColorSchemeParam =
    combo {
            var (M.custom (<@ SurfaceColorParam @>, "primary"))
            var (M.custom (<@ SurfaceColorParam @>, "secondary"))
            var (M.custom (<@ BrushColorParam @>, "label"))
            var (M.custom (<@ BrushColorParam @>, "button"))
            var (M.custom (<@ BrushColorParam @>, "text_field"))
            var (M.custom (<@ BrushColorParam @>, "switch"))
            var (M.custom (<@ BrushColorParam @>, "box"))
            var (M.custom (<@ BrushColorParam @>, "table"))
            var (M.custom (<@ BrushColorParam @>, "section"))
            var (M.custom (<@ BrushColorParam @>, "panel"))
            var (M.custom (<@ BrushColorParam @>, "toolbar"))
            var (M.custom (<@ BrushColorParam @>, "error"))
            var (M.color_hex ("background", White))
    }

let GrayPaletteParam =
    combo {
        var (M.int ("middle_shade_normal", 350))
        var (M.color_hex "normal_50")
        var (M.color_hex "normal_100")
        var (M.color_hex "normal_200")
        var (M.color_hex "normal_300")
        var (M.color_hex "normal_400")
        var (M.color_hex "normal_500")
        var (M.color_hex "normal_600")
        var (M.color_hex "normal_700")
        var (M.color_hex "normal_800")
        var (M.color_hex "normal_900")
    }

let PaletteParam =
    extend [ <@ GrayPaletteParam @> ] {
        var (M.int ("middle_shade_accent", 150))
        var (M.color_hex "accent_100")
        var (M.color_hex "accent_200")
        var (M.color_hex "accent_400")
        var (M.color_hex "accent_700")
    }

let PalettesParam =
    combo {
        var (M.color_hex "black")
        var (M.color_hex ("white", White))
        var (M.custom (<@ PaletteParam @>, "red"))
        var (M.custom (<@ PaletteParam @>, "pink"))
        var (M.custom (<@ PaletteParam @>, "purple"))
        var (M.custom (<@ PaletteParam @>, "deep_purple"))
        var (M.custom (<@ PaletteParam @>, "indigo"))
        var (M.custom (<@ PaletteParam @>, "blue"))
        var (M.custom (<@ PaletteParam @>, "light_blue"))
        var (M.custom (<@ PaletteParam @>, "cyan"))
        var (M.custom (<@ PaletteParam @>, "teal"))
        var (M.custom (<@ PaletteParam @>, "green"))
        var (M.custom (<@ PaletteParam @>, "light_green"))
        var (M.custom (<@ PaletteParam @>, "lime"))
        var (M.custom (<@ PaletteParam @>, "yellow"))
        var (M.custom (<@ PaletteParam @>, "amber"))
        var (M.custom (<@ PaletteParam @>, "orange"))
        var (M.custom (<@ PaletteParam @>, "deep_orange"))
        var (M.custom (<@ GrayPaletteParam @>, "brown"))
        var (M.custom (<@ GrayPaletteParam @>, "gray"))
        var (M.custom (<@ GrayPaletteParam @>, "blue_gray"))
    }

let compile segments =
    [
        G.File (segments, ["_Gen" ; "Palette" ; "SchemeParam.fs"],
            G.AutoOpenModule ("Dap.Gui.Palette.SchemeParam",
                [
                    G.LooseJsonRecord (<@ SurfaceColorParam @>)
                    G.LooseJsonRecord (<@ BrushColorParam @>)
                    G.LooseJsonRecord (<@ ColorSchemeParam @>)
                ]
            )
        )
        G.File (segments, ["_Gen" ; "Palette" ; "MaterialParam.fs"],
            G.AutoOpenQualifiedModule ("Dap.Gui.Palette.MaterialParam",
                [
                    G.LooseJsonRecord (<@ GrayPaletteParam @>)
                    G.LooseJsonRecord (<@ PaletteParam @>)
                    G.LooseJsonRecord (<@ PalettesParam @>)
                ]
            )
        )
    ]
