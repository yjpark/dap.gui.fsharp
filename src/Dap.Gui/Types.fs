[<AutoOpen>]
module Dap.Gui.Types

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform

[<Literal>]
let GuiThemeKind = "GuiTheme"

type IStyle =
    abstract Kind : string with get
    abstract Target0 : IPrefab with get
    abstract TargetType : Type with get
    abstract OnChildAdded : IPrefab -> unit
    abstract OnChildRemoved : IPrefab -> unit
    abstract Apply : unit -> unit

and IStyle<'prefab when 'prefab :> IPrefab> =
    inherit IStyle
    abstract Target : 'prefab with get

and IPrefab =
    inherit IContext
    abstract Parent : IPrefab option with get
    abstract Path : string with get
    abstract Key : string with get
    abstract Setup' : IPrefab option -> string -> unit
    abstract Widget0 : obj with get
    abstract Extras : Map<string, obj> with get
    abstract SetExtras' : Map<string, obj> -> unit
    abstract Styles : IStyle list with get
    abstract SetStyles' : IStyle list -> unit
    abstract ApplyStyles : unit -> unit

type IPrefab<'model when 'model :> IViewProps> =
    inherit IPrefab
    inherit IFeature
    inherit IContext<'model>
    abstract Model : 'model with get

type IPrefab<'model, 'widget when 'model :> IViewProps> =
    inherit IPrefab<'model>
    abstract Widget : 'widget with get

type IContainer =
    inherit IFeature
    abstract Widget0 : obj with get
    abstract Wrapper : IPrefab option with get
    abstract SetWrapper' : IPrefab -> unit
    abstract AddChild : obj -> unit
    abstract RemoveChild : obj -> unit

type IContainer<'widget> =
    inherit IContainer
    abstract Widget : 'widget with get

type IGroupPrefab =
    inherit IPrefab
    abstract Container0 : IContainer with get
    abstract Children : IPrefab list

type IGroupPrefab<'container when 'container :> IContainer> =
    abstract Container : 'container with get

type IComboPrefab =
    inherit IGroupPrefab
    abstract Add<'p, 'm when 'p :> IPrefab<'m> and 'm :> IViewProps> : Key -> (ILogging -> 'p) -> 'p

type IComboPrefab<'model when 'model :> ComboProps> =
    inherit IPrefab<'model>
    inherit IComboPrefab

type IListPrefab =
    inherit IGroupPrefab
    abstract ResizeItems : int -> unit

type IListPrefab<'model when 'model :> ListProps> =
    inherit IPrefab<'model>
    inherit IListPrefab

type IListPrefab<'model, 'item_prefab when 'model :> ListProps and 'item_prefab :> IPrefab> =
    inherit IListPrefab<'model>
    abstract Items : 'item_prefab list

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

type IDisplay =
    abstract Output0 : obj with get
    abstract Presenter0 : IPresenter with get

type IDisplay<'presenter when 'presenter :> IPresenter> =
    inherit IDisplay
    abstract Presenter : 'presenter with get
    abstract SetPresenter : 'presenter -> unit

type IDisplay<'presenter, 'output when 'presenter :> IPresenter> =
    inherit IDisplay<'presenter>
    abstract Output : 'output with get

type IDecorator =
    abstract Kind : string with get
    abstract Setup' : string -> unit
    abstract TargetType : Type with get
    abstract Decorate0 : obj -> unit

type IDecorator<'widget> =
    inherit IDecorator
    abstract Decorate : 'widget -> unit

[<AutoOpen>]
module Extensions =
    type IPrefab with
        member this.TryFindExtra<'obj> (key : string) : 'obj option =
            this.Extras
            |> Map.tryFind key
            |> function
            | None -> None
            | Some o ->
                match o with
                | :? 'obj as o ->
                    Some o
                | _ ->
                    logError this "TryFindExtra" "Type_Mismatched" (key, typeof<'obj>, o.GetType(), o)
                    None
        member this.GetOrNewExtra<'obj> (key : string, factory : string -> 'obj) : 'obj =
            this.Extras
            |> Map.tryFind key
            |> function
            | Some o ->
                match o with
                | :? 'obj as o ->
                    o
                | _ ->
                    failWith (sprintf "Type_Conflicted:%s" key) (typeof<'obj>, o.GetType(), o)
            | None ->
                let o = factory key
                this.Extras
                |> Map.add key (o :> obj)
                |> this.SetExtras'
                o
        member this.GetOrNewExtra<'obj> (factory : string -> 'obj) : 'obj =
            this.GetOrNewExtra<'obj> (typeof<'obj>.FullName, factory)
        member this.FilterStyles<'style when 'style :> IStyle> () : 'style list =
            this.Styles
            |> List.choose (fun style ->
                match style with
                | :? 'style as style -> Some style
                | _ -> None
            )
        member this.TryFindStyle<'style when 'style :> IStyle> () : 'style option =
            match this.FilterStyles<'style> () with
            | [] ->
                logWarn this (sprintf "TryFindStyle<%s>" typeof<'style>.Name) "Not_Found" this.Styles
                None
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
    type IDisplay with
        member this.Attached = this.Presenter0.Attached
        member this.Prefab0 = this.Presenter0.Prefab0
        member this.Widget0 = this.Presenter0.Prefab0.Widget0
