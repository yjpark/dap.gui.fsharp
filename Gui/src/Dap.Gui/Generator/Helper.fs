[<AutoOpen>]
module Dap.Gui.Generator.Helper

open Microsoft.FSharp.Quotations

open Dap.Prelude
open Dap.Context.Generator
open Dap.Context.Meta.Util
open Dap.Gui

type G with
    static member Prefab (param : PrefabParam, meta : IViewProps) =
        new Prefab.Generator (meta)
        :> IGenerator<PrefabParam>
        |> fun g -> g.Generate param
    static member Prefab (name, meta) =
        let param = PrefabParam.Create name
        G.Prefab (param, meta)
    static member Prefab<'widget when 'widget :> IViewProps> (expr : Expr<'widget>) =
        let (name, meta) = unquotePropertyGetExpr expr
        G.Prefab (name, meta)

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
