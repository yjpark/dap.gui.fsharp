[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.TextCell

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator
        (?backgroundColor : Color, ?update : TextCell -> unit,
            ?textColor : Color, ?detailColor : Color) =
    inherit Cell.Decorator<TextCell>
        (?backgroundColor = backgroundColor, ?update = update)
    override __.Decorate (widget : TextCell) =
        base.Decorate widget
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        detailColor
        |> Option.iter (fun x -> widget.DetailColor <- x)