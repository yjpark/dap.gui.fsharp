module Dap.Eto.Yoga.Adaptor

open Eto.Drawing
open Eto.Forms
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Yoga

let private tryFindPositionHandler (widget : Control) =
    match widget.Handler with
    | :? Eto.Forms.Layout.IPositionalLayoutHandler as handler -> Some handler
    | _ ->
        match widget.Parent with
        | null -> None
        | parent ->
            match parent.Handler with
            | :? Eto.Forms.Layout.IPositionalLayoutHandler as handler -> Some handler
            | _ -> None

type EtoAdaptor (logging : ILogging) =
    inherit BaseAdaptor<Control> (logging)
    override __.GetSize (widget : Control) =
        ((float32) widget.Width, (float32) widget.Height)
    override __.MeasureSize (widget : Control, constrainWidth : float32,  constrainHeight : float32) =
        //TODO
        (constrainWidth, constrainHeight)
    override __.ApplyLayout (widget : Control, node : YogaNode) =
        let width = node.LayoutWidth
        let height = node.LayoutHeight
        widget.Size <- new Size((int) width, (int) height)
        tryFindPositionHandler widget
        |> Option.iter (fun handler ->
            //TODO
            ()
        )