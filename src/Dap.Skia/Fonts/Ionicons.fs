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

type Ionicons (folder : string, glyphs : string list, size : int, color : SKColor,
                ?setupPaint : SKPaint -> unit) =
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

type IoniconsCache (folder : string, glyphs : string list, paint : SKPaint, size : int,
                        ?clearColor : SKColor, ?format: SKEncodedImageFormat, ?quality : int) =
    inherit FontIconCache (folder, glyphs, paint, size, calcOffsetY size,
                            ?clearColor = clearColor, ?format = format, ?quality = quality)
    new (folder : string, glyphs : string list, color : SKColor, size : int,
                        ?clearColor : SKColor, ?format: SKEncodedImageFormat, ?quality : int) =
        let paint = Ionicons.GetPaint ((float32) size, color)
        new IoniconsCache (folder, glyphs, paint, size,
                            ?clearColor = clearColor, ?format = format, ?quality = quality)
