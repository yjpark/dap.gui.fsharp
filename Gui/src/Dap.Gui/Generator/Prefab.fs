[<AutoOpen>]
module Dap.Gui.Generator.Prefab

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta
open Dap.Context.Generator
open Dap.Context.Generator.Util
open Dap.Gui

let private getPrefab (meta : IViewProps) =
    match meta with
    | :? IGroupProps as group ->
        LayoutConst.getKind group.Layout.Value
        |> Union.getKind
    | _ ->
        (meta.GetType ()) .Name
            .Replace ("Props", "")

type Generator (meta : IViewProps) =
    let getParentModel () =
        getPrefab meta
    let getParentClass (param : PrefabParam) =
        match meta with
        | :? IGroupProps as group ->
            LayoutConst.getKind group.Layout.Value
            |> Union.getKind
            |> sprintf "WrapGroup<%s, %sProps, I%s>" param.Name param.Name
        | _ ->
            "ToDo"
    let getChildPrefab (child : IViewProps) =
        if child.Prefab.Value <> "" then
            child.Prefab.Value.AsCodeMemberName
        else
            getPrefab child
    let getKind (param : PrefabParam) =
        [
            sprintf "[<Literal>]"
            sprintf "let %sKind = \"%s\"" param.Name param.Name
        ]
    let getJson (param : PrefabParam) =
        [
            sprintf "let %sJson = parseJson \"\"\"" param.Name
            encodeJson 4 meta
            sprintf "\"\"\""
        ]
    let getInterfaceMember (child : IViewProps) =
        let key = child.Spec0.Key
        let prefab = getChildPrefab child
        sprintf "    abstract %s : I%s with get" key.AsCodeMemberName prefab
    let getInterface (param : PrefabParam) =
        let parentModel = getParentModel ()
        [
            yield sprintf "type %sProps = %sProps" param.Name parentModel
            yield sprintf ""
            yield sprintf "type I%s =" param.Name
            yield sprintf "    inherit IPrefab<%sProps>" param.Name
            match meta with
            | :? IGroupProps as group ->
                for prop in group.Children.Value do
                    match prop with
                    | :? IViewProps as prop ->
                        yield getInterfaceMember prop
                    | _ ->
                        ()
            | _ ->
                ()
        ]
    let getClassHeader (param : PrefabParam) =
        let parentClass = getParentClass param
        [
            sprintf "type %s (logging : ILogging) =" param.Name
            sprintf "    inherit %s (%sKind, %sProps.Create, logging)" parentClass param.Name param.Name
        ]
    let getChildAdder (child : IViewProps) =
        let key = child.Spec0.Key
        let prefab = getChildPrefab child
        sprintf "    let %s : I%s = base.AsGroup.Add \"%s\" Feature.create<I%s>" key.AsCodeVariableName prefab key prefab
    let getClassFields (_param : PrefabParam) =
        [
            match meta with
            | :? IGroupProps as group ->
                for prop in group.Children.Value do
                    match prop with
                    | :? IViewProps as prop ->
                        yield getChildAdder prop
                    | _ ->
                        ()
            | _ ->
                ()
        ]
    let getClassSetup (param : PrefabParam) =
        [
            sprintf "    do ("
            sprintf "        base.Model.AsProperty.LoadJson %sJson" param.Name
            sprintf "    )"
        ]
    let getClassMiddle (param : PrefabParam) =
        [
            sprintf "    static member Create l = new %s (l)" param.Name
            sprintf "    static member Create () = new %s (getLogging ())" param.Name
            sprintf "    override this.Self = this"
            sprintf "    override __.Spawn l = %s.Create l" param.Name
        ]
    let getChildMember (child : IViewProps) =
        let key = child.Spec0.Key
        let prefab = getChildPrefab child
        sprintf "    member __.%s : I%s = %s" key.AsCodeMemberName prefab key.AsCodeVariableName
    let getClassMembers (_param : PrefabParam) =
        [
            match meta with
            | :? IGroupProps as group ->
                for prop in group.Children.Value do
                    match prop with
                    | :? IViewProps as prop ->
                        yield getChildMember prop
                    | _ ->
                        ()
            | _ ->
                ()
        ]
    let hasChild () =
        match meta with
        | :? IGroupProps as group ->
            group.Children.Value
            |> List.exists (fun prop ->
                match prop with
                | :? IViewProps -> true
                | _ -> false
            )
        | _ ->
            false

    let getClassFooter (param : PrefabParam) =
        [
            yield sprintf "    interface IFallback"
            yield sprintf "    interface I%s%s" param.Name (if hasChild () then " with" else "")
            match meta with
            | :? IGroupProps as group ->
                for prop in group.Children.Value do
                    match prop with
                    | :? IViewProps as prop ->
                        yield "    " + getChildMember prop
                    | _ ->
                        ()
            | _ ->
                ()
        ]
    interface IGenerator<PrefabParam> with
        member this.Generate param =
            [
                ["open Dap.Platform"]
                ["open Dap.Gui"]
                ["open Dap.Gui.Prefab"]
                [""]
                getKind param
                [""]
                getJson param
                [""]
                getInterface param
                [""]
                getClassHeader param
                getClassFields param
                getClassSetup param
                getClassMiddle param
                getClassMembers param
                getClassFooter param
            ]|> List.concat