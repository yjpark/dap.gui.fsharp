[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Page

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'page when 'page :> Page> () =
    inherit VisualElement.Builder<'page> ()
    //SILP: FABULOUS_BUILDER_OPERATION('page, string, Title, title)
    [<CustomOperation("title")>]                                        //__SILP__
    member __.Title (attributes : Attributes<'page>, title : string) =  //__SILP__
        attributes.With (ViewAttributes.TitleAttribKey, title)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('page, string, BackgroundImage, backgroundImage)
    [<CustomOperation("backgroundImage")>]                                                  //__SILP__
    member __.BackgroundImage (attributes : Attributes<'page>, backgroundImage : string) =  //__SILP__
        attributes.With (ViewAttributes.BackgroundImageAttribKey, backgroundImage)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('page, string, Icon, icon)
    [<CustomOperation("icon")>]                                       //__SILP__
    member __.Icon (attributes : Attributes<'page>, icon : string) =  //__SILP__
        attributes.With (ViewAttributes.IconAttribKey, icon)          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('page, Thickness, Padding, padding)
    [<CustomOperation("padding")>]                                             //__SILP__
    member __.Padding (attributes : Attributes<'page>, padding : Thickness) =  //__SILP__
        attributes.With (ViewAttributes.PaddingAttribKey, padding)             //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_ARRAY('page, ViewElement, ToolbarItems, toolbarItems)
    [<CustomOperation("toolbarItems")>]                                                         //__SILP__
    member __.ToolbarItems (attributes : Attributes<'page>, toolbarItems : ViewElement list) =  //__SILP__
        attributes.With (ViewAttributes.ToolbarItemsAttribKey, Array.ofList toolbarItems)       //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION('page, bool, UseSafeArea, useSafeArea)
    [<CustomOperation("useSafeArea")>]                                            //__SILP__
    member __.UseSafeArea (attributes : Attributes<'page>, useSafeArea : bool) =  //__SILP__
        attributes.With (ViewAttributes.UseSafeAreaAttribKey, useSafeArea)        //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT('page, Page_Appearing, appearing)
    [<CustomOperation("appearing")>]                                                       //__SILP__
    member __.Page_Appearing (attributes : Attributes<'page>, appearing : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.Page_AppearingAttribKey, (fun f ->                 //__SILP__
            System.EventHandler (fun _sender _args -> f ())) (appearing))                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT('page, Page_Disappearing, disappearing)
    [<CustomOperation("disappearing")>]                                                          //__SILP__
    member __.Page_Disappearing (attributes : Attributes<'page>, disappearing : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.Page_DisappearingAttribKey, (fun f ->                    //__SILP__
            System.EventHandler (fun _sender _args -> f ())) (disappearing))                     //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT('page, Page_LayoutChanged, layoutChanged)
    [<CustomOperation("layoutChanged")>]                                                           //__SILP__
    member __.Page_LayoutChanged (attributes : Attributes<'page>, layoutChanged : unit -> unit) =  //__SILP__
        attributes.With (ViewAttributes.Page_LayoutChangedAttribKey, (fun f ->                     //__SILP__
            System.EventHandler (fun _sender _args -> f ())) (layoutChanged))                      //__SILP__
