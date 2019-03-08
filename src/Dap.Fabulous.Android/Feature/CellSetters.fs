module Dap.Fabulous.Android.Feature.CellSetters

open System.Reflection

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Fabulous.Decorator
open Xamarin.Forms

// Xamarin.Forms.Platform.Android/Cells/CellRenderer.cs
// Xamarin.Forms.Platform.Android/Cells/SwitchCellRenderer.cs
let mutable rendererProperty : BindableProperty option = None
let mutable switchCellViewField : FieldInfo option = None
let mutable initialized = false

let getRendererProperty () : BindableProperty option =
    if not initialized then
        try
            let field : FieldInfo =
                typeof<CellRenderer> .GetField
                    ("RendererProperty", BindingFlags.NonPublic ||| BindingFlags.Static)
            rendererProperty <- Some (field.GetValue () :?> BindableProperty)
            let field =
                typeof<SwitchCellRenderer> .GetField
                    ("_view", BindingFlags.NonPublic ||| BindingFlags.Instance)
            switchCellViewField <- Some field
        with e ->
            logException (getLogging ()) "CellSetters.getRendererProperty" "Exception_Raised"
                (rendererProperty, switchCellViewField) e
        initialized <- true
    rendererProperty

let getRenderer<'renderer when 'renderer :> CellRenderer> (cell : BindableObject) : 'render option =
    getRendererProperty ()
    |> Option.bind (fun prop ->
        try
            Some (cell.GetValue prop :?> 'render)
        with e ->
            logException (getLogging ()) "CellSetters.getRenderer" "Exception_Raised" (rendererProperty) e
            None
    )

let getSwitchCellView (cell : BindableObject) : SwitchCellView option =
    getRenderer<SwitchCellRenderer> (cell)
    |> Option.bind (fun renderer ->
        switchCellViewField
        |> Option.bind (fun field ->
            try
                Some <| (field.GetValue renderer :?> SwitchCellView)
            with e ->
                logException (getLogging ()) "CellSetters.getSwitchCellView" "Exception_Raised" (cell, renderer, field) e
                None
        )
    )

type SwitchCellTextColorSetter (logging : ILogging) =
    inherit EmptyContext (logging, SwitchCell.TextColorSetterKind)
    interface SwitchCell.ITextColorSetter with
        member this.SetTextColor (widget : SwitchCell) (textColor : Color) =
            getSwitchCellView widget
            |> Option.iter (fun view ->
                if view =? null then
                    logError this "SetTextColor" "SwitchCellView_Not_Found" (widget, textColor)
                else
                    view.SetMainTextColor (textColor)
            )
