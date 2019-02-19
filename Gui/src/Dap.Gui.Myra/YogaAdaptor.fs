module Dap.Gui.Myra.YogaAdaptor

open System
open Microsoft.Xna.Framework;
open Myra
open Myra.Graphics2D.UI
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui.Yoga

type Adaptor (logging : ILogging) =
    inherit BaseAdaptor<MyraWidget> (logging)
    override __.GetSize (widget : MyraWidget) =
        ((float32) widget.Bounds.Width, (float32) widget.Bounds.Height)
    override __.MeasureSize (widget : MyraWidget, constrainWidth : float32,  constrainHeight : float32) =
        let result = widget.Measure (new Point ((int) constrainWidth, (int) constrainHeight))
        ((float32) result.X, (float32) result.Y)
    override __.ApplyLayout (widget : MyraWidget, node : YogaNode) =
        widget.Left <- (int) node.LayoutX
        widget.Top <- (int) node.LayoutY
        widget.Width <- Nullable <| (int) node.LayoutWidth
        widget.Height <- Nullable <| (int) node.LayoutHeight
