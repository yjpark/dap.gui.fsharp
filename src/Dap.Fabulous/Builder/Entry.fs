[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Entry

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit InputView.Builder<Entry> ()
    //SILP: FABULOUS_BUILDER_BUILD(Entry)
    override __.Build (builder : AttributesBuilder) =                              //__SILP__
        ViewElement.Create<Entry>                                                  //__SILP__
            (ViewBuilders.CreateFuncEntry, ViewBuilders.UpdateFuncEntry, builder)  //__SILP__
    [<CustomOperation("completed")>]
    member __.Completed (attributes : Attributes<Entry>, completed : string -> unit) =
        attributes.With (ViewAttributes.EntryCompletedAttribKey, (fun f ->
            System.EventHandler (fun sender _args -> f (sender :?> Xamarin.Forms.Entry).Text)) (completed))
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, string, Text, text)
    [<CustomOperation("text")>]                                       //__SILP__
    member __.Text (attributes : Attributes<Entry>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, string, Placeholder, placeholder)
    [<CustomOperation("placeholder")>]                                              //__SILP__
    member __.Placeholder (attributes : Attributes<Entry>, placeholder : string) =  //__SILP__
        attributes.With (ViewAttributes.PlaceholderAttribKey, placeholder)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, TextAlignment, HorizontalTextAlignment, horizontalTextAlignment)
    [<CustomOperation("horizontalTextAlignment")>]                                                                 //__SILP__
    member __.HorizontalTextAlignment (attributes : Attributes<Entry>, horizontalTextAlignment : TextAlignment) =  //__SILP__
        attributes.With (ViewAttributes.HorizontalTextAlignmentAttribKey, horizontalTextAlignment)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, double, FontSize, fontSize)
    [<CustomOperation("fontSize")>]                                           //__SILP__
    member __.FontSize (attributes : Attributes<Entry>, fontSize : double) =  //__SILP__
        attributes.With (ViewAttributes.FontSizeAttribKey, fontSize)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, string, FontFamily, fontFamily)
    [<CustomOperation("fontFamily")>]                                             //__SILP__
    member __.FontFamily (attributes : Attributes<Entry>, fontFamily : string) =  //__SILP__
        attributes.With (ViewAttributes.FontFamilyAttribKey, fontFamily)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, FontAttributes, FontAttributes, fontAttributes)
    [<CustomOperation("fontAttributes")>]                                                         //__SILP__
    member __.FontAttributes (attributes : Attributes<Entry>, fontAttributes : FontAttributes) =  //__SILP__
        attributes.With (ViewAttributes.FontAttributesAttribKey, fontAttributes)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, Color, TextColor, textColor)
    [<CustomOperation("textColor")>]                                           //__SILP__
    member __.TextColor (attributes : Attributes<Entry>, textColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.TextColorAttribKey, textColor)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, Color, PlaceholderColor, placeholderColor)
    [<CustomOperation("placeholderColor")>]                                                  //__SILP__
    member __.PlaceholderColor (attributes : Attributes<Entry>, placeholderColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.PlaceholderColorAttribKey, placeholderColor)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, bool, IsPassword, isPassword)
    [<CustomOperation("isPassword")>]                                           //__SILP__
    member __.IsPassword (attributes : Attributes<Entry>, isPassword : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsPasswordAttribKey, isPassword)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(Entry, TextChangedEventArgs, TextChanged, textChanged)
    [<CustomOperation("textChanged")>]                                                                    //__SILP__
    member __.TextChanged (attributes : Attributes<Entry>, textChanged : TextChangedEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.TextChangedAttribKey, (fun f ->                                   //__SILP__
            System.EventHandler<TextChangedEventArgs> (fun _sender args -> f args)) (textChanged))        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, bool, IsTextPredictionEnabled, isTextPredictionEnabled)
    [<CustomOperation("isTextPredictionEnabled")>]                                                        //__SILP__
    member __.IsTextPredictionEnabled (attributes : Attributes<Entry>, isTextPredictionEnabled : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsTextPredictionEnabledAttribKey, isTextPredictionEnabled)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, ReturnType, ReturnType, returnType)
    [<CustomOperation("returnType")>]                                                 //__SILP__
    member __.ReturnType (attributes : Attributes<Entry>, returnType : ReturnType) =  //__SILP__
        attributes.With (ViewAttributes.ReturnTypeAttribKey, returnType)              //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_COMMAND(Entry, ReturnCommand, returnCommand)
    [<CustomOperation("returnCommand")>]                                                      //__SILP__
    member __.ReturnCommand (attributes : Attributes<Entry>, returnCommand : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.ReturnCommandAttribKey, makeCommand returnCommand)    //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, int, CursorPosition, cursorPosition)
    [<CustomOperation("cursorPosition")>]                                              //__SILP__
    member __.CursorPosition (attributes : Attributes<Entry>, cursorPosition : int) =  //__SILP__
        attributes.With (ViewAttributes.CursorPositionAttribKey, cursorPosition)       //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Entry, int, SelectionLength, selectionLength)
    [<CustomOperation("selectionLength")>]                                               //__SILP__
    member __.SelectionLength (attributes : Attributes<Entry>, selectionLength : int) =  //__SILP__
        attributes.With (ViewAttributes.SelectionLengthAttribKey, selectionLength)       //__SILP__
