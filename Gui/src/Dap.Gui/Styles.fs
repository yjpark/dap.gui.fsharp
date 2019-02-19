[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.Styles

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform

let mutable private styles : Map<string, IPrefab -> IStyle> = Map.empty
let mutable private registerLogger : ILogger option = None

let create (prefab : IPrefab) (kind : string) : IStyle option =
    match Map.tryFind kind styles with
    | Some factory ->
        Some <| factory prefab
    | None ->
        logWarn prefab "Styles.create" "Not_Exist" kind
        None

let init (prefab : IPrefab) (styles : IListProperty<IVarProperty<string>>) : IStyle list =
    styles.Value
    |> List.map (fun p -> p.Value)
    |> List.choose (fun kind ->
        create prefab kind
        |> Option.map (fun style -> (kind, style))
    )|> List.map (fun (kind, style) ->
        logWarn prefab "Styles.create" (sprintf "Created:%s" kind) style
        style
    )

let private _register<'style, 'prefab when 'style :> IStyle<'prefab>> (canOverride : bool) (kind : string) (param : obj list) : unit =
    let factory = fun (prefab : IPrefab) ->
        match prefab with
        | :? 'prefab as p ->
            Activator.CreateInstance (typeof<'style>, List.toArray ((p :> obj) :: param))
            :?> IStyle
        | _ ->
            logWarn prefab "Styles.register" "Type_Mismatched"
                (typeof<'style>.FullName, typeof<'prefab>.FullName, prefab.GetType().FullName)
            new InvalidStyle (prefab) :> IStyle
    let logger =
        match registerLogger with
        | Some l -> l
        | None ->
            let l = getLogger "Styles.register"
            registerLogger <- Some l
            l
    match Map.tryFind kind styles with
    | None ->
        logInfo logger "Registered" kind factory
        styles <- styles |> Map.add kind factory
    | Some factory' ->
        if canOverride then
            logWarn logger "Overridden" kind (factory', factory)
            styles <- styles |> Map.add kind factory
        else
            logError logger "Conflicted" kind (factory', factory)

let register<'style, 'prefab when 'style :> IStyle<'prefab>> (kind : string) (param : obj list) : unit =
    _register<'style, 'prefab> false kind param

let register'<'style, 'prefab when 'style :> IStyle<'prefab>> (kind : string) (param : obj list) : unit =
    _register<'style, 'prefab> true kind param
