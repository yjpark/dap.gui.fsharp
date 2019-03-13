[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.NavigationPage

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit Page.Builder<NavigationPage> ()
    //SILP: FABULOUS_BUILDER_BUILD(NavigationPage)
    override __.Build (builder : AttributesBuilder) =                                                //__SILP__
        ViewElement.Create<NavigationPage>                                                           //__SILP__
            (ViewBuilders.CreateFuncNavigationPage, ViewBuilders.UpdateFuncNavigationPage, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_ARRAY(NavigationPage, ViewElement, Pages, pages)
    [<CustomOperation("pages")>]                                                           //__SILP__
    member __.Pages (attributes : Attributes<NavigationPage>, pages : ViewElement list) =  //__SILP__
        attributes.With (ViewAttributes.PagesAttribKey, Array.ofList pages)                //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(NavigationPage, Color, BarBackgroundColor, barBackgroundColor)
    [<CustomOperation("barBackgroundColor")>]                                                             //__SILP__
    member __.BarBackgroundColor (attributes : Attributes<NavigationPage>, barBackgroundColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.BarBackgroundColorAttribKey, barBackgroundColor)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(NavigationPage, Color, BarTextColor, barTextColor)
    [<CustomOperation("barTextColor")>]                                                       //__SILP__
    member __.BarTextColor (attributes : Attributes<NavigationPage>, barTextColor : Color) =  //__SILP__
        attributes.With (ViewAttributes.BarTextColorAttribKey, barTextColor)                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(NavigationPage, NavigationEventArgs, Popped, popped)
    [<CustomOperation("popped")>]                                                                       //__SILP__
    member __.Popped (attributes : Attributes<NavigationPage>, popped : NavigationEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.PoppedAttribKey, (fun f ->                                      //__SILP__
            System.EventHandler<NavigationEventArgs> (fun _sender args -> f args)) (popped))            //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(NavigationPage, NavigationEventArgs, PoppedToRoot, poppedToRoot)
    [<CustomOperation("poppedToRoot")>]                                                                             //__SILP__
    member __.PoppedToRoot (attributes : Attributes<NavigationPage>, poppedToRoot : NavigationEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.PoppedToRootAttribKey, (fun f ->                                            //__SILP__
            System.EventHandler<NavigationEventArgs> (fun _sender args -> f args)) (poppedToRoot))                  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_EVENT_ARGS(NavigationPage, NavigationEventArgs, Pushed, pushed)
    [<CustomOperation("pushed")>]                                                                       //__SILP__
    member __.Pushed (attributes : Attributes<NavigationPage>, pushed : NavigationEventArgs -> unit) =  //__SILP__
        attributes.With (ViewAttributes.PushedAttribKey, (fun f ->                                      //__SILP__
            System.EventHandler<NavigationEventArgs> (fun _sender args -> f args)) (pushed))            //__SILP__
