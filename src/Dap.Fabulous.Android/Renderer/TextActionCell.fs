[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Renderer.TextActionCell

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Android
open Dap.Fabulous
open Dap.Fabulous.Controls

type AButton = Android.Widget.Button
type AMotionEvent = Android.Views.MotionEvent
type AMotionEventActions = Android.Views.MotionEventActions

type OnClickListener (cell : TextActionCell) =
    inherit JavaObject ()
    interface AView.IOnClickListener with
        member this.OnClick view =
            cell.FireOnAction ()

type OnTouchListener (cell : TextActionCell, setPressed : bool -> unit) =
    inherit JavaObject ()
    interface AView.IOnTouchListener with
        member this.OnTouch (view : AView, evt : AMotionEvent) =
            if evt.Action = AMotionEventActions.Down then
                setPressed true
            elif evt.Action = AMotionEventActions.Up then
                setPressed false
            false

type CellView (cell : TextActionCell, renderer : CellRenderer, context : AContext) =
    inherit TextCellView<TextActionCell> (cell, renderer, context)
    let button = new AButton (context)
    let mutable pressed : bool = false
    do (
        base.SetAccessoryView button
    )
    member this.SetPressed (pressed' : bool) =
        pressed <- pressed'
        this.UpdateActionColor ()
    member __.UpdateAction () =
        button.Text <- cell.Action
    member __.UpdateActionColor () =
        let color =
            if not cell.IsEnabled then
                cell.ActionDisabledColor
            elif pressed then
                cell.ActionPressedColor
            else
                cell.ActionColor
        button.SetTextColor (color.ToAndroid ())
    member __.UpdateActionBackgroundColor () =
        button.SetBackgroundColor (cell.ActionBackgroundColor.ToAndroid ())
    override this.DoUpdate () =
        base.DoUpdate ()
        this.UpdateAction ()
        this.UpdateActionColor ()
        this.UpdateActionBackgroundColor ()
        button.SetOnClickListener (new OnClickListener (cell))
        button.SetOnTouchListener (new OnTouchListener (cell, this.SetPressed))
    override this.OnCellPropertyChanged prop =
        base.OnCellPropertyChanged prop
        if prop = TextActionCell.ActionProperty.PropertyName then
            this.UpdateAction ()
        elif prop = TextActionCell.ActionColorProperty.PropertyName
                || prop = TextActionCell.ActionPressedColorProperty.PropertyName
                || prop = TextActionCell.ActionDisabledColorProperty.PropertyName
                || prop = Cell.IsEnabledProperty.PropertyName
                then
            this.UpdateActionColor ()
        elif prop = TextActionCell.ActionBackgroundColorProperty.PropertyName then
            this.UpdateActionBackgroundColor ()
