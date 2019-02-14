[<AutoOpen>]
module Dap.Gui.Types

open Dap.Prelude
open Dap.Context
open Dap.Platform

type IStyle =
    abstract Target0 : IPrefab with get
    abstract OnChildAdded : IPrefab -> unit
    abstract OnChildRemoved : IPrefab -> unit
    abstract Apply : unit -> unit

and IStyle<'prefab when 'prefab :> IPrefab> =
    inherit IStyle
    abstract Target : 'prefab with get

and IPrefab =
    inherit IContext
    abstract Widget0 : obj with get
    abstract Styles : IStyle list with get
    abstract ApplyStyles : unit -> unit

type IPrefab<'model when 'model :> IViewProps> =
    inherit IPrefab
    inherit IFeature
    inherit IContext<'model>

type IPrefab<'model, 'widget when 'model :> IViewProps> =
    inherit IPrefab<'model>
    abstract Widget : 'widget with get

type IPresenter =
    inherit IOwner
    abstract Prefab0 : IPrefab with get
    abstract Attached : bool

type IPresenter<'domain> =
    inherit IPresenter
    abstract Domain : 'domain option with get
    abstract Attach : 'domain -> unit

type IPresenter<'domain, 'prefab when 'prefab :> IPrefab> =
    inherit IPresenter<'domain>
    abstract Prefab : 'prefab with get
    abstract OnAttached : IBus<IPresenter<'domain, 'prefab>> with get

type IDynamicPresenter =
    inherit IPresenter
    abstract Seal : unit -> unit
    abstract Sealed : bool with get

type IDynamicPresenter<'domain> =
    inherit IDynamicPresenter
    abstract Detach : unit -> 'domain option

type IDynamicPresenter<'domain, 'prefab when 'prefab :> IPrefab> =
    inherit IPresenter<'domain, 'prefab>
    inherit IDynamicPresenter<'domain>
    abstract AsPresenter : IPresenter<'domain, 'prefab> with get
    abstract OnDetached : IBus<IDynamicPresenter<'domain, 'prefab>> with get

type IView =
    abstract Display0 : obj with get
    abstract Presenter0 : IPresenter with get

type IView<'presenter when 'presenter :> IPresenter> =
    inherit IView
    abstract Presenter : 'presenter with get

type IView<'presenter, 'display when 'presenter :> IPresenter> =
    inherit IView<'presenter>
    abstract Display : 'display with get

[<AutoOpen>]
module Extensions =
    type IPrefab with
        member this.FilterStyles<'style when 'style :> IStyle> () : 'style list =
            this.Styles
            |> List.choose (fun style ->
                match style with
                | :? 'style as style -> Some style
                | _ -> None
            )
        member this.TryFindStyle<'style when 'style :> IStyle> () : 'style option =
            match this.FilterStyles<'style> () with
            | [] -> None
            | [ style ] -> Some style
            | _ as styles ->
                logWarn this (sprintf "TryFindStyle<%s>" typeof<'style>.Name) "Found_Multiple" styles
                styles
                |> List.head
                |> Some
        member this._StylesOnChildAdded (child : IPrefab) =
            this.Styles
            |> List.iter (fun style -> style.OnChildAdded child)
        member this._StylesOnChildRemoved (child : IPrefab) =
            this.Styles
            |> List.iter (fun style -> style.OnChildRemoved child)
    type IPrefab<'model when 'model :> IViewProps> with
        member this.Model = this.Properties
    type IView with
        member this.Attached = this.Presenter0.Attached
        member this.Prefab0 = this.Presenter0.Prefab0
        member this.Widget0 = this.Presenter0.Prefab0.Widget0
