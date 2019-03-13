[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Cell

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> Cell>
        (?update : 'widget -> unit, ?backgroundColor : Color) =
    inherit Element.Decorator<'widget> (?update = update)
    override __.Decorate (widget : 'widget) =
        base.Decorate widget

type Decorator
        (?update : Cell -> unit, ?backgroundColor : Color) =
    inherit Decorator<Cell>
        (?update = update, ?backgroundColor = backgroundColor)
