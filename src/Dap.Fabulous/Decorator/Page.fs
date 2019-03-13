[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Page

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> Page>
        (?backgroundColor : Color, ?update : 'widget -> unit,
            ?padding : Thickness) =
    inherit VisualElement.Decorator<'widget>
        (?backgroundColor = backgroundColor, ?update = update)
    override __.Decorate (widget : 'widget) =
        base.Decorate widget
        padding
        |> Option.iter (fun x -> widget.Padding <- x)

type Decorator
        (?backgroundColor : Color, ?update : Page -> unit,
            ?padding : Thickness) =
    inherit Decorator<Page>
        (?backgroundColor = backgroundColor, ?update = update,
            ?padding = padding)
