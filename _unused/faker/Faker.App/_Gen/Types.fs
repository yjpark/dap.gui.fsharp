[<AutoOpen>]
module Faker.App.Types

open System.Threading
open System.Threading.Tasks
open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform

module Context = Dap.Platform.Context

(*
 * Generated: <Record>
 *     IsJson
 *)
type Project = {
    Name : (* Project *) string
    Actions : (* Project *) string list
} with
    static member Create
        (
            ?name : (* Project *) string,
            ?actions : (* Project *) string list
        ) : Project =
        {
            Name = (* Project *) name
                |> Option.defaultWith (fun () -> "")
            Actions = (* Project *) actions
                |> Option.defaultWith (fun () -> [])
        }
    static member SetName ((* Project *) name : string) (this : Project) =
        {this with Name = name}
    static member SetActions ((* Project *) actions : string list) (this : Project) =
        {this with Actions = actions}
    static member JsonEncoder : JsonEncoder<Project> =
        fun (this : Project) ->
            E.object [
                "name", E.string (* Project *) this.Name
                "actions", (E.list E.string) (* Project *) this.Actions
            ]
    static member JsonDecoder : JsonDecoder<Project> =
        D.object (fun get ->
            {
                Name = get.Required.Field (* Project *) "name" D.string
                Actions = get.Required.Field (* Project *) "actions" (D.list D.string)
            }
        )
    static member JsonSpec =
        FieldSpec.Create<Project> (Project.JsonEncoder, Project.JsonDecoder)
    interface IJson with
        member this.ToJson () = Project.JsonEncoder this
    interface IObj
    member this.WithName ((* Project *) name : string) =
        this |> Project.SetName name
    member this.WithActions ((* Project *) actions : string list) =
        this |> Project.SetActions actions

(*
 * Generated: <Combo>
 *)
type BuilderProps (owner : IOwner, key : Key) =
    inherit WrapProperties<BuilderProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let projects = target'.AddList<(* BuilderProps *) Project> (Project.JsonEncoder, Project.JsonDecoder, "projects", (Project.Create ()), None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new BuilderProps (o, k)
    static member Create () = BuilderProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<BuilderProps> (BuilderProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = BuilderProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Projects (* BuilderProps *) : IListProperty<IVarProperty<Project>> = projects

(*
 * Generated: <Context>
 *)
type IBuilder =
    inherit IFeature
    inherit IContext<BuilderProps>
    abstract BuilderProps : BuilderProps with get
    abstract ReloadAsync : IAsyncHandler<unit, unit> with get

(*
 * Generated: <Context>
 *)
[<Literal>]
let BuilderKind = "Builder"

[<AbstractClass>]
type BaseBuilder<'context when 'context :> IBuilder> (logging : ILogging) =
    inherit CustomContext<'context, ContextSpec<BuilderProps>, BuilderProps> (logging, new ContextSpec<BuilderProps>(BuilderKind, BuilderProps.Create))
    let reloadAsync = base.AsyncHandlers.Add<unit, unit> (E.unit, D.unit, E.unit, D.unit, "reload")
    member this.BuilderProps : BuilderProps = this.Properties
    member __.ReloadAsync : IAsyncHandler<unit, unit> = reloadAsync
    interface IBuilder with
        member this.BuilderProps : BuilderProps = this.Properties
        member __.ReloadAsync : IAsyncHandler<unit, unit> = reloadAsync
    interface IFeature
    member this.AsBuilder = this :> IBuilder

(*
 * Generated: <Context>
 *)
type IAppGui =
    inherit IFeature
    inherit IContext<NoProperties>
    abstract NoProperties : NoProperties with get
    abstract DoDummy : IHandler<unit, unit> with get

(*
 * Generated: <Context>
 *)
[<Literal>]
let AppGuiKind = "AppGui"

[<AbstractClass>]
type BaseAppGui<'context when 'context :> IAppGui> (logging : ILogging) =
    inherit CustomContext<'context, ContextSpec<NoProperties>, NoProperties> (logging, new ContextSpec<NoProperties>(AppGuiKind, NoProperties.Create))
    let doDummy = base.Handlers.Add<unit, unit> (E.unit, D.unit, E.unit, D.unit, "do_dummy")
    member this.NoProperties : NoProperties = this.Properties
    member __.DoDummy : IHandler<unit, unit> = doDummy
    interface IAppGui with
        member this.NoProperties : NoProperties = this.Properties
        member __.DoDummy : IHandler<unit, unit> = doDummy
    interface IFeature
    member this.AsAppGui = this :> IAppGui

(*
 * Generated: <Pack>
 *)
type ICorePackArgs =
    abstract Builder : Context.Args<IBuilder> with get

type ICorePack =
    inherit IPack
    abstract Args : ICorePackArgs with get
    abstract Builder : Context.Agent<IBuilder> with get

(*
 * Generated: <Pack>
 *)
type IGuiPackArgs =
    abstract AppGui : Context.Args<IAppGui> with get

type IGuiPack =
    inherit IPack
    abstract Args : IGuiPackArgs with get
    abstract AppGui : Context.Agent<IAppGui> with get