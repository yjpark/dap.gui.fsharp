[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.TextCell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'cell when 'cell :> TextCell>
        (?backgroundColor : Color, ?update : 'cell -> unit,
            ?textColor : Color, ?detailColor : Color) =
    inherit Cell.Decorator<'cell>
        (?backgroundColor = backgroundColor, ?update = update)
    override __.Decorate (widget : 'cell) =
        base.Decorate widget
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        detailColor
        |> Option.iter (fun x -> widget.DetailColor <- x)

type Decorator
        (?backgroundColor : Color, ?update : TextCell -> unit,
            ?textColor : Color, ?detailColor : Color) =
    inherit Decorator<TextCell>
        (?backgroundColor = backgroundColor, ?update = update,
            ?textColor = textColor, ?detailColor = detailColor)
