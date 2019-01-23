[<AutoOpen>]
module Dap.Gui.Layouts

open Dap.Prelude
open Dap.Context
open Dap.Platform

type ILayout =
    inherit IPrefab
    abstract Widget1 : obj with get

type IComboLayout =
    inherit ILayout
    abstract Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : Key -> (ILogging -> 'p) -> 'p

type IComboLayout<'model when 'model :> ComboProps> =
    inherit IPrefab<'model>
    inherit IComboLayout

type IListLayout =
    inherit ILayout
    abstract Prefabs0 : IPrefab list
    abstract SetItems<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : 'm list -> (ILogging -> 'p) -> unit

type IListLayout<'model when 'model :> ListProps> =
    inherit IPrefab<'model>
    inherit IListLayout

type IListLayout<'model, 'item_prefab when 'model :> ListProps> =
    inherit IListLayout<'model>
    abstract Prefabs : 'item_prefab list

type StackProps = ComboProps
type IStack =
    inherit IComboLayout<StackProps>

type TableProps = ListProps
type ITable =
    inherit IListLayout<TableProps>

type FullTableProps = ListProps
type IFullTable =
    inherit IListLayout<FullTableProps>

