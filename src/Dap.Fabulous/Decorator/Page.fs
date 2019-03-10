[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Page

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let NativeDecoratorKind = "PageNativeDecorator"

type INativeDecorator =
    inherit IFeature
    abstract SetToolbarTextColor : Page -> Color -> unit

type Decorator<'widget when 'widget :> Page>
        (?backgroundColor : Color, ?toolbarTextColor : Color, ?update : 'widget -> unit,
            ?padding : Thickness) =
    inherit VisualElement.Decorator<'widget>
        (?backgroundColor = backgroundColor, ?update = update)
    let native = base.TryCreateFeature<INativeDecorator> ()
    let DecorateNative (widget : 'widget) (decorator : INativeDecorator) =
        if toolbarTextColor.IsSome then
            widget.Appearing.Add (fun _ ->
                toolbarTextColor
                |> Option.iter (decorator.SetToolbarTextColor widget)
            )
    override __.Decorate (widget : 'widget) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        padding
        |> Option.iter (fun x -> widget.Padding <- x)

type Decorator
        (?backgroundColor : Color, ?toolbarTextColor : Color, ?update : Page -> unit,
            ?padding : Thickness) =
    inherit Decorator<Page>
        (?backgroundColor = backgroundColor, ?toolbarTextColor = toolbarTextColor, ?update = update,
            ?padding = padding)
