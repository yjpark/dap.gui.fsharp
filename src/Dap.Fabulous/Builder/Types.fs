[<AutoOpen>]
module Dap.Fabulous.Builder.Types

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous

type Attributes<'element when 'element :> Element> () =
    let kind = typeof<'element>.Name
    let logger = (getLogging ()) .GetLogger (sprintf "Attributes<%s>" kind)
    let mutable callbacks : ('element -> unit) list = []
    let mutable attributes : (AttributesBuilder -> unit) list = []
    let mutable builder : AttributesBuilder option = None
    member __.Kind = kind
    member __.Logger = logger
    member __.IsOpen = builder.IsNone
    member __.IsClosed = builder.IsSome
    member __.Count = attributes.Length + 1
    member __.Callbacks = callbacks
    member __.Attributes = attributes
    member this.Combine (another : Attributes<'element>) =
        callbacks <- another.Callbacks @ callbacks
        attributes <- another.Attributes @ attributes
        this
    member this.AddCallback (callback : 'element -> unit) =
        if builder.IsSome then
            logError logger "AddCallback" "Already_Closed" (this.Count, callbacks.Length, callback)
            failWith "Already_Closed" callback
        else
            callbacks <- callback :: callbacks
    member this.WithCallback callback =
        this.AddCallback callback
        this
    member this.Add<'value> (key : AttributeKey<'value>, value : 'value) =
        if builder.IsSome then
            logError logger "Add" "Already_Closed" (this.Count, key, value)
            failWith "Already_Closed" key
        else
            attributes <-
                (fun b -> b.Add (key, value)) :: attributes
    member this.With<'value> (key, value) =
        this.Add<'value> (key, value)
        this
    member this.ToBuilder () =
        if builder.IsNone then
            let b = new AttributesBuilder (this.Count)
            b.Add (ViewAttributes.ElementCreatedAttribKey, (fun (element' : obj) ->
                let element = element' :?> 'element
                IGuiApp.Instance.Theme.DecorateFabulous element
                callbacks
                |> List.rev
                |> List.iter (fun callback -> callback element)
            ))
            attributes
            |> List.rev
            |> List.iter (fun add -> add b)
            builder <- Some b
        builder.Value
    interface ILogger with
        member __.Log m = logger.Log m
    interface IObj
