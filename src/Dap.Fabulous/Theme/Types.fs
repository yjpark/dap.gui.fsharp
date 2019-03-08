[<AutoOpen>]
module Dap.Fabulous.Theme.Types

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Dap.Fabulous.Decorator

type FabulousColors = {
    Primary : Color
    Secondary : Color
    Background : Color
}

type FabulousTheme = {
    Colors : FabulousColors
}

type Theme with
    member this.WithFabulous (param : FabulousTheme) =
        // Views
        this.AddClassDecorator
            (new View.Decorator (backgroundColor = param.Colors.Background))
        this.AddClassDecorator
            (new Label.Decorator (textColor = param.Colors.Primary))
        // Cells
        this.AddClassDecorator
            (new Cell.Decorator (backgroundColor = param.Colors.Background))
        this.AddClassDecorator
            (new TextCell.Decorator (textColor = param.Colors.Primary, detailColor = param.Colors.Secondary))
        this.AddClassDecorator
            (new SwitchCell.Decorator (textColor = param.Colors.Primary))
        // Pages
        this.AddClassDecorator
            (new Page.Decorator (backgroundColor = param.Colors.Background))
        this
