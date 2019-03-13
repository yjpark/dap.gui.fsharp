[<AutoOpen>]
module Dap.Fabulous.Theme

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous.Palette
open Dap.Fabulous.Decorator

type ITheme with
    member this.AddFabulousColorScheme
            (param : Dap.Fabulous.Palette.Types.ColorScheme,
                ?forNavigationBar : bool) =
        // Views
        this.AddClassDecorator
            (new View.Decorator
                (backgroundColor = param.Background))
        this.AddClassDecorator
            (new Label.Decorator
                (textColor = param.Label.Normal, ?backgroundColor = param.Label.Surface))
        this.AddClassDecorator
            (new Button.Decorator
                (textColor = param.Button.Normal, ?backgroundColor = param.Button.Surface))
        // Cells
        this.AddClassDecorator
            (new Cell.Decorator
                (backgroundColor = param.Background))
        this.AddClassDecorator
            (new TextCell.Decorator
                (textColor = param.Label.Normal, ?detailColor = param.Label.Dimmed, ?backgroundColor = param.Label.Surface))
        this.AddClassDecorator
            (new SwitchCell.Decorator
                (textColor = param.Switch.Normal, ?onColor = param.Switch.Accent, ?backgroundColor = param.Switch.Surface))
        // Custom Cells
        this.AddClassDecorator
            (new TextActionCell.Decorator
                (textColor = param.Label.Normal, ?detailColor = param.Label.Dimmed, ?backgroundColor = param.Label.Surface,
                actionColor = param.Button.Normal, ?actionSelectedColor = param.Button.Accent,
                    ?actionDisabledColor = param.Button.Dimmed, ?actionBackgroundColor = param.Button.Surface))
        // Pages
        this.AddClassDecorator
            (new Page.Decorator
                (backgroundColor = param.Background))
        if defaultArg forNavigationBar true then
            this.AddClassDecorator
                (new NavigationPage.Decorator
                    (barTextColor = param.Panel.Normal, ?barBackgroundColor = param.Panel.Surface, barActionColor = param.Button.Normal))
