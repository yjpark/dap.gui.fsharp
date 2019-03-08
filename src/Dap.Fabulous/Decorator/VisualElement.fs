[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.VisualElement

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> VisualElement>
        (?backgroundColor : Color) =
    inherit BaseDecorator<'widget> ()
    override __.Decorate (widget : 'widget) =
        backgroundColor
        |> Option.iter (fun x -> widget.BackgroundColor <- x)

type Decorator
        (?backgroundColor : Color) =
    inherit Decorator<VisualElement>
        (?backgroundColor = backgroundColor)
