[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Entry

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : Entry -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness,
            ?textColor : Color, ?textBorderColor : Color, ?textBackgroundColor : Color, ?fontSize : float, ?placeholderColor : Color) =
    inherit View.Decorator<Entry>
        (?backgroundColor = backgroundColor, ?update = update,
            ?horizontalOptions = horizontalOptions, ?verticalOptions = verticalOptions, ?margin = margin)
    let native = base.TryGetNativeDecorator<IEntryDecorator> ()
    let DecorateNative (widget : Entry) (decorator : IEntryDecorator) =
        if textBorderColor.IsSome || textBackgroundColor.IsSome then
            runGuiFunc' (fun () ->
                textBorderColor
                |> Option.iter (fun x -> decorator.SetTextBorderColor (widget, x))
                textBackgroundColor
                |> Option.iter (fun x -> decorator.SetTextBackgroundColor (widget, x))
            )
    override __.Decorate (widget : Entry) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        fontSize
        |> Option.iter (fun x -> widget.FontSize <- x)
        placeholderColor
        |> Option.iter (fun x -> widget.PlaceholderColor <- x)
