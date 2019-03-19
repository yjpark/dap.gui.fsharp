[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.EntryCell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : EntryCell -> unit,
            ?labelColor : Color, ?textColor : Color, ?textBackgroundColor : Color, ?placeholderColor : Color) =
    inherit Cell.Decorator<EntryCell>
        (?backgroundColor = backgroundColor, ?update = update)
    let native = base.TryGetNativeDecorator<IEntryCellDecorator> ()
    let DecorateNative (widget : EntryCell) (decorator : IEntryCellDecorator) =
        if textColor.IsSome
                || textBackgroundColor.IsSome
                || placeholderColor.IsSome then
            widget.Appearing.Add (fun _ ->
                textColor
                |> Option.iter (fun x -> decorator.SetTextColor (widget, x))
                textBackgroundColor
                |> Option.iter (fun x -> decorator.SetTextBackgroundColor (widget, x))
                placeholderColor
                |> Option.iter (fun x -> decorator.SetPlaceholderColor (widget, x))
            )

    override __.Decorate (widget : EntryCell) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        labelColor
        |> Option.iter (fun x -> widget.LabelColor <- x)