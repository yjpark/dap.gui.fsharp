[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.View

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> View>
        (?backgroundColor : Color, ?update : 'widget -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness) =
    inherit VisualElement.Decorator<'widget>
        (?backgroundColor = backgroundColor, ?update = update)
    override __.Decorate (widget : 'widget) =
        base.Decorate widget
        horizontalOptions
        |> Option.iter (fun x -> widget.HorizontalOptions <- x)
        verticalOptions
        |> Option.iter (fun x -> widget.VerticalOptions <- x)
        margin
        |> Option.iter (fun x -> widget.Margin <- x)

type Decorator
        (?backgroundColor : Color, ?update : View -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness) =
    inherit Decorator<View>
        (?backgroundColor = backgroundColor, ?update = update,
            ?horizontalOptions = horizontalOptions, ?verticalOptions = verticalOptions, ?margin = margin)
