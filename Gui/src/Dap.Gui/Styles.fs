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
    |> List.choose (create prefab)

let register' (kind : string) (factory : IPrefab -> IStyle) : unit =
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
        styles <-
            styles |> Map.add kind factory
    | Some factory' ->
        logError logger "Conflicted" kind (factory', factory)

let register<'style, 'prefab when 'style :> IStyle<'prefab>> (kind : string) (param : obj list) : unit =
    fun (prefab : IPrefab) ->
        match prefab with
        | :? 'prefab as p ->
            Activator.CreateInstance (typeof<'style>, List.toArray ((p :> obj) :: param))
            :?> IStyle
        | _ ->
            logWarn prefab "Styles.register" "Type_Mismatched"
                (typeof<'style>.FullName, typeof<'prefab>.FullName, prefab.GetType().FullName)
            new InvalidStyle (prefab) :> IStyle
    |> register' kind