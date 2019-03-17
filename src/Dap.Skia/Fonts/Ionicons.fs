[<AutoOpen>]
module Dap.Skia.Ionicons

open SkiaSharp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local

// Based on
// https://github.com/joshuapolok/Xamarin-Font-Icons/blob/master/VectorIcon/VectorIcon.FormsPlugin.Abstractions/FontCodes/IonIconCode.cs
// Grouped and remove prefixes.

[<Literal>]
let Ionicons_Font_Path = "Assets/Fonts/ionicons.ttf"

let mutable private typeface : SKTypeface option = None

let private getTypeface () =
    if typeface.IsNone then
        typeface <- EmbeddedResource.TryCreateTypeface Ionicons_Font_Path
    typeface.Value

let private calcOffsetY (size : int) : float32 =
    ((float32)size) * 3.0f / 8.0f

type IoniconsCache (folder : string, glyphs : string list, paint : SKPaint, size : int) =
    inherit FontIconCache (folder, glyphs, paint, size, calcOffsetY size)

type Ionicons () =
    static let icons = new IoniconsGlyph.Icons ()
    static let android = new IoniconsGlyph.AndroidIcons ()
    static let iOS = new IoniconsGlyph.IOSIcons ()
    static let social = new IoniconsGlyph.SocialIcons ()
    static member Icons = icons
    static member Android = android
    static member IOS = iOS
    static member Social = social
    static member Typeface = getTypeface ()
    static member GetPaint
        (?textSize : float32, ?color : SKColor,
            ?isAntialias : bool, ?style : SKPaintStyle) =
        let paint = new SKPaint ()
        paint.Typeface <- Ionicons.Typeface
        textSize
        |> Option.iter (fun x -> paint.TextSize <- x)
        color
        |> Option.iter (fun x -> paint.Color <- x)
        isAntialias
        |> Option.defaultValue true
        |> (fun x -> paint.IsAntialias <- x)
        style
        |> Option.iter (fun x -> paint.Style <- x)
        paint
    static member EnsureCache
        (folder : string, glyphs : string list,
            textSize : int, color : SKColor,
            ?isAntialias : bool, ?style : SKPaintStyle,
            ?setupPaint : SKPaint -> unit) =
        let paint =
            Ionicons.GetPaint
                (textSize = (float32)textSize, color = color,
                ?isAntialias = isAntialias, ?style = style)
        let setupPaint = defaultArg setupPaint ignore
        setupPaint paint
        let cache = new IoniconsCache (folder, glyphs, paint, textSize)
        cache.EnsureAllCache ()
        cache
