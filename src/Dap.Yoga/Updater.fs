[<RequireQualifiedAccess>]
module Dap.Yoga.Updater

open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Facebook.Yoga

type YogaUpdater () =
    let mutable updates : (YogaNode -> unit) list = []
    member __.Add (update : YogaNode -> unit) =
        updates <- update :: updates
    interface IYogaUpdater with
        member __.Update node =
            updates
            |> List.rev
            |> List.iter( fun update -> update node)

type Builder () =
    member __.Zero () = new YogaUpdater ()
    member this.Yield (_ : 'a) = this.Zero ()
    //YogaUpdater.cs
    [<CustomOperation("style_direction")>]
    member __.StyleDirection (target : YogaUpdater, v : YogaDirection) =
        target.Add (fun node -> node.StyleDirection <- v)
        target
    [<CustomOperation("flex_direction")>]
    member __.FlexDirection (target : YogaUpdater, v : YogaFlexDirection) =
        target.Add (fun node -> node.FlexDirection <- v)
        target
    [<CustomOperation("justify_content")>]
    member __.JustifyContent (target : YogaUpdater, v : YogaJustify) =
        target.Add (fun node -> node.JustifyContent <- v)
        target
    [<CustomOperation("display")>]
    member __.Display (target : YogaUpdater, v : YogaDisplay) =
        target.Add (fun node -> node.Display <- v)
        target
    [<CustomOperation("align_items")>]
    member __.AlignItems (target : YogaUpdater, v : YogaAlign) =
        target.Add (fun node -> node.AlignItems <- v)
        target
    [<CustomOperation("align_self")>]
    member __.AlignSelf (target : YogaUpdater, v : YogaAlign) =
        target.Add (fun node -> node.AlignSelf <- v)
        target
    [<CustomOperation("align_content")>]
    member __.AlignContent (target : YogaUpdater, v : YogaAlign) =
        target.Add (fun node -> node.AlignContent <- v)
        target
    [<CustomOperation("position_type")>]
    member __.PositionType (target : YogaUpdater, v : YogaPositionType) =
        target.Add (fun node -> node.PositionType <- v)
        target
    [<CustomOperation("wrap")>]
    member __.Wrap (target : YogaUpdater, v : YogaWrap) =
        target.Add (fun node -> node.Wrap <- v)
        target
    [<CustomOperation("flex")>]
    member __.Flex (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.Flex <- v)
        target
    [<CustomOperation("flex_grow")>]
    member __.FlexGrow (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.FlexGrow <- v)
        target
    [<CustomOperation("flex_shrink")>]
    member __.FlexShrink (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.FlexShrink <- v)
        target
    [<CustomOperation("flex_basis")>]
    member __.FlexBasis (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.FlexBasis <- v)
        target
    [<CustomOperation("width")>]
    member __.Width (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Width <- v)
        target
    [<CustomOperation("max_width")>]
    member __.MaxWidth (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MaxWidth <- v)
        target
    [<CustomOperation("min_width")>]
    member __.MinWidth (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MinWidth <- v)
        target
    [<CustomOperation("height")>]
    member __.Height (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Height <- v)
        target
    [<CustomOperation("max_height")>]
    member __.MaxHeight (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MaxHeight <- v)
        target
    [<CustomOperation("min_height")>]
    member __.MinHeight (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MinHeight <- v)
        target
    [<CustomOperation("aspect_ratio")>]
    member __.AspectRatio (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.AspectRatio <- v)
        target
    [<CustomOperation("overflow")>]
    member __.Overflow (target : YogaUpdater, v : YogaOverflow) =
        target.Add (fun node -> node.Overflow <- v)
        target
    //YogaUpdater.Spacing.cs
    [<CustomOperation("left")>]
    member __.Left (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Left <- v)
        target
    [<CustomOperation("top")>]
    member __.Top (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Top <- v)
        target
    [<CustomOperation("right")>]
    member __.Right (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Right <- v)
        target
    [<CustomOperation("bottom")>]
    member __.Bottom (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Bottom <- v)
        target
    [<CustomOperation("start")>]
    member __.Start (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Start <- v)
        target
    [<CustomOperation("end")>]
    member __.End (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.End <- v)
        target
    [<CustomOperation("margin_left")>]
    member __.MarginLeft (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginLeft <- v)
        target
    [<CustomOperation("margin_top")>]
    member __.MarginTop (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginTop <- v)
        target
    [<CustomOperation("margin_right")>]
    member __.MarginRight (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginRight <- v)
        target
    [<CustomOperation("margin_bottom")>]
    member __.MarginBottom (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginBottom <- v)
        target
    [<CustomOperation("margin_start")>]
    member __.MarginStart (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginStart <- v)
        target
    [<CustomOperation("margin_end")>]
    member __.MarginEnd (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginEnd <- v)
        target
    [<CustomOperation("margin_horizontal")>]
    member __.MarginHorizontal (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginHorizontal <- v)
        target
    [<CustomOperation("margin_vertical")>]
    member __.MarginVertical (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.MarginVertical <- v)
        target
    [<CustomOperation("margin")>]
    member __.Margin (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Margin <- v)
        target
    [<CustomOperation("padding_left")>]
    member __.PaddingLeft (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingLeft <- v)
        target
    [<CustomOperation("padding_top")>]
    member __.PaddingTop (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingTop <- v)
        target
    [<CustomOperation("padding_right")>]
    member __.PaddingRight (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingRight <- v)
        target
    [<CustomOperation("padding_bottom")>]
    member __.PaddingBottom (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingBottom <- v)
        target
    [<CustomOperation("padding_start")>]
    member __.PaddingStart (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingStart <- v)
        target
    [<CustomOperation("padding_end")>]
    member __.PaddingEnd (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingEnd <- v)
        target
    [<CustomOperation("padding_horizontal")>]
    member __.PaddingHorizontal (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingHorizontal <- v)
        target
    [<CustomOperation("padding_vertical")>]
    member __.PaddingVertical (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.PaddingVertical <- v)
        target
    [<CustomOperation("padding")>]
    member __.Padding (target : YogaUpdater, v : YogaValue) =
        target.Add (fun node -> node.Padding <- v)
        target
    [<CustomOperation("border_left_width")>]
    member __.BorderLeftWidth (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.BorderLeftWidth <- v)
        target
    [<CustomOperation("border_top_width")>]
    member __.BorderTopWidth (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.BorderTopWidth <- v)
        target
    [<CustomOperation("border_right_width")>]
    member __.BorderRightWidth (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.BorderRightWidth <- v)
        target
    [<CustomOperation("border_bottom_width")>]
    member __.BorderBottomWidth (target : YogaUpdater, v : float32) =
        target.Add (fun node -> node.BorderBottomWidth <- v)
        target
