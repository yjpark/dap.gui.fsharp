[<AutoOpen>]
module Dap.Gui.Palette.Types

open Dap.Prelude
open Dap.Context
open Dap.Platform

//Support
// #RGB
// #ARGB
// #RRGGBB
// #AARRGGBB
type ColorHex = string

type IColorFactory<'color> =
    abstract Create : ColorHex -> 'color

type IPalette = interface end

type IPalettes<'palette, 'grayPalette, 'color when 'palette :> IPalette and 'grayPalette :> IPalette> =
    abstract Black : 'color
    abstract White : 'color
    abstract Red : 'palette
    abstract Pink : 'palette
    abstract Purple : 'palette
    abstract DeepPurple : 'palette
    abstract Indigo : 'palette
    abstract Blue : 'palette
    abstract LightBlue : 'palette
    abstract Cyan : 'palette
    abstract Teal : 'palette
    abstract Green : 'palette
    abstract LightGreen : 'palette
    abstract Lime : 'palette
    abstract Yellow : 'palette
    abstract Amber : 'palette
    abstract Orange : 'palette
    abstract DeepOrange : 'palette
    abstract Brown : 'grayPalette
    abstract Gray : 'grayPalette
    abstract BlueGray : 'grayPalette

type Colors<'color> = {
    Normal : 'color
    Dimmed : 'color
    Accent : 'color
    Background : 'color
}
