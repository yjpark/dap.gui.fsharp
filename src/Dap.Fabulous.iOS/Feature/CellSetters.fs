module Dap.Fabulous.iOS.Feature.CellSetters

open System
open System.Reflection

open Foundation
open CoreGraphics
open UIKit

open Xamarin.Forms
open Xamarin.Forms.Platform.iOS

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

// Xamarin.Forms.Platform.iOS/Cells/CellRenderer.cs
let mutable realCellProperty : BindableProperty option = None
let mutable initialized = false
let getRealCellProperty () : BindableProperty option =
    if not initialized then
        try
            let field : FieldInfo =
                typeof<CellRenderer> .GetField
                    ("RealCellProperty", BindingFlags.NonPublic ||| BindingFlags.Static)
            realCellProperty <- Some (field.GetValue () :?> BindableProperty)
        with e ->
            logException (getLogging ()) "CellSetters.getRealCellProperty" "Exception_Raised" (realCellProperty) e
        initialized <- true
    realCellProperty

let getRealCell (cell : BindableObject) =
    getRealCellProperty ()
    |> Option.bind (fun prop ->
        try
            Some (cell.GetValue (prop) :?> UITableViewCell)
        with e ->
            logException (getLogging ()) "CellSetters.getRealCell" "Exception_Raised" (cell, prop) e
            None
    )

type SwitchCellTextColorSetter (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.TextColorSetterKind)
    interface SwitchCell.ITextColorSetter with
        member this.SetTextColor (widget : SwitchCell) (textColor : Color) =
            getRealCell widget
            |> Option.iter (fun cell ->
                if cell =? null then
                    logError this "SetTextColor" "RealCell_Not_Found" (widget, textColor)
                else
                    cell.TextLabel.TextColor <- textColor.ToUIColor ()
            )
