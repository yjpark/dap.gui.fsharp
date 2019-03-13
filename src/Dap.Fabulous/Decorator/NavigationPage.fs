[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.NavigationPage

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let NativeDecoratorKind = "NavigationPageNativeDecorator"

type INativeDecorator =
    inherit IFeature
    //Note : Can NOT just use NavigationPage.BarTextColor, which has different behavior
    //On Android and iOS
    // iOS: Change both title and action
    // Android: Change only title
    //|> Option.iter (fun x -> widget.BarTextColor <- x)
    abstract SetBarActionColor : NavigationPage -> Color -> unit
    abstract UpdateBarStyle : NavigationPage -> unit

type Decorator
        (?backgroundColor : Color, ?update : NavigationPage -> unit,
            ?padding : Thickness,
            ?barTextColor : Color, ?barBackgroundColor : Color, ?barActionColor : Color) =
    inherit Page.Decorator<NavigationPage>
        (?backgroundColor = backgroundColor, ?update = update,
            ?padding = padding)
    let native = base.TryCreateFeature<INativeDecorator> ()
    let DecorateNative (widget : NavigationPage) (decorator : INativeDecorator) =
        widget.Appearing.Add (fun _ ->
            barActionColor
            |> Option.iter (decorator.SetBarActionColor widget)
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
