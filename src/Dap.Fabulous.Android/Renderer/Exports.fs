[<AutoOpen>]
module Dap.Fabulous.Android.Renderer.Exports

open Xamarin.Forms

open Dap.Fabulous.Controls

[<assembly: ExportRenderer (typeof<TextActionCell>, typeof<CellRenderer<TextActionCell, TextActionCell.CellView>>)>]
do ()