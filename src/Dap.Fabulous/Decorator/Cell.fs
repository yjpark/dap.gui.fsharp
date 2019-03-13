[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Cell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> Cell>
        (?backgroundColor : Color, ?update : 'widget -> unit) =
    inherit BaseDecorator<'widget> ()
    override __.Decorate (widget : 'widget) =
        //TODO
        ()

type Decorator
        (?backgroundColor : Color, ?update : Cell -> unit) =
    inherit Decorator<Cell>
        (?backgroundColor = backgroundColor, ?update = update)
