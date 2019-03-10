[<AutoOpen>]
module Dap.Gui.BaseDecorator

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type BaseDecorator<'widget> () =
    let mutable kind : string option = None
    abstract member Decorate : 'widget -> unit
    member __.Kind = kind.Value
    member __.TargetType = typeof<'widget>
    member __.TryCreateFeature<'feature when 'feature :> IFeature> () : 'feature option =
        Feature.tryCreate<'feature> (getLogging ())
        |> (fun feature ->
            if feature.IsNone then
                logError (getLogging ()) "TryCreateFeature" "Feature_Not_Exist" typeof<'feature>
            feature
        )
    member this.CreateFeature<'feature when 'feature :> IFeature> () : 'feature =
        this.TryCreateFeature<'feature> ()
        |> Option.get
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
                    (typeof<'widget>.FullName, widget.GetType().FullName, widget)