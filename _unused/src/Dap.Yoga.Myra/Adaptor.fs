module Dap.Yoga.Myra.Adaptor

open System
open Microsoft.Xna.Framework;
open Myra
open Myra.Graphics2D.UI
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Yoga
open Dap.Myra

type Adaptor (logging : ILogging) =
    inherit BaseAdaptor<Widget> (logging)
    override __.GetSize (widget : Widget) =
        ((float32) widget.Bounds.Width, (float32) widget.Bounds.Height)
    override __.MeasureSize (widget : Widget, constrainWidth : float32,  constrainHeight : float32) =
        let result = widget.Measure (new Point ((int) constrainWidth, (int) constrainHeight))
        ((float32) result.X, (float32) result.Y)
    override __.ApplyLayout (widget : Widget, node : YogaNode) =
        widget.Left <- (int) node.LayoutX
        widget.Top <- (int) node.LayoutY
        widget.Width <- Nullable <| (int) node.LayoutWidth
        widget.Height <- Nullable <| (int) node.LayoutHeight
