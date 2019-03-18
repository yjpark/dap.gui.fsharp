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
        let cache = new IoniconsCache ("icons_white", [ Icons.Settings ; Icons.Help ], SKColors.White, 128)
        cache.EnsureAll ()
        let cache = new IoniconsCache ("icons_black", [ Icons.Settings ; Icons.Help ], SKColors.Black, 128)
        cache.EnsureAll ()
