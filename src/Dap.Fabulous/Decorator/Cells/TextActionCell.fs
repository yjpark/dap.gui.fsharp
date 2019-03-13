[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.TextActionCell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : TextActionCell -> unit,
            ?textColor : Color, ?detailColor : Color,
            ?actionColor : Color, ?actionSelectedColor : Color, ?actionDisabledColor : Color, ?actionBackgroundColor : Color) =
    inherit TextCell.Decorator<TextActionCell>
        (?backgroundColor = backgroundColor, ?update = update,
            ?textColor = textColor, ?detailColor = detailColor)
    override __.Decorate (widget : TextActionCell) =
        base.Decorate widget
        actionColor
        |> Option.iter (fun x -> widget.ActionColor <- x)
        actionSelectedColor
        |> Option.iter (fun x -> widget.ActionPressedColor <- x)
        actionDisabledColor
        |> Option.iter (fun x -> widget.ActionDisabledColor <- x)
        actionBackgroundColor
        |> Option.iter (fun x -> widget.ActionBackgroundColor <- x)