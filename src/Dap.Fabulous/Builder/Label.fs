[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Label

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit View.Builder<Label> ()
    //SILP: FABULOUS_BUILDER_BUILD(Label)
    override __.Build (builder : AttributesBuilder) =                              //__SILP__
        ViewElement.Create<Label>                                                  //__SILP__
            (ViewBuilders.CreateFuncLabel, ViewBuilders.UpdateFuncLabel, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, string, Text, text)
    [<CustomOperation("text")>]                                       //__SILP__
    member __.Text (attributes : Attributes<Label>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, TextAlignment, HorizontalTextAlignment, horizontalTextAlignment)
    [<CustomOperation("horizontalTextAlignment")>]                                                                 //__SILP__
    member __.HorizontalTextAlignment (attributes : Attributes<Label>, horizontalTextAlignment : TextAlignment) =  //__SILP__
        attributes.With (ViewAttributes.HorizontalTextAlignmentAttribKey, horizontalTextAlignment)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, TextAlignment, VerticalTextAlignment, verticalTextAlignment)
    [<CustomOperation("verticalTextAlignment")>]                                                               //__SILP__
    member __.VerticalTextAlignment (attributes : Attributes<Label>, verticalTextAlignment : TextAlignment) =  //__SILP__
        attributes.With (ViewAttributes.VerticalTextAlignmentAttribKey, verticalTextAlignment)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, double, FontSize, fontSize)
    [<CustomOperation("fontSize")>]                                           //__SILP__
    member __.FontSize (attributes : Attributes<Label>, fontSize : double) =  //__SILP__
        attributes.With (ViewAttributes.FontSizeAttribKey, fontSize)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, string, FontFamily, fontFamily)
    [<CustomOperation("fontFamily")>]                                             //__SILP__
    member __.FontFamily (attributes : Attributes<Label>, fontFamily : string) =  //__SILP__
        attributes.With (ViewAttributes.FontFamilyAttribKey, fontFamily)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, FontAttributes, FontAttributes, fontAttributes)
    [<CustomOperation("fontAttributes")>]                                                         //__SILP__
    member __.FontAttributes (attributes : Attributes<Label>, fontAttributes : FontAttributes) =  //__SILP__
        attributes.With (ViewAttributes.FontAttributesAttribKey, fontAttributes)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, Color, TextColor, textColor)
    [<CustomOperation("textColor")>]                                           //__SILP__
    member __.TextColor (attributes : Attributes<Label>, textColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.TextColorAttribKey, textColor)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, ViewElement, FormattedText, formattedText)
    [<CustomOperation("formattedText")>]                                                     //__SILP__
    member __.FormattedText (attributes : Attributes<Label>, formattedText : ViewElement) =  //__SILP__
        attributes.With (ViewAttributes.FormattedTextAttribKey, formattedText)               //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, LineBreakMode, LineBreakMode, lineBreakMode)
    [<CustomOperation("lineBreakMode")>]                                                       //__SILP__
    member __.LineBreakMode (attributes : Attributes<Label>, lineBreakMode : LineBreakMode) =  //__SILP__
        attributes.With (ViewAttributes.LineBreakModeAttribKey, lineBreakMode)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, double, LineHeight, lineHeight)
    [<CustomOperation("lineHeight")>]                                             //__SILP__
    member __.LineHeight (attributes : Attributes<Label>, lineHeight : double) =  //__SILP__
        attributes.With (ViewAttributes.LineHeightAttribKey, lineHeight)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, int, MaxLines, maxLines)
    [<CustomOperation("maxLines")>]                                        //__SILP__
    member __.MaxLines (attributes : Attributes<Label>, maxLines : int) =  //__SILP__
        attributes.With (ViewAttributes.MaxLinesAttribKey, maxLines)       //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Label, TextDecorations, TextDecorations, textDecorations)
    [<CustomOperation("textDecorations")>]                                                           //__SILP__
    member __.TextDecorations (attributes : Attributes<Label>, textDecorations : TextDecorations) =  //__SILP__
        attributes.With (ViewAttributes.TextDecorationsAttribKey, textDecorations)                   //__SILP__
