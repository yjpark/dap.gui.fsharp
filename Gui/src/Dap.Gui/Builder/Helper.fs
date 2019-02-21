[<AutoOpen>]
module Dap.Gui.Builder.Helper

open Microsoft.FSharp.Quotations

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta.Util
open Dap.Context.Generator.Util
open Dap.Gui
module Base = Dap.Gui.Builder.Internal.Base

let label = label_props
let button = button_props
let text_field = text_field_props

type ComboPrefabBuilder (prefab : string, props : ComboProps) =
    inherit Base.ComboPropsBuilder ()
    override this.Zero () =
        props
        |> fun t -> this.Prefab (t, prefab)

type ComboPropsBuilder (container : string) =
    inherit Base.ComboPropsBuilder ()
    override this.Zero () =
        base.Zero ()
        |> fun t -> this.Container (t, container)
    [<CustomOperation("child'")>]
    member __.Child' (target : ComboProps, key, props : IViewProps) =
        target.Children.AddAny key props.Clone0 |> ignore
        target
    [<CustomOperation("child")>]
    member this.Child (target : ComboProps, key, child : obj) =
        match child with
        | :? IViewProps as props ->
            this.Child' (target, key, props)
        | :? Expr<ComboProps> as expr ->
            let (name, props) = unquotePropertyGetExpr expr
            props.Prefab.SetValue name.AsCodeJsonKey
            this.Child' (target, key, props)
        | :? Expr<ListProps> as expr ->
            let (name, props) = unquotePropertyGetExpr expr
            props.Prefab.SetValue name.AsCodeJsonKey
            this.Child' (target, key, props)
        | _ ->
            failWith "Unsupported_Child" child
            target

type ListPropsBuilder (container : string) =
    inherit Base.ListPropsBuilder ()
    override this.Zero () =
        base.Zero ()
        |> fun t -> this.Container (t, container)
    [<CustomOperation("item'")>]
    member __.Item' (target : ListProps, itemPrefab : string) =
        target.ItemPrefab.SetValue itemPrefab
        target
    [<CustomOperation("item")>]
    member this.Item<'props when 'props :> IViewProps> (target : ListProps, expr : Expr<'props>) =
        let (name, _meta) = unquotePropertyGetExpr expr
        this.Item' (target, name.AsCodeJsonKey)

let combo_panel = new ComboPropsBuilder (ContainerKind.Panel)
let combo_h_box = new ComboPropsBuilder (ContainerKind.HBox)
let combo_v_box = new ComboPropsBuilder (ContainerKind.VBox)
let combo_table = new ComboPropsBuilder (ContainerKind.Table)

let list_panel = new ListPropsBuilder (ContainerKind.Panel)
let list_h_box = new ListPropsBuilder (ContainerKind.HBox)
let list_v_box = new ListPropsBuilder (ContainerKind.VBox)
let list_table = new ListPropsBuilder (ContainerKind.Table)
