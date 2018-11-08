[<AutoOpen>]
module Dap.Gui.BasePresenter

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePresenter<'domain, 'prefab when 'prefab :> IPrefab> (prefab : 'prefab, ?domain' : 'domain) =
    let mutable domain : 'domain option = domain'
    abstract member OnAttached : unit -> unit
    default __.OnAttached () = ()
    member __.Prefab = prefab
    member __.Domain = domain
    member this.Attach (domain' : 'domain) =
        if domain.IsSome then
            logError this "Attach" "Already_Attached" (domain, domain')
        domain <- Some domain'
        this.OnAttached ()
    member __.Attached = domain.IsSome
    interface IPresenter<'domain, 'prefab> with
        member __.Prefab = prefab
        member __.Domain = domain
        member this.Attach (domain' : 'domain) = this.Attach domain'
    interface IPresenter with
        member __.Prefab0 = prefab :> IPrefab
        member __.Attached = domain.IsSome
    interface IOwner with
        member __.Luid = prefab.Luid
        member __.Disposed = prefab.Disposed
    interface ILogger with
        member __.Log m = prefab.Log m
    member this.AsPresenter = this :> IPresenter<'domain, 'prefab>

[<AbstractClass>]
type DynamicPresenter<'domain, 'prefab when 'prefab :> IPrefab> (prefab : 'prefab) =
    let mutable sealed' : bool = false
    let mutable domain : 'domain option = None
    new (getPrefab : unit -> 'prefab) =
        new DynamicPresenter<'domain, 'prefab> (getPrefab ())
    abstract member OnSealed : unit -> unit
    abstract member OnWillAttach : 'domain -> unit
    abstract member OnWillDetach : 'domain option -> unit
    default __.OnSealed () = ()
    default __.OnWillAttach (_next : 'domain) = ()
    default __.OnWillDetach (_next : 'domain option) = ()
    member __.Prefab = prefab
    member __.Domain = domain
    member this.Attach (domain' : 'domain) =
        if sealed' then
            logError this "Attach" "Already_Sealed" (domain, domain')
        if domain.IsSome then
            this.OnWillDetach <| Some domain'
        this.OnWillAttach domain'
        domain <- Some domain'
    member this.Detach () =
        if sealed' then
            logError this "Detach" "Already_Sealed" (domain)
        if domain.IsSome then
            this.OnWillDetach None
        let domain' = domain
        domain <- None
        domain'
    member __.Attached = domain.IsSome
    interface IDynamicPresenter<'domain, 'prefab> with
        member this.Detach () = this.Detach ()
        member this.AsPresenter = this.AsPresenter
    interface IDynamicPresenter with
        member this.Seal () =
            if not sealed' then
                sealed' <- true
                this.OnSealed ()
        member __.Sealed = sealed'
    interface IPresenter<'domain, 'prefab> with
        member __.Prefab = prefab
        member __.Domain = domain
        member this.Attach (domain' : 'domain) = this.Attach domain'
    interface IPresenter with
        member __.Prefab0 = prefab :> IPrefab
        member __.Attached = domain.IsSome
    interface IOwner with
        member __.Luid = prefab.Luid
        member __.Disposed = prefab.Disposed
    interface ILogger with
        member __.Log m = prefab.Log m
    member this.AsPresenter = this :> IPresenter<'domain, 'prefab>
    member this.AsDynamicPresenter = this :> IDynamicPresenter<'domain, 'prefab>
