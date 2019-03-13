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
open Dap.Mac

type Renderer () =
    inherit TextCellRenderer ()
    static let mutable logger : ILogger option = None
    let updateButton (tvc : NSView) (update : NSButton -> unit) =
        ()
        (*
        match tvc.AccessoryView.Subviews[0] with
        | :? NSButton as button -> update button
        | _ -> ()
        *)
    static member Logger =
        if logger.IsNone then
            logger <- Some <| (getLogging ()) .GetLogger ("TextActionCell.Renderer")
        logger.Value
    override __.GetCell (item : Cell, reusableCell : NSView, tv : NSTableView) : NSView =
        let cell = item :?> TextActionCell
        let tvc = base.GetCell (item, reusableCell, tv)
        logWip Renderer.Logger "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" (cell, tvc)
        (*
        let button =
            match tvc.AccessoryView with
            | :? NSButton as button -> button
            | _ ->
                let button = new NSButton ()
                button.LineBreakMode <- UILineBreakMode.TailTruncation
                button.TouchUpInside.Add (fun _ ->
                    cell.FireOnAction ()
                )
                tvc.AccessoryView <- button
                button
        button.Enabled <- cell.ActionEnabled
        button.TitleLabel.Text <- cell.Action
        button.TitleLabel.TextColor <- cell.ActionColor.ToUIColor ()
        button.BackgroundColor <- cell.ActionBackgroundColor.ToUIColor ()
        *)
        tvc
    (*
    override __.HandleCellPropertyChanged (sender : obj, args : PropertyChangedEventArgs) =
        base.HandleCellPropertyChanged (sender, args)
        let cell = sender :?> TextActionCell
        let tvc =
            Dap.Fabulous.Mac.Feature.Decorator.Cell.getRealCell Renderer.Logger cell
            |> Option.get
            :?> CellNSView
        let prop = args.PropertyName
        if prop = TextActionCell.ActionEnabledProperty.PropertyName then
            updateButton tvc (fun button ->
                button.Enabled <- cell.ActionEnabled
            )
        elif prop = TextActionCell.ActionProperty.PropertyName then
            updateButton tvc (fun button ->
                button.TitleLabel.Text <- cell.Action
            )
        elif prop = TextActionCell.ActionColorProperty.PropertyName then
            updateButton tvc (fun button ->
                button.TitleLabel.TextColor <- cell.ActionColor.ToUIColor ()
            )
        elif prop = TextActionCell.ActionBackgroundColorProperty.PropertyName then
            updateButton tvc (fun button ->
                button.BackgroundColor <- cell.ActionBackgroundColor.ToUIColor ()
            )
    *)
