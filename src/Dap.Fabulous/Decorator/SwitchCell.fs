[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.SwitchCell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : SwitchCell -> unit,
            ?textColor : Color, ?onColor : Color) =
    inherit Cell.Decorator<SwitchCell>
        (?backgroundColor = backgroundColor, ?update = update)
    let native = base.TryGetNativeDecorator<ISwitchCellDecorator> ()
    let DecorateNative (widget : SwitchCell) (decorator : ISwitchCellDecorator) =
        if textColor.IsSome then
            widget.Appearing.Add (fun _ ->
                textColor
                |> Option.iter (fun x -> decorator.SetTextColor (widget, x))
            )

    override __.Decorate (widget : SwitchCell) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        onColor
        |> Option.iter (fun x -> widget.OnColor <- x)