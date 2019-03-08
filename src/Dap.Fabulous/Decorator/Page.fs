[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Page

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> Page>
        (?backgroundColor : Color,
            ?padding : Thickness) =
    inherit VisualElement.Decorator<'widget>
        (?backgroundColor = backgroundColor)
    override __.Decorate (widget : 'widget) =
        base.Decorate widget
        padding
        |> Option.iter (fun x -> widget.Padding <- x)

type Decorator
        (?backgroundColor : Color,
            ?padding : Thickness) =
    inherit Decorator<Page>
        (?backgroundColor = backgroundColor,
            ?padding = padding)
