[<AutoOpen>]
module Dap.Gui.Internal.BaseContainer

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseContainer<'container, 'widget, 'child when 'container :> IContainer>
        (kind : Kind, logging : ILogging, widget : 'widget) =
    inherit EmptyContext<'container> (logging, kind)
    let mutable wrapper : IPrefab option = None
    abstract member AddChild : 'child -> unit
    abstract member RemoveChild : 'child -> unit
    member __.Wrapper = wrapper
    member __.Widget = widget
    member this.SetWrapper' wrapper' =
        if wrapper.IsSome then
            logError this "SetWrapper" "Already_Set" (wrapper.Value, wrapper')
        else
            wrapper <- Some wrapper'
    interface IContainer<'widget> with
        member this.Widget = this.Widget
    interface IContainer with
        member __.Wrapper = wrapper
        member __.Widget0 = widget :> obj
        member this.SetWrapper' w = this.SetWrapper' w
        member this.AddChild child =
            match child with
            | :? 'child as child ->
                this.AddChild child
            | _ ->
                logError this "AddChild" "Type_Mismatched"
                    (typeof<'child>.FullName, child.GetType().FullName, child)
        member this.RemoveChild child =
            match child with
            | :? 'child as child ->
                this.RemoveChild child
            | _ ->
                logError this "RemoveChild" "Type_Mismatched"
                    (typeof<'child>.FullName, child.GetType().FullName, child)
    member this.AsContainer = this :> IContainer<'widget>
