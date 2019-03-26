[<AutoOpen>]
module Demo.Fabulous.Icons

open SkiaSharp

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Skia

type Icons (folder : string, color : SKColor) =
    inherit IoniconsCache (folder, [ Icons.Settings ; Icons.Help ], color, Icons.Size)
    static member Size = 128
    static member Settings = Ionicons.MD.Settings
    static member Help = Ionicons.MD.Help
