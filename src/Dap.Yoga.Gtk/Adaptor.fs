module Dap.Yoga.Gtk.Adaptor

open System
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Yoga
open Dap.Gtk

type Adaptor (logging : ILogging) =
    inherit BaseAdaptor<Widget> (logging)
    let logger = logging.GetLogger "GtkYoga"
    override __.GetSize (widget : Widget) =
        ((float32) widget.AllocatedWidth, (float32) widget.AllocatedHeight)
    override __.MeasureSize (widget : Widget, constrainWidth : float32,  constrainHeight : float32) =
        let mutable constrainSize = new Gtk.Requisition ()
        constrainSize.Width <- (int) constrainWidth
        constrainSize.Height <- (int) constrainHeight
        let mutable result : Gtk.Requisition = Gtk.Requisition.Zero
        widget.GetPreferredSize (ref constrainSize, ref result)
        ((float32) result.Width, (float32) result.Height)
    override __.ApplyLayout (widget : Widget, node : YogaNode) =
        match widget.Parent with
        | :? Gtk.Fixed as container ->
            container.Move (widget, (int) node.LayoutX, (int) node.LayoutY)
        | _ ->
            logWarn logger "ApplyLayout" "Not_Support_Parent" (widget.Parent)
            ()
        widget.SetSizeRequest ((int) node.LayoutWidth, (int) node.LayoutHeight)