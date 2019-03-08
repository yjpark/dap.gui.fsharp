[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Cell

open Xamarin.Forms
open Fabulous.Core

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Decorator<'widget when 'widget :> Cell>
        (?backgroundColor : Color) =
    inherit BaseDecorator<'widget> ()
    override __.Decorate (widget : 'widget) =
        //TODO
        ()

type Decorator
        (?backgroundColor : Color) =
    inherit Decorator<Cell>
        (?backgroundColor = backgroundColor)
