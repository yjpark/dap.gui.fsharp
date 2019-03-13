[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.SwitchCell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let NativeDecoratorKind = "SwitchCellNativeDecorator"

type INativeDecorator =
    inherit IFeature
    abstract SetTextColor : SwitchCell -> Color -> unit

type Decorator
        (?backgroundColor : Color, ?update : SwitchCell -> unit,
            ?textColor : Color, ?onColor : Color) =
    inherit Cell.Decorator<SwitchCell>
        (?backgroundColor = backgroundColor, ?update = update)
    let native = base.TryCreateFeature<INativeDecorator> ()
    let DecorateNative (widget : SwitchCell) (decorator : INativeDecorator) =
        if textColor.IsSome then
            widget.Appearing.Add (fun _ ->
                textColor
                |> Option.iter (decorator.SetTextColor widget)
            )

    override __.Decorate (widget : SwitchCell) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        onColor
        |> Option.iter (fun x -> widget.OnColor <- x)