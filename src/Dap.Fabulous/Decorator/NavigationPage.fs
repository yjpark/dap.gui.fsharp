[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.NavigationPage

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator
        (?backgroundColor : Color, ?update : NavigationPage -> unit,
            ?padding : Thickness,
            ?barTextColor : Color, ?barBackgroundColor : Color) =
    inherit Page.Decorator<NavigationPage>
        (?backgroundColor = backgroundColor, ?update = update,
            ?padding = padding)
    override __.Decorate (widget : NavigationPage) =
        base.Decorate widget
        barTextColor
        |> Option.iter (fun x -> widget.BarTextColor <- x)
        barBackgroundColor
        |> Option.iter (fun x -> widget.BarBackgroundColor <- x)
