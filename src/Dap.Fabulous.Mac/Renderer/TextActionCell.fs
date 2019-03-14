[<AutoOpen>]
module Dap.Fabulous.Mac.Renderer.TextActionCell

open System.ComponentModel

open Foundation
open CoreGraphics
open AppKit

open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Fabulous.Controls

type Model = {
    Cell : TextActionCell
    View : NSStackView
    Button : NSButton
}

type Renderer () =
    inherit TextCellRenderer ()
    static let mutable logger : ILogger option = None
    let mutable model : Model option = None
    member __.Logger =
        if logger.IsNone then
            logger <- Some <| (getLogging ()) .GetLogger ("TextActionCell.Renderer")
        logger.Value
    member __.Cell = model.Value.Cell
    member __.Button = model.Value.Button
    member this.UpdateActionEnabled () =
        this.Button.Enabled <- this.Cell.ActionEnabled
    member this.UpdateActionText () =
        let color = this.GetActionColor ()
        if color = Color.Default then
            this.Button.Title <- this.Cell.Action
        else
            let textWithColor =
                new NSAttributedString (
                    this.Cell.Action,
                    foregroundColor = color.ToNSColor(),
                    paragraphStyle = new NSMutableParagraphStyle (Alignment = NSTextAlignment.Center)
                )
            this.Button.AttributedTitle <- textWithColor
    member this.GetActionColor () =
        this.Cell.ActionColor
    member this.UpdateActionBackgroundColor () =
        this.Button.Cell.BackgroundColor <- this.Cell.ActionBackgroundColor.ToNSColor ()
    member this.UpdateActionButton () =
        this.UpdateActionEnabled ()
        this.UpdateActionText ()
        this.UpdateActionBackgroundColor ()
    member this.CreateModel (cell : TextActionCell, tvc : NSView) =
        let view = new NSStackView ()
        view.Orientation <- NSUserInterfaceLayoutOrientation.Horizontal
        view.AddArrangedSubview (tvc)
        let button = new NSButton ()
        button.Activated.Add (fun _ ->
            cell.FireOnAction ()
        )
        view.SetViews([| button |], NSStackViewGravity.Trailing)
        view.AddArrangedSubview (button)
        {
            Cell = cell
            View = view
            Button = button
        }
    override this.GetCell (item : Cell, reusableCell : NSView, tv : NSTableView) : NSView =
        let cell = item :?> TextActionCell
        let tvc = base.GetCell (item, reusableCell, tv)
        if model.IsNone then
            model <- Some <| this.CreateModel (cell, tvc)
        this.UpdateActionButton ()
        model.Value.View :> NSView
    override this.HandlePropertyChanged (sender : obj, args : PropertyChangedEventArgs) =
        base.HandlePropertyChanged (sender, args)
        model
        |> Option.iter (fun _model ->
            let prop = args.PropertyName
            if prop = TextActionCell.ActionEnabledProperty.PropertyName then
                this.UpdateActionEnabled ()
            elif prop = TextActionCell.ActionProperty.PropertyName
                    || prop = TextActionCell.ActionColorProperty.PropertyName
                    || prop = TextActionCell.ActionPressedColorProperty.PropertyName
                    || prop = TextActionCell.ActionDisabledColorProperty.PropertyName
                    then
                this.UpdateActionText ()
            elif prop = TextActionCell.ActionBackgroundColorProperty.PropertyName then
                this.UpdateActionBackgroundColor ()
        )