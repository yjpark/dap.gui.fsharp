[<AutoOpen>]
module Dap.Gui.BasePresenter

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePresenter<'domain, 'prefab when 'prefab :> IPrefab> (prefab : 'prefab, ?domain' : 'domain) =
    let onAttached = new Bus<IPresenter<'domain, 'prefab>> (prefab, sprintf "%s:OnAttached" prefab.Luid)
    let mutable domain : 'domain option = domain'
    abstract member OnDidAttach : unit -> unit
    default __.OnDidAttach () = ()
    member __.Prefab = prefab
    member __.Domain = domain
    member this.Attach (domain' : 'domain) =
        if domain.IsSome then
            logError this "Attach" "Already_Attached" (domain, domain')
        domain <- Some domain'
        runGuiFunc (fun () ->
            this.OnDidAttach ()
            onAttached.Trigger <| this.AsPresenter
        )
    member __.Attached = domain.IsSome
    interface IPresenter<'domain, 'prefab> with
        member __.Prefab = prefab
        member __.Domain = domain
        member this.Attach (domain' : 'domain) = this.Attach domain'
        member this.OnAttached = onAttached.Publish
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
    let onAttached = new Bus<IPresenter<'domain, 'prefab>> (prefab, sprintf "%s:OnAttached" prefab.Luid)
    let onDetached = new Bus<IDynamicPresenter<'domain, 'prefab>> (prefab, sprintf "%s:OnDetached" prefab.Luid)
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
        onAttached.Trigger <| this.AsPresenter
    member this.Detach () =
        if sealed' then
            logError this "Detach" "Already_Sealed" (domain)
        let domain' = domain
        if domain.IsSome then
            this.OnWillDetach None
        domain <- None
        onDetached.Trigger <| this.AsDynamicPresenter
        domain'
    member __.Attached = domain.IsSome
    interface IDynamicPresenter<'domain, 'prefab> with
        member this.Detach () = this.Detach ()
        member this.AsPresenter = this.AsPresenter
        member this.OnDetached = onDetached.Publish
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
        member this.OnAttached = onAttached.Publish
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
