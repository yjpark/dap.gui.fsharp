[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.NavigationPage

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : NavigationPage -> unit,
            ?padding : Thickness,
            ?barTextColor : Color, ?barBackgroundColor : Color, ?barActionColor : Color) =
    inherit Page.Decorator<NavigationPage>
        (?backgroundColor = backgroundColor, ?update = update,
            ?padding = padding)
    let native = base.TryGetNativeDecorator<INavigationPageDecorator> ()
    let DecorateNative (widget : NavigationPage) (decorator : INavigationPageDecorator) =
        widget.Appearing.Add (fun _ ->
            barActionColor
            |> Option.iter (fun x -> decorator.SetBarActionColor (widget, x))
            decorator.UpdateBarStyle widget
        )

    override __.Decorate (widget : NavigationPage) =
        base.Decorate widget
        barTextColor
        |> Option.iter (fun x -> widget.BarTextColor <- x)
        barBackgroundColor
        |> Option.iter (fun x -> widget.BarBackgroundColor <- x)
        native
        |> Option.iter (DecorateNative widget)
