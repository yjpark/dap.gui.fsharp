[<AutoOpen>]
module Dap.Gui.Generator.Helper

open Microsoft.FSharp.Quotations

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta.Util
open Dap.Context.Generator
open Dap.Context.Generator.Util
open Dap.Gui

type G with
    static member Prefab (param : PrefabParam, meta : IViewProps) =
        new Prefab.Generator (meta)
        :> IGenerator<PrefabParam>
        |> fun g -> g.Generate param
    static member Prefab (name : string, meta) =
        let param = PrefabParam.Create name
        G.Prefab (param, meta)
    static member Prefab<'widget when 'widget :> IViewProps> (expr : Expr<'widget>) =
        let (name, meta) = unquotePropertyGetExpr expr
        meta.Prefab.SetValue name.AsCodeJsonKey
        G.Prefab (name, meta)
    static member PrefabBuilder (param : PrefabParam, meta : IViewProps) =
        new Prefab.BuilderGenerator (meta)
        :> IGenerator<PrefabParam>
        |> fun g -> g.Generate param
    static member PrefabBuilder (name : string, meta) =
        let name = sprintf "%sBuilder" name.AsCodeMemberName
        let param = PrefabParam.Create name
        G.PrefabBuilder (param, meta)
    static member PrefabBuilder<'widget when 'widget :> IViewProps> (expr : Expr<'widget>) =
        let (name, meta) = unquotePropertyGetExpr expr
        meta.Prefab.SetValue name.AsCodeJsonKey
        G.PrefabBuilder (name, meta)

type G with
    static member PrefabFile<'widget when 'widget :> IViewProps> (segments1 : string list, segments2 : string list, moduleName : string, expr : Expr<'widget>, ?lines : Lines) =
        G.File (segments1, segments2,
            G.AutoOpenModule (moduleName,
                [
                    defaultArg lines []
                    G.Prefab (expr)
                ]
            )
        )
    static member PrefabBuilderFile<'widget when 'widget :> IViewProps> (segments1 : string list, segments2 : string list, moduleName : string, expr : Expr<'widget>, ?lines : Lines) =
        G.File (segments1, segments2,
            G.BuilderModule (moduleName,
                [
                    defaultArg lines []
                    G.PrefabBuilder (expr)
                ]
            )
        )
