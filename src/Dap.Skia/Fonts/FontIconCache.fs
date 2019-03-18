[<AutoOpen>]
module Dap.Skia.FontIconCache

open System
open System.IO
open System.Text
open System.Security.Cryptography

open SkiaSharp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local

let private md5 = new MD5CryptoServiceProvider()

let FontIconCache_DefaultClearColor = SKColors.Transparent

let FontIconCache_DefaultFormat = SKEncodedImageFormat.Png

[<Literal>]
let FontIconCache_DefaultQuality = 80

type FontIconCache (folder : string, glyphs : string list, paint : SKPaint, size : int, offsetY : float32,
                    ?clearColor : SKColor, ?format : SKEncodedImageFormat, ?quality : int) =
    let clearColor' = defaultArg clearColor FontIconCache_DefaultClearColor
    let format' = defaultArg format FontIconCache_DefaultFormat
    let quality' = defaultArg quality FontIconCache_DefaultQuality
    let center = 0.5f * ((float32) size)
    let imageInfo = new SKImageInfo (size, size)
    let surface = SKSurface.Create (imageInfo)
    let canvas = surface.Canvas
    do (
        paint.TextAlign <- SKTextAlign.Center
    )
    member __.Folder = folder
    member __.Glyphs = glyphs
    member __.Paint = paint
    member __.Size = size
    member __.OffsetY = offsetY
    member __.ClearColor = clearColor'
    member __.Format = format'
    member __.Quality = quality'
    member __.GetCacheKey (glyph : string) =
        Encoding.UTF8.GetBytes glyph
        |> md5.ComputeHash
        |> Convert.ToBase64String
        |> sprintf "%s.png"
        |> fun x -> System.IO.Path.Combine (folder, x)
    member this.GetCachePath (glyph : string) =
        Cache.getPath <| this.GetCacheKey glyph
    member this.IsCached (glyph : string) =
        Cache.has <| this.GetCacheKey glyph
    member this.GetCachedPathIfCached (glyph : string) =
        if this.IsCached glyph then
            this.GetCachePath glyph
        else
            ""
    member this.CreateCache (glyph : string) =
        canvas.Clear (clearColor')
        canvas.DrawText (glyph, center, center + offsetY, paint)
        canvas.Flush ()
        let image = surface.Snapshot ()
        let image = image.Encode (format', quality')
        use stream = new MemoryStream ()
        image.SaveTo stream
        stream.ToArray ()
    member this.EnsureCache (glyph : string) =
        let relPath = this.GetCacheKey glyph
        Cache.ensure relPath (fun () -> this.CreateCache glyph)
    member this.RefreshCache (glyph : string) =
        let relPath = this.GetCacheKey glyph
        this.CreateCache glyph
        |> BinaryFile.save (Cache.getPath relPath)
    member this.EnsureAll () =
        glyphs
        |> List.iter this.EnsureCache
    member this.RefreshAll () =
        glyphs
        |> List.iter this.RefreshCache
