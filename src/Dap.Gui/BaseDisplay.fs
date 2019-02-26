[<AutoOpen>]
module Dap.Gui.BaseDisplay

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<AbstractClass>]
type BaseDisplay<'presenter, 'output when 'presenter :> IPresenter> (output : 'output) =
    let mutable presenter : 'presenter option = None
    abstract member OnPresenter : unit -> unit
    default __.OnPresenter () = ()
    member this.SetPresenter (presenter' : 'presenter) =
        presenter <- Some presenter'
        presenter'.Prefab0.Setup' None ""
        this.OnPresenter ()
    member this.AsDisplay = this :> IDisplay<'presenter, 'output>
    member this.AsDisplay1 = this :> IDisplay<'presenter>
    member this.AsDisplay0 = this :> IDisplay
    interface IDisplay<'presenter, 'output> with
        member __.Output = output
    interface IDisplay<'presenter> with
        member __.Presenter = presenter.Value
        member this.SetPresenter p = this.SetPresenter p
    interface IDisplay with
        member __.Presenter0 = presenter.Value :> IPresenter
        member __.Output0 = output :> obj