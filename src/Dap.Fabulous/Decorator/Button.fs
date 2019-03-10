[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Button

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator
        (?backgroundColor : Color, ?update : Button -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness,
            ?textColor : Color, ?fontSize : float) =
    inherit View.Decorator<Button>
        (?backgroundColor = backgroundColor, ?update = update,
            ?horizontalOptions = horizontalOptions, ?verticalOptions = verticalOptions, ?margin = margin)
    override __.Decorate (widget : Button) =
        base.Decorate widget
        textColor
        |> Option.iter (fun x -> widget.TextColor <- x)
        fontSize
        |> Option.iter (fun x -> widget.FontSize <- x)