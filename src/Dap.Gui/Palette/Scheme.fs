[<AutoOpen>]
module Dap.Gui.Palette.Scheme

open Dap.Prelude
open Dap.Context
open Dap.Platform

type SurfaceColor<'color> = {
    Brush : 'color
    Normal : 'color
    Variant : 'color option
} with
    static member Create (factory : IColorFactory<'color>) (param : SurfaceColorParam) : SurfaceColor<'color> =
        {
            Brush = factory.Create param.Brush
            Normal = factory.Create param.Normal
            Variant = param.Variant |> Option.map factory.Create
        }

type BrushColor<'color> = {
    Normal : 'color
    Dimmed : 'color option
    Accent : 'color option
    Surface : 'color option
} with
    static member Create (factory : IColorFactory<'color>) (param : BrushColorParam) : BrushColor<'color> =
        {
            Normal = factory.Create param.Normal
            Dimmed = param.Dimmed |> Option.map factory.Create
            Accent = param.Accent |> Option.map factory.Create
            Surface = param.Surface |> Option.map factory.Create
        }

type ColorScheme<'color> = {
    Primary : SurfaceColor<'color>
    Secondary : SurfaceColor<'color>
    Label : BrushColor<'color>
    Button : BrushColor<'color>
    TextField : BrushColor<'color>
    Switch : BrushColor<'color>
    Box : BrushColor<'color>
    Table : BrushColor<'color>
    Panel : BrushColor<'color>
    Toolbar : BrushColor<'color>
    Error : BrushColor<'color>
    Background : 'color
} with
    static member Create (factory : IColorFactory<'color>) (param : ColorSchemeParam) : ColorScheme<'color> =
        {
            Primary = SurfaceColor<'color>.Create factory param.Primary
            Secondary = SurfaceColor<'color>.Create factory param.Secondary
            Label = BrushColor<'color>.Create factory param.Label
            Button = BrushColor<'color>.Create factory param.Button
            TextField = BrushColor<'color>.Create factory param.TextField
            Switch = BrushColor<'color>.Create factory param.Switch
            Box = BrushColor<'color>.Create factory param.Box
            Table = BrushColor<'color>.Create factory param.Table
            Panel = BrushColor<'color>.Create factory param.Panel
            Toolbar = BrushColor<'color>.Create factory param.Toolbar
            Error = BrushColor<'color>.Create factory param.Error
            Background = factory.Create param.Background
        }
