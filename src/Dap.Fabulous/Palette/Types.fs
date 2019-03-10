[<AutoOpen>]
module Dap.Fabulous.Palette.Types

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Palette

type ColorFactory = ColorFactory
with
    interface IColorFactory<Color> with
        member __.Create (hex : ColorHex) : Color =
            Color.FromHex hex

type ColorScheme = Dap.Gui.Palette.Scheme.ColorScheme<Color>