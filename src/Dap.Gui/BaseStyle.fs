[<AutoOpen>]
module Dap.Gui.BaseStyle

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BaseStyle<'prefab when 'prefab :> IPrefab> (kind : string, target : 'prefab) =
    abstract member OnChildAdded : IPrefab -> unit
    abstract member OnChildRemoved : IPrefab -> unit
    abstract member Apply : unit -> unit
    default __.OnChildAdded (_prefab : IPrefab) = ()
    default __.OnChildRemoved (_prefab : IPrefab) = ()
    default __.Apply () = ()
    member __.Kind = kind
    member __.Target = target
    member __.Target0 = target :> IPrefab
    interface IStyle<'prefab> with
        member __.Target = target
    interface IStyle with
        member __.Kind = kind
        member __.Target0 = target :> IPrefab
        member this.OnChildAdded child = this.OnChildAdded child
        member this.OnChildRemoved child = this.OnChildRemoved child
        member this.Apply () = this.Apply ()

type InvalidStyle (kind : string, target : IPrefab) =
    inherit BaseStyle<IPrefab> (kind, target)