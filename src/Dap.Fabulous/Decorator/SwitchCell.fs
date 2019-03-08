[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.SwitchCell

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let TextColorSetterKind = "SwitchCellTextColorSetter"

type ITextColorSetter =
    inherit IFeature
    abstract SetTextColor : SwitchCell -> Color -> unit

let mutable private textColorSetter : ITextColorSetter option = None
let mutable initialized = false

let setTextColor (widget : SwitchCell) (textColor : Color) =
    if not initialized then
        textColorSetter <- Feature.tryCreate<ITextColorSetter> (getLogging ())
        if textColorSetter.IsNone then
            logError (getLogging ()) "SwitchCell.setTextColor" "Feature_Not_Exist" "ITextColorSetter"
    textColorSetter
    |> Option.iter (fun setter ->
        widget.Appearing.Add (fun _ ->
            setter.SetTextColor widget textColor
        )
    )

type Decorator
        (?backgroundColor : Color,
            ?textColor : Color, ?onColor : Color) =
    inherit Cell.Decorator<SwitchCell>
        (?backgroundColor = backgroundColor)
    override __.Decorate (widget : SwitchCell) =
        base.Decorate widget
        textColor
        |> Option.iter ^<| setTextColor widget
        onColor
        |> Option.iter (fun x -> widget.OnColor <- x)