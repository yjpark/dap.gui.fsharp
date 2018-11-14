[<AutoOpen>]
module Dap.Gui.Prefabs

open Dap.Prelude
open Dap.Context
open Dap.Platform

type ILabel =
    inherit IPrefab<LabelProps>

type IButton =
    inherit IPrefab<ButtonProps>
    abstract OnClick : IChannel<unit> with get

type ITextField =
    inherit IPrefab<TextFieldProps>

type ListProps<'item when 'item :> IViewProps> (owner : IOwner, key : Key, spawner : PropertySpawner<'item>) =
    inherit ListProps (owner, key)
    let items = base.Target.AddList<'item> (spawner, "items")
    static member Create (o, k, s) = new ListProps<'item> (o, k, s)
    member __.Items : IListProperty<'item> = items

type IListPrefab<'model, 'item when 'model :> ListProps<'item> and 'item :> IViewProps> =
    inherit IPrefab<'model>
