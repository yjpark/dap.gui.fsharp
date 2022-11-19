module Dap.Yoga.Mac.Adaptor

open System
open Foundation
open CoreGraphics
open AppKit

open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Yoga

type Adaptor (logging : ILogging) =
    inherit BaseAdaptor<Widget> (logging)
    let logger = logging.GetLogger "MacYoga"
    override __.GetSize (widget : Widget) =
        ((float32) widget.Frame.Width, (float32) widget.Frame.Height)
    override __.MeasureSize (widget : Widget, constrainWidth : float32,  constrainHeight : float32) =
        // https://github.com/facebook/yoga/issues/589
        let sizeThatFits = widget.FittingSize
        (min ((float32) sizeThatFits.Width) constrainWidth, min ((float32) sizeThatFits.Height) constrainHeight)
    override __.ApplyLayout (widget : Widget, node : YogaNode) =
        widget.Frame <- new CGRect (node.LayoutX, node.LayoutY, node.LayoutWidth, node.LayoutHeight);
