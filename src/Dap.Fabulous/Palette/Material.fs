[<RequireQualifiedAccess>]
module Dap.Fabulous.Palette.Material

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform

module Base = Dap.Gui.Palette.Material

type Palette = Base.Palette<Color>

type GrayPalette = Base.GrayPalette<Color>

type Params = Base.Params

let Palettes = Base.Palettes<Color>.Create ColorFactory

let LightScheme = ColorScheme.Create ColorFactory Params.LightScheme

let DarkScheme = ColorScheme.Create ColorFactory Params.DarkScheme