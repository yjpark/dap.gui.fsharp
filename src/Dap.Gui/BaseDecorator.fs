[<AutoOpen>]
module Dap.Gui.BaseDecorator

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type BaseDecorator<'widget> () =
    let mutable kind : string option = None
    abstract member Decorate : 'widget -> unit
    member __.Kind = kind.Value
    member __.TargetType = typeof<'widget>
    interface IDecorator<'widget> with
        member this.Decorate widget = this.Decorate widget
    interface IDecorator with
        member __.Kind = kind.Value
        member this.Setup' kind' =
            match kind with
            | None ->
                kind <- Some kind'
            | Some kind ->
                let section = sprintf "<%s>.Setup'" <| (this.GetType ()) .FullName
                logError (getLogging ()) section "Already_Setup"
                    (typeof<'widget>.FullName, kind, kind')
        member this.TargetType = this.TargetType
        member this.Decorate0 (widget : obj) =
            match widget with
            | :? 'widget as widget ->
                this.Decorate widget
            | _ ->
                let section = sprintf "<%s>.Decorate0" <| (this.GetType ()) .FullName
                logError (getLogging ()) section "Type_Mismatched"
                    (kind.Value, typeof<'widget>.FullName, widget.GetType().FullName, widget)