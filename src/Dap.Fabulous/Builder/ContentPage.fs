[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.ContentPage

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit Page.Builder<ContentPage> ()
    //SILP: FABULOUS_BUILDER_BUILD(ContentPage)
    override __.Build (builder : AttributesBuilder) =                                          //__SILP__
        ViewElement.Create<ContentPage>                                                        //__SILP__
            (ViewBuilders.CreateFuncContentPage, ViewBuilders.UpdateFuncContentPage, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(ContentPage, ViewElement, Content, content)
    [<CustomOperation("content")>]                                                     //__SILP__
    member __.Content (attributes : Attributes<ContentPage>, content : ViewElement) =  //__SILP__
        attributes.With (ViewAttributes.ContentAttribKey, content)                     //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION_CALLBACK_ARGS(SwitchCell, (double * double), OnSizeAllocatedCallback, onSizeAllocated)
    [<CustomOperation("onSizeAllocated")>]                                                                                  //__SILP__
    member __.OnSizeAllocatedCallback (attributes : Attributes<SwitchCell>, onSizeAllocated : (double * double) -> unit) =  //__SILP__
        attributes.With (ViewAttributes.OnSizeAllocatedCallbackAttribKey, (fun f ->                                         //__SILP__
            FSharp.Control.Handler<_> (fun _sender args -> f args)) (onSizeAllocated))                                      //__SILP__
