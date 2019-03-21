[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.TableView

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous.Controls

type Decorator
        (?backgroundColor : Color, ?update : TableView -> unit,
            ?horizontalOptions : LayoutOptions, ?verticalOptions : LayoutOptions, ?margin : Thickness,
            ?sectionTextColor : Color, ?separatorColor : Color) =
    inherit View.Decorator<TableView>
        (?backgroundColor = backgroundColor, ?update = update,
            ?horizontalOptions = horizontalOptions, ?verticalOptions = verticalOptions, ?margin = margin)
    let native = base.TryGetNativeDecorator<ITableViewDecorator> ()
    let DecorateNative (widget : TableView) (decorator : ITableViewDecorator) =
        if separatorColor.IsSome then
            runGuiFunc' (fun () ->
                separatorColor
                |> Option.iter (fun x -> decorator.SetSeparatorColor (widget, x))
            )
    override __.Decorate (widget : TableView) =
        base.Decorate widget
        native
        |> Option.iter (DecorateNative widget)
        (* Having timing issue now, not used ATM
        sectionTextColor
        |> Option.iter (fun x ->
            for section in widget.Root do
                section.TextColor <- x
        )
        *)
