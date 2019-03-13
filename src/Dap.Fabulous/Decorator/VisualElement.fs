[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.VisualElement

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> VisualElement>
        (?backgroundColor : Color, ?update : 'widget -> unit) =
    inherit BaseDecorator<'widget> ()
    override __.Decorate (widget : 'widget) =
        backgroundColor
        |> Option.iter (fun x -> widget.BackgroundColor <- x)
        update
        |> Option.iter (fun x -> x widget)

type Decorator
        (?backgroundColor : Color, ?update : VisualElement -> unit) =
    inherit Decorator<VisualElement>
        (?backgroundColor = backgroundColor, ?update = update)
