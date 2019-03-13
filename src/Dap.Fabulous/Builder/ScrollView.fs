[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.ScrollView

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit View.Builder<ScrollView> ()
    //SILP: FABULOUS_BUILDER_BUILD(ScrollView)
    override __.Build (builder : AttributesBuilder) =                                        //__SILP__
        ViewElement.Create<ScrollView>                                                       //__SILP__
            (ViewBuilders.CreateFuncScrollView, ViewBuilders.UpdateFuncScrollView, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ScrollView, ViewElement, Content, content)
    [<CustomOperation("content")>]                                                    //__SILP__
    member __.Content (attributes : Attributes<ScrollView>, content : ViewElement) =  //__SILP__
        attributes.With (ViewAttributes.ContentAttribKey, content)                    //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ScrollView, ScrollOrientation, ScrollOrientation, orientation)
    [<CustomOperation("orientation")>]                                                                    //__SILP__
    member __.ScrollOrientation (attributes : Attributes<ScrollView>, orientation : ScrollOrientation) =  //__SILP__
        attributes.With (ViewAttributes.ScrollOrientationAttribKey, orientation)                          //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ScrollView, ScrollBarVisibility, HorizontalScrollBarVisibility, horizontalScrollBarVisibility)
    [<CustomOperation("horizontalScrollBarVisibility")>]                                                                                  //__SILP__
    member __.HorizontalScrollBarVisibility (attributes : Attributes<ScrollView>, horizontalScrollBarVisibility : ScrollBarVisibility) =  //__SILP__
        attributes.With (ViewAttributes.HorizontalScrollBarVisibilityAttribKey, horizontalScrollBarVisibility)                            //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ScrollView, ScrollBarVisibility, VerticalScrollBarVisibility, verticalScrollBarVisibility)
    [<CustomOperation("verticalScrollBarVisibility")>]                                                                                //__SILP__
    member __.VerticalScrollBarVisibility (attributes : Attributes<ScrollView>, verticalScrollBarVisibility : ScrollBarVisibility) =  //__SILP__
        attributes.With (ViewAttributes.VerticalScrollBarVisibilityAttribKey, verticalScrollBarVisibility)                            //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ScrollView, float * float * AnimationKind, ScrollTo, scrollTo)
    [<CustomOperation("scrollTo")>]                                                                       //__SILP__
    member __.ScrollTo (attributes : Attributes<ScrollView>, scrollTo : float * float * AnimationKind) =  //__SILP__
        attributes.With (ViewAttributes.ScrollToAttribKey, scrollTo)                                      //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(ScrollView, ScrolledEventArgs, Scrolled, scrolled)
    [<CustomOperation("scrolled")>]                                                                   //__SILP__
    member __.Scrolled (attributes : Attributes<ScrollView>, scrolled : ScrolledEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.ScrolledAttribKey, (fun f ->                                  //__SILP__
            System.EventHandler<ScrolledEventArgs> (fun _sender args -> f args)) (scrolled))          //__SILP__
