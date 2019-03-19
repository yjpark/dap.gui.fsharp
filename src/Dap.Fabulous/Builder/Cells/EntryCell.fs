[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.EntryCell

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type EntryCell = Fabulous.CustomControls.CustomEntryCell

type Builder () =
    inherit Cell.Builder<EntryCell> ()
    //SILP: FABULOUS_BUILDER_BUILD(EntryCell)
    override __.Build (builder : AttributesBuilder) =                                      //__SILP__
        ViewElement.Create<EntryCell>                                                      //__SILP__
            (ViewBuilders.CreateFuncEntryCell, ViewBuilders.UpdateFuncEntryCell, builder)  //__SILP__
    [<CustomOperation("completed")>]
    member __.Completed (attributes : Attributes<EntryCell>, completed : string -> unit) =
        attributes.With (ViewAttributes.EntryCompletedAttribKey, (fun f ->
            System.EventHandler (fun sender _args -> f (sender :?> Xamarin.Forms.EntryCell).Text)) (completed))
    //SILP: FABULOUS_BUILDER_OPERATION(EntryCell, string, Label, label)
    [<CustomOperation("label")>]                                            //__SILP__
    member __.Label (attributes : Attributes<EntryCell>, label : string) =  //__SILP__
        attributes.With (ViewAttributes.LabelAttribKey, label)              //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(EntryCell, string, Text, text)
    [<CustomOperation("text")>]                                           //__SILP__
    member __.Text (attributes : Attributes<EntryCell>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)              //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(EntryCell, Keyboard, Keyboard, keyboard)
    [<CustomOperation("keyboard")>]                                                 //__SILP__
    member __.Keyboard (attributes : Attributes<EntryCell>, keyboard : Keyboard) =  //__SILP__
        attributes.With (ViewAttributes.KeyboardAttribKey, keyboard)                //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(EntryCell, string, Placeholder, placeholder)
    [<CustomOperation("placeholder")>]                                                  //__SILP__
    member __.Placeholder (attributes : Attributes<EntryCell>, placeholder : string) =  //__SILP__
        attributes.With (ViewAttributes.PlaceholderAttribKey, placeholder)              //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(EntryCell, TextAlignment, HorizontalTextAlignment, horizontalTextAlignment)
    [<CustomOperation("horizontalTextAlignment")>]                                                                     //__SILP__
    member __.HorizontalTextAlignment (attributes : Attributes<EntryCell>, horizontalTextAlignment : TextAlignment) =  //__SILP__
        attributes.With (ViewAttributes.HorizontalTextAlignmentAttribKey, horizontalTextAlignment)                     //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(EntryCell, TextChangedEventArgs, EntryCellTextChanged, textChanged)
    [<CustomOperation("textChanged")>]                                                                                 //__SILP__
    member __.EntryCellTextChanged (attributes : Attributes<EntryCell>, textChanged : TextChangedEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.EntryCellTextChangedAttribKey, (fun f ->                                       //__SILP__
            System.EventHandler<TextChangedEventArgs> (fun _sender args -> f args)) (textChanged))                     //__SILP__
