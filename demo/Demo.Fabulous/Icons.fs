[<AutoOpen>]
module Demo.Fabulous.Icons

open SkiaSharp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Skia

type Icons () =
    //TODO: Different icons for ios and android
    static member Settings =
        Ionicons.Icons.Settings
    static member Help =
        Ionicons.Icons.Help
    static member EnsureCache () =
        Ionicons.EnsureCache ("icons_white", [ Icons.Settings ; Icons.Help ], 128, SKColors.White)
        |> ignore
        Ionicons.EnsureCache ("icons_black", [ Icons.Settings ; Icons.Help ], 128, SKColors.Black)
        |> ignore
