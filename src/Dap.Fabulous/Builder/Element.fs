[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.Element

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform
open Dap.Gui

[<AbstractClass>]
type Builder<'element when 'element :> Element> () =
    inherit ObjBuilder<Attributes<'element>> ()
    abstract Build : AttributesBuilder -> Fabulous.DynamicViews.ViewElement

    override __.Zero () = new Attributes<'element> ()
    member this.Run (attributes : Attributes<'element>) =
        this.Build <| attributes.ToBuilder ()
    member __.Combine (attributes : Attributes<'element>, another : Attributes<'element>) =
        attributes.Combine another
    member this.For (attributesList : seq<Attributes<'element>>, _func) =
        attributesList
        |> Seq.fold (fun a b -> this.Combine (a, b)) (this.Zero ())
    [<CustomOperation("callback")>]
    member __.Callback (attributes : Attributes<'element>, callback : 'element -> unit) =
        attributes.WithCallback callback
    //SILP: FABULOUS_BUILDER_OPERATION('view, string, ClassId, classId)
    [<CustomOperation("classId")>]                                          //__SILP__
    member __.ClassId (attributes : Attributes<'view>, classId : string) =  //__SILP__
        attributes.With (ViewAttributes.ClassIdAttribKey, classId)          //__SILP__
