[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.VisualElement

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'element when 'element :> VisualElement> () =
    inherit Element.Builder<'element> ()
    //SILP: FABULOUS_BUILDER_OPERATION('element, double, AnchorX, anchorX)
    [<CustomOperation("anchorX")>]                                             //__SILP__
    member __.AnchorX (attributes : Attributes<'element>, anchorX : double) =  //__SILP__
        attributes.With (ViewAttributes.AnchorXAttribKey, anchorX)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('element, double, AnchorY, anchorY)
    [<CustomOperation("anchorY")>]                                             //__SILP__
    member __.AnchorY (attributes : Attributes<'element>, anchorY : double) =  //__SILP__
        attributes.With (ViewAttributes.AnchorYAttribKey, anchorY)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('element, Color, BackgroundColor, backgroundColor)
    [<CustomOperation("backgroundColor")>]                                                    //__SILP__
    member __.BackgroundColor (attributes : Attributes<'element>, backgroundColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.BackgroundColorAttribKey, backgroundColor)            //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('element, bool, IsEnabled, isEnabled)
    [<CustomOperation("isEnabled")>]                                             //__SILP__
    member __.IsEnabled (attributes : Attributes<'element>, isEnabled : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsEnabledAttribKey, isEnabled)           //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('element, bool, IsVisible, isVisible)
    [<CustomOperation("isVisible")>]                                             //__SILP__
    member __.IsVisible (attributes : Attributes<'element>, isVisible : bool) =  //__SILP__
        attributes.With (ViewAttributes.IsVisibleAttribKey, isVisible)           //__SILP__
    (*
        match heightRequest with None -> () | Some v -> attribBuilder.Add(ViewAttributes.HeightRequestAttribKey, (v)) 
        match inputTransparent with None -> () | Some v -> attribBuilder.Add(ViewAttributes.InputTransparentAttribKey, (v)) 
        match minimumHeightRequest with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MinimumHeightRequestAttribKey, (v)) 
        match minimumWidthRequest with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MinimumWidthRequestAttribKey, (v)) 
        match opacity with None -> () | Some v -> attribBuilder.Add(ViewAttributes.OpacityAttribKey, (v)) 
        match rotation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RotationAttribKey, (v)) 
        match rotationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RotationXAttribKey, (v)) 
        match rotationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RotationYAttribKey, (v)) 
        match scale with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScaleAttribKey, (v)) 
        match style with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StyleAttribKey, (v)) 
        match styleClass with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StyleClassAttribKey, makeStyleClass(v)) 
        match translationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TranslationXAttribKey, (v)) 
        match translationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TranslationYAttribKey, (v)) 
        match widthRequest with None -> () | Some v -> attribBuilder.Add(ViewAttributes.WidthRequestAttribKey, (v)) 
        match resources with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ResourcesAttribKey, (v)) 
        match styles with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StylesAttribKey, (v)) 
        match styleSheets with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StyleSheetsAttribKey, (v)) 
        match isTabStop with None -> () | Some v -> attribBuilder.Add(ViewAttributes.IsTabStopAttribKey, (v)) 
        match scaleX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScaleXAttribKey, (v)) 
        match scaleY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScaleYAttribKey, (v)) 
        match tabIndex with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TabIndexAttribKey, (v)) 
        match childrenReordered with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ChildrenReorderedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        match measureInvalidated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.MeasureInvalidatedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        match focused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FocusedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.FocusEventArgs>(fun _sender args -> f args))(v)) 
        match sizeChanged with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SizeChangedAttribKey, (fun f -> System.EventHandler(fun sender _args -> let visualElement = sender :?> Xamarin.Forms.VisualElement in f (Fabulous.CustomControls.SizeChangedEventArgs(visualElement.Width, visualElement.Height))))(v)) 
        match unfocused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.UnfocusedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.FocusEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder
    *)
