[<RequireQualifiedAccess>]
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
    member __.Logger =
        if logger.IsNone then
            logger <- Some <| (getLogging ()) .GetLogger ("TextActionCell.Renderer")
        logger.Value
    member this.GetActionButton (tvc : CellTableViewCell) =
        match tvc.AccessoryView with
        | :? UIButton as button -> Some button
        | _ -> None
    member this.UpdateForAlllStates (update : UIControlState -> unit) =
        update UIControlState.Normal
        update UIControlState.Highlighted
        update UIControlState.Disabled
        update UIControlState.Selected
    member this.UpdateActionEnabled (cell : TextActionCell) (button : UIButton) =
        button.Enabled <- cell.ActionEnabled
    member this.UpdateAction (cell : TextActionCell) (button : UIButton) =
        button.SetTitle (cell.Action, UIControlState.Normal)
        button.SizeToFit ()
    member this.UpdateActionColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionColor.ToUIColor (), UIControlState.Normal)
    member this.UpdateActionPressedColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionPressedColor.ToUIColor (), UIControlState.Highlighted)
    member this.UpdateActionDisabledColor (cell : TextActionCell) (button : UIButton) =
        button.SetTitleColor (cell.ActionDisabledColor.ToUIColor (), UIControlState.Disabled)
    member this.UpdateActionBackgroundColor (cell : TextActionCell) (button : UIButton) =
        button.BackgroundColor <- cell.ActionBackgroundColor.ToUIColor ()
    member this.UpdateActionButton (cell : TextActionCell) (button : UIButton) =
        this.UpdateActionEnabled cell button
        this.UpdateAction cell button
        this.UpdateActionColor cell button
        this.UpdateActionPressedColor cell button
        this.UpdateActionDisabledColor cell button
        this.UpdateActionBackgroundColor cell button
    override this.GetCell (item : Cell, reusableCell : UITableViewCell, tv : UITableView) : UITableViewCell =
        let cell = item :?> TextActionCell
        let tvc = base.GetCell (item, reusableCell, tv) :?> CellTableViewCell
        //TODO: Reuse button when figured out how to remove old handler
        let button = new UIButton ()
        tvc.AccessoryView <- button
        button.TouchUpInside.Add (fun _ ->
            if cell.ActionEnabled then
                cell.FireOnAction ()
        )
        this.UpdateActionButton cell button
        tvc :> UITableViewCell
    override this.HandleCellPropertyChanged (sender : obj, args : PropertyChangedEventArgs) =
        base.HandleCellPropertyChanged (sender, args)
        let cell = sender :?> TextActionCell
        let tvc =
            Dap.Fabulous.iOS.Decorator.Cell.getRealCell this.Logger cell
            |> Option.get
            :?> CellTableViewCell
        this.GetActionButton tvc
        |> Option.iter (fun button ->
            let prop = args.PropertyName
            if prop = TextActionCell.ActionEnabledProperty.PropertyName then
                this.UpdateActionEnabled cell button
            elif prop = TextActionCell.ActionProperty.PropertyName then
                this.UpdateAction cell button
            elif prop = TextActionCell.ActionColorProperty.PropertyName then
                this.UpdateActionColor cell button
            elif prop = TextActionCell.ActionPressedColorProperty.PropertyName then
                this.UpdateActionPressedColor cell button
            elif prop = TextActionCell.ActionDisabledColorProperty.PropertyName then
                this.UpdateActionDisabledColor cell button
            elif prop = TextActionCell.ActionBackgroundColorProperty.PropertyName then
                this.UpdateActionBackgroundColor cell button
        )
