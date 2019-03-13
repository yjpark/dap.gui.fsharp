[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Button

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit View.Builder<Button> ()
    //SILP: FABULOUS_BUILDER_BUILD(Button)
    override __.Build (builder : AttributesBuilder) =                                //__SILP__
        ViewElement.Create<Button>                                                   //__SILP__
            (ViewBuilders.CreateFuncButton, ViewBuilders.UpdateFuncButton, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, string, Text, text)
    [<CustomOperation("text")>]                                        //__SILP__
    member __.Text (attributes : Attributes<Button>, text : string) =  //__SILP__
        attributes.With (ViewAttributes.TextAttribKey, text)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, unit -> unit, ButtonCommand, command)
    [<CustomOperation("command")>]                                                       //__SILP__
    member __.ButtonCommand (attributes : Attributes<Button>, command : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.ButtonCommandAttribKey, command)                 //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, bool, ButtonCanExecute, canExecute)
    [<CustomOperation("canExecute")>]                                                  //__SILP__
    member __.ButtonCanExecute (attributes : Attributes<Button>, canExecute : bool) =  //__SILP__
        attributes.With (ViewAttributes.ButtonCanExecuteAttribKey, canExecute)         //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, Color, BorderColor, borderColor)
    [<CustomOperation("borderColor")>]                                              //__SILP__
    member __.BorderColor (attributes : Attributes<Button>, borderColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.BorderColorAttribKey, borderColor)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, double, BorderWidth, borderWidth)
    [<CustomOperation("borderWidth")>]                                               //__SILP__
    member __.BorderWidth (attributes : Attributes<Button>, borderWidth : double) =  //__SILP__
        attributes.With (ViewAttributes.BorderWidthAttribKey, borderWidth)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, obj, CommandParameter, commandParameter)
    [<CustomOperation("commandParameter")>]                                                 //__SILP__
    member __.CommandParameter (attributes : Attributes<Button>, commandParameter : obj) =  //__SILP__
        attributes.With (ViewAttributes.CommandParameterAttribKey, commandParameter)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, Button.ButtonContentLayout, ContentLayout, contentLayout)
    [<CustomOperation("contentLayout")>]                                                                     //__SILP__
    member __.ContentLayout (attributes : Attributes<Button>, contentLayout : Button.ButtonContentLayout) =  //__SILP__
        attributes.With (ViewAttributes.ContentLayoutAttribKey, contentLayout)                               //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, int, ButtonCornerRadius, cornerRadius)
    [<CustomOperation("cornerRadius")>]                                                   //__SILP__
    member __.ButtonCornerRadius (attributes : Attributes<Button>, cornerRadius : int) =  //__SILP__
        attributes.With (ViewAttributes.ButtonCornerRadiusAttribKey, cornerRadius)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, string, FontFamily, fontFamily)
    [<CustomOperation("fontFamily")>]                                              //__SILP__
    member __.FontFamily (attributes : Attributes<Button>, fontFamily : string) =  //__SILP__
        attributes.With (ViewAttributes.FontFamilyAttribKey, fontFamily)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, FontAttributes, FontAttributes, fontAttributes)
    [<CustomOperation("fontAttributes")>]                                                          //__SILP__
    member __.FontAttributes (attributes : Attributes<Button>, fontAttributes : FontAttributes) =  //__SILP__
        attributes.With (ViewAttributes.FontAttributesAttribKey, fontAttributes)                   //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, double, FontSize, fontSize)
    [<CustomOperation("fontSize")>]                                            //__SILP__
    member __.FontSize (attributes : Attributes<Button>, fontSize : double) =  //__SILP__
        attributes.With (ViewAttributes.FontSizeAttribKey, fontSize)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, string, ButtonImageSource, image)
    [<CustomOperation("image")>]                                                     //__SILP__
    member __.ButtonImageSource (attributes : Attributes<Button>, image : string) =  //__SILP__
        attributes.With (ViewAttributes.ButtonImageSourceAttribKey, image)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, Color, TextColor, textColor)
    [<CustomOperation("textColor")>]                                            //__SILP__
    member __.TextColor (attributes : Attributes<Button>, textColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.TextColorAttribKey, textColor)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(Button, Thickness, Padding, padding)
    [<CustomOperation("padding")>]                                              //__SILP__
    member __.Padding (attributes : Attributes<Button>, padding : Thickness) =  //__SILP__
        attributes.With (ViewAttributes.PaddingAttribKey, padding)              //__SILP__
