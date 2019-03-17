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

let private md5 = new MD5CryptoServiceProvider()

type System.String with
    member this.ToGlyphImageCacheKey () =
        Encoding.UTF8.GetBytes this
        |> md5.ComputeHash
        |> Convert.ToBase64String
        |> sprintf "%s.png"

type FontIconCache (folder : string, glyphs : string list, paint : SKPaint, size : int, offsetY : float32) =
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
    member this.CreateOneCache (glyph : string) =
        canvas.Clear (SKColors.Transparent)
        canvas.DrawText (glyph, center, center + offsetY, paint)
        canvas.Flush ()
        let image = surface.Snapshot ()
        let image = image.Encode ()
        use stream = new MemoryStream ()
        image.SaveTo stream
        stream.ToArray ()
    member this.EnsureOneCache (glyph : string) =
        let cacheKey = glyph.ToGlyphImageCacheKey ()
        let relPath = System.IO.Path.Combine (folder, cacheKey)
        Cache.ensure relPath (fun () -> this.CreateOneCache glyph)
    member this.EnsureAllCache () =
        glyphs
        |> List.iter this.EnsureOneCache