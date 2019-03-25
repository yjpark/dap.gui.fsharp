[<RequireQualifiedAccess>]
module Dap.Gui.Palette.Material

open Dap.Prelude
open Dap.Context
open Dap.Platform

type Params = MaterialParams with
    static member Black = "#000000"
    static member White = "#FFFFFF"
    static member Red =
        MaterialParam.PaletteParam.Create
            (
                350, "#FFEBEE", "#FFCDD2", "#EF9A9A", "#E57373", "#EF5350", "#F44336", "#E53935", "#D32F2F", "#C62828", "#B71C1C",
                150, "#FF8A80", "#FF5252", "#FF1744", "#D50000"
            )
    static member Pink =
        MaterialParam.PaletteParam.Create
            (
                350, "#FCE4EC", "#F8BBD0", "#F48FB1", "#F06292", "#EC407A", "#E91E63", "#D81B60", "#C2185B", "#AD1457", "#880E4F",
                150, "#FF80AB", "#FF4081", "#F50057", "#C51162"
            )
    static member Purple =
        MaterialParam.PaletteParam.Create
            (
                250, "#F3E5F5", "#E1BEE7", "#CE93D8", "#BA68C8", "#AB47BC", "#9C27B0", "#8E24AA", "#7B1FA2", "#6A1B9A", "#4A148C",
                150, "#EA80FC", "#E040FB", "#D500F9", "#AA00FF"
            )
    static member DeepPurple =
        MaterialParam.PaletteParam.Create
            (
                350, "#EDE7F6", "#D1C4E9", "#B39DDB", "#9575CD", "#7E57C2", "#673AB7", "#5E35B1", "#512DA8", "#4527A0", "#311B92",
                150, "#B388FF", "#7C4DFF", "#651FFF", "#6200EA"
            )
    static member Indigo =
        MaterialParam.PaletteParam.Create
            (
                350, "#E8EAF6", "#C5CAE9", "#9FA8DA", "#7986CB", "#5C6BC0", "#3F51B5", "#3949AB", "#303F9F", "#1A237E", "#8C9EFF",
                150, "#8C9EFF", "#536DFE", "#3D5AFE", "#304FFE"
            )
    static member Blue =
        MaterialParam.PaletteParam.Create
            (
                550, "#E3F2FD", "#BBDEFB", "#90CAF9", "#64B5F6", "#42A5F5", "#2196F3", "#1E88E5", "#1976D2", "#1565C0", "#0D47A1",
                150, "#82B1FF", "#448AFF", "#2979FF", "#2962FF"
            )
    static member LightBlue =
        MaterialParam.PaletteParam.Create
            (
                650, "#E1F5FE", "#B3E5FC", "#81D4FA", "#4FC3F7", "#29B6F6", "#03A9F4", "#039BE5", "#0288D1", "#0277BD", "#01579B",
                450, "#80D8FF", "#40C4FF", "#00B0FF", "#0091EA"
            )
    static member Cyan =
        MaterialParam.PaletteParam.Create
            (
                650, "#E0F7FA", "#B2EBF2", "#80DEEA", "#4DD0E1", "#26C6DA", "#00BCD4", "#00ACC1", "#0097A7", "#00838F", "#006064",
                750, "#84FFFF", "#18FFFF", "#00E5FF", "#00B8D4"
            )
    static member Teal =
        MaterialParam.PaletteParam.Create
            (
                450, "#E0F2F1", "#B2DFDB", "#80CBC4", "#4DB6AC", "#26A69A", "#009688", "#00897B", "#00796B", "#00695C", "#004D40",
                750, "#A7FFEB", "#64FFDA", "#1DE9B6", "#00BFA5"
            )
    static member Green =
        MaterialParam.PaletteParam.Create
            (
                550, "#E8F5E9", "#C8E6C9", "#A5D6A7", "#81C784", "#66BB6A", "#4CAF50", "#43A047", "#388E3C", "#2E7D32", "#1B5E20",
                750, "#B9F6CA", "#69F0AE", "#00E676", "#00C853"
            )
    static member LightGreen =
        MaterialParam.PaletteParam.Create
            (
                750, "#F1F8E9", "#DCEDC8", "#C5E1A5", "#AED581", "#9CCC65", "#8BC34A", "#7CB342", "#689F38", "#558B2F", "#33691E",
                750, "#CCFF90", "#B2FF59", "#76FF03", "#64DD17"
            )
    static member Lime =
        MaterialParam.PaletteParam.Create
            (
                850, "#F9FBE7", "#F0F4C3", "#E6EE9C", "#DCE775", "#D4E157", "#CDDC39", "#C0CA33", "#AFB42B", "#9E9D24", "#827717",
                750, "#F4FF81", "#EEFF41", "#C6FF00", "#AEEA00"
            )
    static member Yellow =
        MaterialParam.PaletteParam.Create
            (
                950, "#FFFDE7", "#FFF9C4", "#FFF59D", "#FFF176", "#FFEE58", "#FFEB3B", "#FDD835", "#FBC02D", "#F9A825", "#F57F17",
                750, "#FFFF8D", "#FFFF00", "#FFEA00", "#FFD600"
            )
    static member Amber =
        MaterialParam.PaletteParam.Create
            (
                950, "#FFF8E1", "#FFECB3", "#FFE082", "#FFD54F", "#FFCA28", "#FFC107", "#FFB300", "#FFA000", "#FF8F00", "#FF6F00",
                750, "#FFE57F", "#FFD740", "#FFC400", "#FFAB00"
            )
    static member Orange =
        MaterialParam.PaletteParam.Create
            (
                850, "#FFF3E0", "#FFE0B2", "#FFCC80", "#FFB74D", "#FFA726", "#FF9800", "#FB8C00", "#F57C00", "#EF6C00", "#E65100",
                750, "#FFD180", "#FFAB40", "#FF9100", "#FF6D00"
            )
    static member DeepOrange =
        MaterialParam.PaletteParam.Create
            (
                550, "#FBE9E7", "#FFCCBC", "#FFAB91", "#FF8A65", "#FF7043", "#FF5722", "#F4511E", "#E64A19", "#D84315", "#BF360C",
                250, "#FF9E80", "#FF6E40", "#FF3D00", "#DD2C00"
            )
    static member Brown =
        MaterialParam.GrayPaletteParam.Create
            (
                250, "#EFEBE9", "#D7CCC8", "#BCAAA4", "#A1887F", "#8D6E63", "#795548", "#6D4C41", "#5D4037", "#4E342E", "#3E2723"
            )
    static member Gray =
        MaterialParam.GrayPaletteParam.Create
            (
                550, "#FAFAFA", "#F5F5F5", "#EEEEEE", "#E0E0E0", "#BEBEBE", "#9E9E9E", "#757575", "#616161", "#424242", "#212121"
            )
    static member BlueGray =
        MaterialParam.GrayPaletteParam.Create
            (
                350, "#CECFF1", "#CFD8DC", "#B0BEC5", "#90A4AE", "#78909C", "#607D8B", "#546E7A", "#455A64", "#37473F", "#263238"
            )
    static member Palettes =
        MaterialParam.PalettesParam.Create
            (
                Params.Black, Params.White,
                Params.Red, Params.Pink, Params.Purple, Params.DeepPurple,
                Params.Indigo, Params.Blue, Params.LightBlue, Params.Cyan,
                Params.Teal, Params.Green, Params.LightGreen, Params.Lime,
                Params.Yellow, Params.Amber, Params.Orange, Params.DeepOrange,
                Params.Brown, Params.Gray, Params.BlueGray
            )
    static member CreateScheme
            (normal, dimmed, surface, background,
                ?primary, ?secondary,
                ?action, ?actionDimmed, ?actionAccent, ?actionSurface,
                ?switch, ?switchDimmed, ?switchAccent,
                ?section, ?sectionDimmed, ?sectionSurface
                ) : ColorSchemeParam =
        let primary = defaultArg primary background
        let secondary = defaultArg secondary surface
        let action = defaultArg action normal
        let actionDimmed = defaultArg actionDimmed dimmed
        let actionAccent = defaultArg actionAccent action
        let switch = defaultArg switch normal
        let switchDimmed = defaultArg switchDimmed dimmed
        let switchAccent = defaultArg switchAccent switch
        let section = defaultArg section normal
        let sectionDimmed = defaultArg sectionDimmed dimmed
        let sectionSurface = defaultArg sectionSurface surface
        {
            Primary = SurfaceColorParam.Create
                (brush = normal, normal = primary)
            Secondary = SurfaceColorParam.Create
                (brush = normal, normal = secondary)
            Label = BrushColorParam.Create
                (normal = normal, dimmed = dimmed)
            Button = BrushColorParam.Create
                (normal = action, dimmed = actionDimmed, accent = actionAccent, surface = background)
            TextField = BrushColorParam.Create
                (normal = normal, dimmed = dimmed)
            Switch = BrushColorParam.Create
                (normal = switch, dimmed = switchDimmed, accent = switchAccent)
            Box = BrushColorParam.Create
                (normal = normal, dimmed = dimmed, surface = surface)
            Table = BrushColorParam.Create
                (normal = normal, dimmed = dimmed, surface = surface)
            Section = BrushColorParam.Create
                (normal = section, dimmed = sectionDimmed, surface = sectionSurface)
            Panel = BrushColorParam.Create
                (normal = normal, dimmed = dimmed, surface = surface)
            Toolbar = BrushColorParam.Create
                (normal = action, dimmed = actionDimmed, accent = actionAccent, surface = surface)
            Error = BrushColorParam.Create
                (normal = Params.White, surface = Params.Red.Normal500)
            Background = background
        }
    static member LightScheme : ColorSchemeParam =
        Params.CreateScheme
            (
                normal = Params.Black,
                dimmed = Params.Gray.Normal700,
                surface = Params.Gray.Normal100,
                background = Params.White,
                action = Params.Blue.Normal700,
                actionAccent = Params.Blue.Normal800,
                switchAccent = Params.Green.Normal700,
                section = Params.Red.Normal600,
                sectionDimmed = Params.Gray.Normal400
            )
    static member DarkScheme : ColorSchemeParam =
        Params.CreateScheme
            (
                normal = Params.Gray.Normal100,
                dimmed = Params.Gray.Normal400,
                surface = Params.Gray.Normal900,
                background = Params.Black,
                action = Params.Blue.Normal400,
                actionAccent = Params.Blue.Normal300,
                switchAccent = Params.Green.Normal500,
                section = Params.Red.Normal500,
                sectionDimmed = Params.Gray.Normal700
            )

