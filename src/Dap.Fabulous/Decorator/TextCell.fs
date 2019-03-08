[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.TextCell

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator
        (?backgroundColor : Color,
            ?textColor : Color, ?detailColor : Color) =
    inherit Cell.Decorator<TextCell>
        (?backgroundColor = backgroundColor)
    override __.Decorate (widget : TextCell) =
        base.Decorate widget
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        detailColor
        |> Option.iter (fun x -> widget.DetailColor <- x)