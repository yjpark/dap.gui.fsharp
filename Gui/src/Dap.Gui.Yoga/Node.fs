[<RequireQualifiedAccess>]
module Dap.Gui.Yoga.Node

open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Facebook.Yoga

type Builder () =
    member this.Yield (_ : 'a) = new YogaNode ()
    //YogaNode.cs
    [<CustomOperation("style_direction")>]
    member __.StyleDirection (target : YogaNode, v : YogaDirection) =
        target.StyleDirection <- v
        target
    [<CustomOperation("flex_direction")>]
    member __.FlexDirection (target : YogaNode, v : YogaFlexDirection) =
        target.FlexDirection <- v
        target
    [<CustomOperation("justify_content")>]
    member __.JustifyContent (target : YogaNode, v : YogaJustify) =
        target.JustifyContent <- v
        target
    [<CustomOperation("display")>]
    member __.Display (target : YogaNode, v : YogaDisplay) =
        target.Display <- v
        target
    [<CustomOperation("align_items")>]
    member __.AlignItems (target : YogaNode, v : YogaAlign) =
        target.AlignItems <- v
        target
    [<CustomOperation("align_self")>]
    member __.AlignSelf (target : YogaNode, v : YogaAlign) =
        target.AlignSelf <- v
        target
    [<CustomOperation("align_content")>]
    member __.AlignContent (target : YogaNode, v : YogaAlign) =
        target.AlignContent <- v
        target
    [<CustomOperation("position_type")>]
    member __.PositionType (target : YogaNode, v : YogaPositionType) =
        target.PositionType <- v
        target
    [<CustomOperation("wrap")>]
    member __.Wrap (target : YogaNode, v : YogaWrap) =
        target.Wrap <- v
        target
    [<CustomOperation("flex")>]
    member __.Flex (target : YogaNode, v : float32) =
        target.Flex <- v
        target
    [<CustomOperation("flex_grow")>]
    member __.FlexGrow (target : YogaNode, v : float32) =
        target.FlexGrow <- v
        target
    [<CustomOperation("flex_shrink")>]
    member __.FlexShrink (target : YogaNode, v : float32) =
        target.FlexShrink <- v
        target
    [<CustomOperation("flex_basis")>]
    member __.FlexBasis (target : YogaNode, v : YogaValue) =
        target.FlexBasis <- v
        target
    [<CustomOperation("width")>]
    member __.Width (target : YogaNode, v : YogaValue) =
        target.Width <- v
        target
    [<CustomOperation("max_width")>]
    member __.MaxWidth (target : YogaNode, v : YogaValue) =
        target.MaxWidth <- v
        target
    [<CustomOperation("min_width")>]
    member __.MinWidth (target : YogaNode, v : YogaValue) =
        target.MinWidth <- v
        target
    [<CustomOperation("height")>]
    member __.Height (target : YogaNode, v : YogaValue) =
        target.Height <- v
        target
    [<CustomOperation("max_height")>]
    member __.MaxHeight (target : YogaNode, v : YogaValue) =
        target.MaxHeight <- v
        target
    [<CustomOperation("min_height")>]
    member __.MinHeight (target : YogaNode, v : YogaValue) =
        target.MinHeight <- v
        target
    [<CustomOperation("aspect_ratio")>]
    member __.AspectRatio (target : YogaNode, v : float32) =
        target.AspectRatio <- v
        target
    [<CustomOperation("overflow")>]
    member __.Overflow (target : YogaNode, v : YogaOverflow) =
        target.Overflow <- v
        target
    [<CustomOperation("child")>]
    member __.Child (target : YogaNode, v : YogaNode) =
        target.AddChild v
        target
    //YogaNode.Spacing.cs
    [<CustomOperation("left")>]
    member __.Left (target : YogaNode, v : YogaValue) =
        target.Left <- v
        target
    [<CustomOperation("top")>]
    member __.Top (target : YogaNode, v : YogaValue) =
        target.Top <- v
        target
    [<CustomOperation("right")>]
    member __.Right (target : YogaNode, v : YogaValue) =
        target.Right <- v
        target
    [<CustomOperation("bottom")>]
    member __.Bottom (target : YogaNode, v : YogaValue) =
        target.Bottom <- v
        target
    [<CustomOperation("start")>]
    member __.Start (target : YogaNode, v : YogaValue) =
        target.Start <- v
        target
    [<CustomOperation("end")>]
    member __.End (target : YogaNode, v : YogaValue) =
        target.End <- v
        target
    [<CustomOperation("margin_left")>]
    member __.MarginLeft (target : YogaNode, v : YogaValue) =
        target.MarginLeft <- v
        target
    [<CustomOperation("margin_top")>]
    member __.MarginTop (target : YogaNode, v : YogaValue) =
        target.MarginTop <- v
        target
    [<CustomOperation("margin_right")>]
    member __.MarginRight (target : YogaNode, v : YogaValue) =
        target.MarginRight <- v
        target
    [<CustomOperation("margin_bottom")>]
    member __.MarginBottom (target : YogaNode, v : YogaValue) =
        target.MarginBottom <- v
        target
    [<CustomOperation("margin_start")>]
    member __.MarginStart (target : YogaNode, v : YogaValue) =
        target.MarginStart <- v
        target
    [<CustomOperation("margin_end")>]
    member __.MarginEnd (target : YogaNode, v : YogaValue) =
        target.MarginEnd <- v
        target
    [<CustomOperation("margin_horizontal")>]
    member __.MarginHorizontal (target : YogaNode, v : YogaValue) =
        target.MarginHorizontal <- v
        target
    [<CustomOperation("margin_vertical")>]
    member __.MarginVertical (target : YogaNode, v : YogaValue) =
        target.MarginVertical <- v
        target
    [<CustomOperation("margin")>]
    member __.Margin (target : YogaNode, v : YogaValue) =
        target.Margin <- v
        target
    [<CustomOperation("padding_left")>]
    member __.PaddingLeft (target : YogaNode, v : YogaValue) =
        target.PaddingLeft <- v
        target
    [<CustomOperation("padding_top")>]
    member __.PaddingTop (target : YogaNode, v : YogaValue) =
        target.PaddingTop <- v
        target
    [<CustomOperation("padding_right")>]
    member __.PaddingRight (target : YogaNode, v : YogaValue) =
        target.PaddingRight <- v
        target
    [<CustomOperation("padding_bottom")>]
    member __.PaddingBottom (target : YogaNode, v : YogaValue) =
        target.PaddingBottom <- v
        target
    [<CustomOperation("padding_start")>]
    member __.PaddingStart (target : YogaNode, v : YogaValue) =
        target.PaddingStart <- v
        target
    [<CustomOperation("padding_end")>]
    member __.PaddingEnd (target : YogaNode, v : YogaValue) =
        target.PaddingEnd <- v
        target
    [<CustomOperation("padding_horizontal")>]
    member __.PaddingHorizontal (target : YogaNode, v : YogaValue) =
        target.PaddingHorizontal <- v
        target
    [<CustomOperation("padding_vertical")>]
    member __.PaddingVertical (target : YogaNode, v : YogaValue) =
        target.PaddingVertical <- v
        target
    [<CustomOperation("padding")>]
    member __.Padding (target : YogaNode, v : YogaValue) =
        target.Padding <- v
        target
    [<CustomOperation("border_left_width")>]
    member __.BorderLeftWidth (target : YogaNode, v : float32) =
        target.BorderLeftWidth <- v
        target
    [<CustomOperation("border_top_width")>]
    member __.BorderTopWidth (target : YogaNode, v : float32) =
        target.BorderTopWidth <- v
        target
    [<CustomOperation("border_right_width")>]
    member __.BorderRightWidth (target : YogaNode, v : float32) =
        target.BorderRightWidth <- v
        target
    [<CustomOperation("border_bottom_width")>]
    member __.BorderBottomWidth (target : YogaNode, v : float32) =
        target.BorderBottomWidth <- v
        target