// https://material.io/design/color/the-color-system.html
type GrayPalette<'color> = {
    Black : 'color
    White : 'color
    MiddleShadeNormal : int
    Normal50 : 'color
    Normal100 : 'color
    Normal200 : 'color
    Normal300 : 'color
    Normal400 : 'color
    Normal500 : 'color
    Normal600 : 'color
    Normal700 : 'color
    Normal800 : 'color
    Normal900 : 'color
} with
    interface IPalette
    member this.IsNormal50Dark = 50 > this.MiddleShadeNormal
    member this.IsNormal100Dark = 100 > this.MiddleShadeNormal
    member this.IsNormal200Dark = 200 > this.MiddleShadeNormal
    member this.IsNormal300Dark = 300 > this.MiddleShadeNormal
    member this.IsNormal400Dark = 400 > this.MiddleShadeNormal
    member this.IsNormal500Dark = 500 > this.MiddleShadeNormal
    member this.IsNormal600Dark = 600 > this.MiddleShadeNormal
    member this.IsNormal700Dark = 700 > this.MiddleShadeNormal
    member this.IsNormal800Dark = 800 > this.MiddleShadeNormal
    member this.IsNormal900Dark = 900 > this.MiddleShadeNormal
    member this.OnNormal50 = if this.IsNormal50Dark then this.White else this.Black
    member this.OnNormal100 = if this.IsNormal100Dark then this.White else this.Black
    member this.OnNormal200 = if this.IsNormal200Dark then this.White else this.Black
    member this.OnNormal300 = if this.IsNormal300Dark then this.White else this.Black
    member this.OnNormal400 = if this.IsNormal400Dark then this.White else this.Black
    member this.OnNormal500 = if this.IsNormal500Dark then this.White else this.Black
    member this.OnNormal600 = if this.IsNormal600Dark then this.White else this.Black
    member this.OnNormal700 = if this.IsNormal700Dark then this.White else this.Black
    member this.OnNormal800 = if this.IsNormal800Dark then this.White else this.Black
    member this.OnNormal900 = if this.IsNormal900Dark then this.White else this.Black

    static member Create (factory : IColorFactory<'color>) black white (param : MaterialParam.GrayPaletteParam) : GrayPalette<'color> =
        {
            Black = black
            White = white
            MiddleShadeNormal = param.MiddleShadeNormal
            Normal50 = factory.Create param.Normal50
            Normal100 = factory.Create param.Normal100
            Normal200 = factory.Create param.Normal200
            Normal300 = factory.Create param.Normal300
            Normal400 = factory.Create param.Normal400
            Normal500 = factory.Create param.Normal500
            Normal600 = factory.Create param.Normal600
            Normal700 = factory.Create param.Normal700
            Normal800 = factory.Create param.Normal800
            Normal900 = factory.Create param.Normal900
        }

type Palette<'color> = {
    Black : 'color
    White : 'color
    MiddleShadeNormal : int
    MiddleShadeAccent : int
    Normal50 : 'color
    Normal100 : 'color
    Normal200 : 'color
    Normal300 : 'color
    Normal400 : 'color
    Normal500 : 'color
    Normal600 : 'color
    Normal700 : 'color
    Normal800 : 'color
    Normal900 : 'color
    Accent100 : 'color
    Accent200 : 'color
    Accent400 : 'color
    Accent700 : 'color
} with
    interface IPalette
    member this.IsNormal50Dark = 50 > this.MiddleShadeNormal
    member this.IsNormal100Dark = 100 > this.MiddleShadeNormal
    member this.IsNormal200Dark = 200 > this.MiddleShadeNormal
    member this.IsNormal300Dark = 300 > this.MiddleShadeNormal
    member this.IsNormal400Dark = 400 > this.MiddleShadeNormal
    member this.IsNormal500Dark = 500 > this.MiddleShadeNormal
    member this.IsNormal600Dark = 600 > this.MiddleShadeNormal
    member this.IsNormal700Dark = 700 > this.MiddleShadeNormal
    member this.IsNormal800Dark = 800 > this.MiddleShadeNormal
    member this.IsNormal900Dark = 900 > this.MiddleShadeNormal
    member this.IsAccent100Dark = 100 > this.MiddleShadeAccent
    member this.IsAccent200Dark = 200 > this.MiddleShadeAccent
    member this.IsAccent400Dark = 400 > this.MiddleShadeAccent
    member this.IsAccent700Dark = 700 > this.MiddleShadeAccent
    member this.OnNormal50 = if this.IsNormal50Dark then this.White else this.Black
    member this.OnNormal100 = if this.IsNormal100Dark then this.White else this.Black
    member this.OnNormal200 = if this.IsNormal200Dark then this.White else this.Black
    member this.OnNormal300 = if this.IsNormal300Dark then this.White else this.Black
    member this.OnNormal400 = if this.IsNormal400Dark then this.White else this.Black
    member this.OnNormal500 = if this.IsNormal500Dark then this.White else this.Black
    member this.OnNormal600 = if this.IsNormal600Dark then this.White else this.Black
    member this.OnNormal700 = if this.IsNormal700Dark then this.White else this.Black
    member this.OnNormal800 = if this.IsNormal800Dark then this.White else this.Black
    member this.OnNormal900 = if this.IsNormal900Dark then this.White else this.Black
    member this.OnAccent100 = if this.IsAccent100Dark then this.White else this.Black
    member this.OnAccent200 = if this.IsAccent200Dark then this.White else this.Black
    member this.OnAccent400 = if this.IsAccent400Dark then this.White else this.Black
    member this.OnAccent700 = if this.IsAccent700Dark then this.White else this.Black

    static member Create (factory : IColorFactory<'color>) black white (param : MaterialParam.PaletteParam) : Palette<'color> =
        {
            Black = black
            White = white
            MiddleShadeNormal = param.MiddleShadeNormal
            Normal50 = factory.Create param.Normal50
            Normal100 = factory.Create param.Normal100
            Normal200 = factory.Create param.Normal200
            Normal300 = factory.Create param.Normal300
            Normal400 = factory.Create param.Normal400
            Normal500 = factory.Create param.Normal500
            Normal600 = factory.Create param.Normal600
            Normal700 = factory.Create param.Normal700
            Normal800 = factory.Create param.Normal800
            Normal900 = factory.Create param.Normal900
            MiddleShadeAccent = param.MiddleShadeAccent
            Accent100 = factory.Create param.Accent100
            Accent200 = factory.Create param.Accent200
            Accent400 = factory.Create param.Accent400
            Accent700 = factory.Create param.Accent700
        }

type Palettes<'color> = {
    Black : 'color
    White : 'color
    Red : Palette<'color>
    Pink : Palette<'color>
    Purple : Palette<'color>
    DeepPurple : Palette<'color>
    Indigo : Palette<'color>
    Blue : Palette<'color>
    LightBlue : Palette<'color>
    Cyan : Palette<'color>
    Teal : Palette<'color>
    Green : Palette<'color>
    LightGreen : Palette<'color>
    Lime : Palette<'color>
    Yellow : Palette<'color>
    Amber : Palette<'color>
    Orange : Palette<'color>
    DeepOrange : Palette<'color>
    Brown : GrayPalette<'color>
    Gray : GrayPalette<'color>
    BlueGray : GrayPalette<'color>
} with
    interface IPalettes<Palette<'color>, GrayPalette<'color>, 'color> with
        member this.Black = this.Black
        member this.White = this.White
        member this.Red = this.Red
        member this.Pink = this.Pink
        member this.Purple = this.Purple
        member this.DeepPurple = this.DeepPurple
        member this.Indigo = this.Indigo
        member this.Blue = this.Blue
        member this.LightBlue = this.LightBlue
        member this.Cyan = this.Cyan
        member this.Teal = this.Teal
        member this.Green = this.Green
        member this.LightGreen = this.LightGreen
        member this.Lime = this.Lime
        member this.Yellow = this.Yellow
        member this.Amber = this.Amber
        member this.Orange = this.Orange
        member this.DeepOrange = this.DeepOrange
        member this.Brown = this.Brown
        member this.Gray = this.Gray
        member this.BlueGray = this.BlueGray
    static member Create (factory : IColorFactory<'color>, ?param : MaterialParam.PalettesParam) : Palettes<'color> =
        let param = defaultArg param Params.Palettes
        let black = factory.Create param.Black
        let white = factory.Create param.White
        {
            Black = black
            White = white
            Red = Palette<'color>.Create factory black white param.Red
            Pink = Palette<'color>.Create factory black white param.Pink
            Purple = Palette<'color>.Create factory black white param.Purple
            DeepPurple = Palette<'color>.Create factory black white param.DeepPurple
            Indigo = Palette<'color>.Create factory black white param.Indigo
            Blue = Palette<'color>.Create factory black white param.Blue
            LightBlue = Palette<'color>.Create factory black white param.LightBlue
            Cyan = Palette<'color>.Create factory black white param.Cyan
            Teal = Palette<'color>.Create factory black white param.Teal
            Green = Palette<'color>.Create factory black white param.Green
            LightGreen = Palette<'color>.Create factory black white param.LightGreen
            Lime = Palette<'color>.Create factory black white param.Lime
            Yellow = Palette<'color>.Create factory black white param.Yellow
            Amber = Palette<'color>.Create factory black white param.Amber
            Orange = Palette<'color>.Create factory black white param.Orange
            DeepOrange = Palette<'color>.Create factory black white param.DeepOrange
            Brown = GrayPalette<'color>.Create factory black white param.Brown
            Gray = GrayPalette<'color>.Create factory black white param.Gray
            BlueGray = GrayPalette<'color>.Create factory black white param.BlueGray
        }
