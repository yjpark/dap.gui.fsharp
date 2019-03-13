[<AutoOpen>]
module Dap.Fabulous.iOS.Renderer.TextActionCell

open System.ComponentModel

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Fabulous.Controls

type Renderer () =
    inherit TextCellRenderer ()
    static let mutable logger : ILogger option = None
    let getActionButton (tvc : CellTableViewCell) =
        match tvc.AccessoryView with
        | :? UIButton as button -> Some button
        | _ -> None
    let updateForAlllStates (update : UIControlState -> unit) =
        update UIControlState.Normal
        update UIControlState.Highlighted
        update UIControlState.Disabled
        update UIControlState.Selected
    let updateActionEnabled (cell : TextActionCell) (button : UIButton) =
        button.Enabled <- cell.ActionEnabled
    let updateAction (cell : TextActionCell) (button : UIButton) =
        button.SetTitle (cell.Action, UIControlState.Normal)
        button.SizeToFit ()
    let updateActionColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionColor.ToUIColor (), UIControlState.Normal)
    let updateActionPressedColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionPressedColor.ToUIColor (), UIControlState.Highlighted)
    let updateActionDisabledColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionDisabledColor.ToUIColor (), UIControlState.Disabled)
    let updateActionBackgroundColor (cell : TextActionCell) (button : UIButton) =
        button.BackgroundColor <- cell.ActionBackgroundColor.ToUIColor ()
    let updateActionButton (cell : TextActionCell) (button : UIButton) =
        updateActionEnabled cell button
        updateAction cell button
        updateActionColor cell button
        updateActionPressedColor cell button
        updateActionDisabledColor cell button
        updateActionBackgroundColor cell button
    static member Logger =
        if logger.IsNone then
            logger <- Some <| (getLogging ()) .GetLogger ("TextActionCell.Renderer")
        logger.Value
    override __.GetCell (item : Cell, reusableCell : UITableViewCell, tv : UITableView) : UITableViewCell =
        let cell = item :?> TextActionCell
        let tvc = base.GetCell (item, reusableCell, tv) :?> CellTableViewCell
        let button =
            match tvc.AccessoryView with
            | :? UIButton as button -> button
            | _ ->
                let button = new UIButton ()
                button.TitleLabel.BackgroundColor <- button.BackgroundColor;
                button.TouchUpInside.Add (fun _ ->
                    if cell.ActionEnabled then
                        cell.FireOnAction ()
                )
                tvc.AccessoryView <- button
                button
        updateActionButton cell button
        tvc :> UITableViewCell
    override __.HandleCellPropertyChanged (sender : obj, args : PropertyChangedEventArgs) =
        base.HandleCellPropertyChanged (sender, args)
        let cell = sender :?> TextActionCell
        let tvc =
            Dap.Fabulous.iOS.Decorator.Cell.getRealCell Renderer.Logger cell
            |> Option.get
            :?> CellTableViewCell
        getActionButton tvc
        |> Option.iter (fun button ->
            let prop = args.PropertyName
            if prop = TextActionCell.ActionEnabledProperty.PropertyName then
                updateActionEnabled cell button
            elif prop = TextActionCell.ActionProperty.PropertyName then
                updateAction cell button
            elif prop = TextActionCell.ActionColorProperty.PropertyName then
                updateActionColor cell button
            elif prop = TextActionCell.ActionPressedColorProperty.PropertyName then
                updateActionPressedColor cell button
            elif prop = TextActionCell.ActionDisabledColorProperty.PropertyName then
                updateActionDisabledColor cell button
            elif prop = TextActionCell.ActionBackgroundColorProperty.PropertyName then
                updateActionBackgroundColor cell button
        )
