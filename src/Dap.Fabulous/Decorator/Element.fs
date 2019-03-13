[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Element

open System
open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous.Controls

let private typeINativeDecorator = typeof<INativeDecorator>
let mutable private loaded : bool = false
let mutable private nativeDecorators : Map<string, INativeDecorator list> = Map.empty
let mutable logger : ILogger option = None

let private getNativeDecoratorKinds (type' : Type) =
    type'.GetInterfaces ()
    |> Array.filter (fun t ->
        (t.GetGenericArguments ()) .Length = 0
            && t <> typeINativeDecorator
    )|> Array.map Bootstrap.getKind

let private addNativeDecorator (logger : ILogger) ((kind, native) : string * INativeDecorator) : unit =
    match Map.tryFind kind nativeDecorators with
    | None ->
        nativeDecorators <-
            Map.add kind [ native ] nativeDecorators
    | Some decorators ->
        nativeDecorators <-
            Map.add kind (native :: decorators) nativeDecorators

let private loadNativeDecorators (logging : ILogging) =
    logger <- Some <| logging.GetLogger ("NativeDecorator")
    CliHook.createAll<INativeDecorator> logging
    |> List.iter (fun native ->
        let t = native.GetType ()
        let kinds = getNativeDecoratorKinds t
        logInfo logger.Value "Loaded" t.FullName kinds
        kinds
        |> Array.iter (fun kind ->
            addNativeDecorator logger.Value (kind, native)
        )
    )

let private getNativeDecorator<'native when 'native :> INativeDecorator> () =
    if not loaded then
        loadNativeDecorators (getLogging ())
    let kind = Bootstrap.getKind typeof<'native>
    nativeDecorators
    |> Map.tryFind kind
    |> Option.bind (fun decorators ->
        match decorators with
        | [] -> None
        | [ decorator ] -> Some (decorator :?> 'native)
        | _ ->
            logWarn logger.Value "getNativeDecorator" "Multiple_Found" (kind, decorators)
            Some (List.head decorators :?> 'native)
    )|> (fun native ->
        if native.IsNone then
            logWarn logger.Value "getNativeDecorator" "Not_Found" kind
        native
    )

type Decorator<'element when 'element :> Element>
        (?update : 'element -> unit) =
    inherit BaseDecorator<'element> ()
    override __.Decorate (widget : 'element) =
        update
        |> Option.iter (fun x -> x widget)
    member __.TryGetNativeDecorator<'native when 'native :> INativeDecorator> () : 'native option =
        getNativeDecorator<'native> ()
    member this.GetNativeDecorator<'native when 'native :> INativeDecorator> () : 'native =
        this.TryGetNativeDecorator<'native> ()
        |> Option.get
