[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.Styles

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform

let private typeIPrefab = typeof<IPrefab>

let private isPrefabInterface (type' : Type) =
    if type' = typeIPrefab then
        false
    else
        typeIPrefab.IsAssignableFrom(type')

type Factory = IPrefab -> IStyle

let mutable private styles : Map<string, Factory list> = Map.empty
let mutable private registerLogger : ILogger option = None
let private getRegisterLogger () =
    match registerLogger with
    | Some l -> l
    | None ->
        let l = getLogger "Styles.register"
        registerLogger <- Some l
        l

let create (prefab : IPrefab) (kind : string) : IStyle list =
    match Map.tryFind kind styles with
    | Some factories ->
        factories
        |> List.rev
        |> List.map (fun factory ->
            let style = factory prefab
            logWarn prefab "Styles.create" (sprintf "Created:%s" kind) style
            style
        )
    | None ->
        //logWarn prefab "Styles.create" (sprintf "Not_Registered:%s" kind) ()
        []

let init (prefab : IPrefab) : IStyle list =
    //TODO: Also check parent and key for more complex rules
    let type' = prefab.GetType ()
    type'.GetInterfaces ()
    |> Array.toList
    |> List.filter isPrefabInterface
    |> List.map (fun type' ->
        create prefab type'.FullName
    )|> List.concat

(*
 * Note: Not have 'style :> IStyle<'prefab> on purpose
 * so IStyle<IPrefab> can be apply to any 'prefab :> IPrefab
*)
let private register<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle>
        (allowMultiple : bool) (clearExists : bool) (kind : string) (param : obj list) : unit =
    let factory = fun (prefab : IPrefab) ->
        match prefab with
        | :? 'prefab ->
            Activator.CreateInstance (typeof<'style>, List.toArray ((kind :> obj) :: (prefab :> obj) :: param))
            :?> IStyle
        | _ ->
            logWarn prefab "Styles.register" "Type_Mismatched"
                (typeof<'style>.FullName, typeof<'prefab>.FullName, prefab.GetType().FullName)
            new InvalidStyle (kind, prefab) :> IStyle
    let logger = getRegisterLogger ()
    match Map.tryFind kind styles with
    | None ->
        logInfo logger "Registered" kind factory
        styles <- styles |> Map.add kind [ factory ]
    | Some factories ->
        if clearExists then
            logWarn logger "Overridden" kind (factories, factory)
            styles <- styles |> Map.add kind [ factory ]
        else
            if allowMultiple  then
                logInfo logger "Registered" kind factory
                styles <- styles |> Map.add kind (factory :: factories)
            else
                logError logger "Not_Allow_Multiple" kind (factories, factory)

let add<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
    register<'prefab, 'style> true false kind param

let addNew<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
    register<'prefab, 'style> false false kind param

let addForce<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
    register<'prefab, 'style> false true kind param

let addClass<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (param : obj list) : unit =
    if not typeof<'prefab>.IsInterface then
        failWith "Must_Be_Interface" (typeof<'prefab>.FullName)
    register<'prefab, 'style> true false (typeof<'prefab>.FullName) param