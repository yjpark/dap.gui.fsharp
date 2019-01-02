[<AutoOpen>]
module Faker.App.Types

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2
open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform

module Context = Dap.Platform.Context

(*
 * Generated: <Record>
 *     IsJson
 *)
type Target = {
    Project : (* Target *) string
    Action : (* Target *) string
} with
    static member Create
        (
            ?project : (* Target *) string,
            ?action : (* Target *) string
        ) : Target =
        {
            Project = (* Target *) project
                |> Option.defaultWith (fun () -> "")
            Action = (* Target *) action
                |> Option.defaultWith (fun () -> "")
        }
    static member SetProject ((* Target *) project : string) (this : Target) =
        {this with Project = project}
    static member SetAction ((* Target *) action : string) (this : Target) =
        {this with Action = action}
    static member JsonEncoder : JsonEncoder<Target> =
        fun (this : Target) ->
            E.object [
                "project", E.string (* Target *) this.Project
                "action", E.string (* Target *) this.Action
            ]
    static member JsonDecoder : JsonDecoder<Target> =
        D.object (fun get ->
            {
                Project = get.Required.Field (* Target *) "project" D.string
                Action = get.Required.Field (* Target *) "action" D.string
            }
        )
    static member JsonSpec =
        FieldSpec.Create<Target> (Target.JsonEncoder, Target.JsonDecoder)
    interface IJson with
        member this.ToJson () = Target.JsonEncoder this
    interface IObj
    member this.WithProject ((* Target *) project : string) =
        this |> Target.SetProject project
    member this.WithAction ((* Target *) action : string) =
        this |> Target.SetAction action

(*
 * Generated: <Combo>
 *)
type BuilderProps (owner : IOwner, key : Key) =
    inherit WrapProperties<BuilderProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let targets = target'.AddList<(* BuilderProps *) Target> (Target.JsonEncoder, Target.JsonDecoder, "targets", (Target.Create ()), None)
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
    member __.Targets (* BuilderProps *) : IListProperty<IVarProperty<Target>> = targets

(*
 * Generated: <Context>
 *)
type IBuilder =
    inherit IFeature
    inherit IContext<BuilderProps>
    abstract BuilderProps : BuilderProps with get
    abstract Reload : IHandler<unit, unit> with get

(*
 * Generated: <Context>
 *)
[<Literal>]
let BuilderKind = "Builder"

[<AbstractClass>]
type BaseBuilder<'context when 'context :> IBuilder> (logging : ILogging) =
    inherit CustomContext<'context, ContextSpec<BuilderProps>, BuilderProps> (logging, new ContextSpec<BuilderProps>(BuilderKind, BuilderProps.Create))
    let reload = base.Handlers.Add<unit, unit> (E.unit, D.unit, E.unit, D.unit, "reload")
    member this.BuilderProps : BuilderProps = this.Properties
    member __.Reload : IHandler<unit, unit> = reload
    interface IBuilder with
        member this.BuilderProps : BuilderProps = this.Properties
        member __.Reload : IHandler<unit, unit> = reload
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