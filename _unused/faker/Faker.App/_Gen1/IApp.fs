[<AutoOpen>]
module Faker.App.IApp

open System.Threading
open System.Threading.Tasks
open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform

module Context = Dap.Platform.Context

(*
 * Generated: <App>
 *)

type AppKinds () =
    static member Builder (* ICorePack *) = "Builder"
    static member AppGui (* IGuiPack *) = "AppGui"

type AppKeys () =
    static member Builder (* ICorePack *) = ""
    static member AppGui (* IGuiPack *) = ""

type IApp =
    inherit IApp<IApp>
    inherit ICorePack
    inherit IGuiPack
    abstract Args : AppArgs with get
    abstract AsCorePack : ICorePack with get
    abstract AsGuiPack : IGuiPack with get

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
and AppArgs = {
    Scope : (* AppArgs *) Scope
    Setup : (* AppArgs *) IApp -> unit
    Builder : (* ICorePack *) Context.Args<IBuilder>
    AppGui : (* IGuiPack *) Context.Args<IAppGui>
} with
    static member Create
        (
            ?scope : (* AppArgs *) Scope,
            ?setup : (* AppArgs *) IApp -> unit,
            ?builder : (* ICorePack *) Context.Args<IBuilder>,
            ?appGui : (* IGuiPack *) Context.Args<IAppGui>
        ) : AppArgs =
        {
            Scope = (* AppArgs *) scope
                |> Option.defaultWith (fun () -> NoScope)
            Setup = (* AppArgs *) setup
                |> Option.defaultWith (fun () -> ignore)
            Builder = (* ICorePack *) builder
                |> Option.defaultWith (fun () -> Feature.addToAgent<IBuilder>)
            AppGui = (* IGuiPack *) appGui
                |> Option.defaultWith (fun () -> Feature.addToAgent<IAppGui>)
        }
    static member SetScope ((* AppArgs *) scope : Scope) (this : AppArgs) =
        {this with Scope = scope}
    static member SetSetup ((* AppArgs *) setup : IApp -> unit) (this : AppArgs) =
        {this with Setup = setup}
    static member SetBuilder ((* ICorePack *) builder : Context.Args<IBuilder>) (this : AppArgs) =
        {this with Builder = builder}
    static member SetAppGui ((* IGuiPack *) appGui : Context.Args<IAppGui>) (this : AppArgs) =
        {this with AppGui = appGui}
    static member JsonEncoder : JsonEncoder<AppArgs> =
        fun (this : AppArgs) ->
            E.object [
                "scope", Scope.JsonEncoder (* AppArgs *) this.Scope
            ]
    static member JsonDecoder : JsonDecoder<AppArgs> =
        D.object (fun get ->
            {
                Scope = get.Optional.Field (* AppArgs *) "scope" Scope.JsonDecoder
                    |> Option.defaultValue NoScope
                Setup = (* (* AppArgs *)  *) ignore
                Builder = (* (* ICorePack *)  *) Feature.addToAgent<IBuilder>
                AppGui = (* (* IGuiPack *)  *) Feature.addToAgent<IAppGui>
            }
        )
    static member JsonSpec =
        FieldSpec.Create<AppArgs> (AppArgs.JsonEncoder, AppArgs.JsonDecoder)
    interface IJson with
        member this.ToJson () = AppArgs.JsonEncoder this
    interface IObj
    member this.WithScope ((* AppArgs *) scope : Scope) =
        this |> AppArgs.SetScope scope
    member this.WithSetup ((* AppArgs *) setup : IApp -> unit) =
        this |> AppArgs.SetSetup setup
    member this.WithBuilder ((* ICorePack *) builder : Context.Args<IBuilder>) =
        this |> AppArgs.SetBuilder builder
    member this.WithAppGui ((* IGuiPack *) appGui : Context.Args<IAppGui>) =
        this |> AppArgs.SetAppGui appGui
    interface ICorePackArgs with
        member this.Builder (* ICorePack *) : Context.Args<IBuilder> = this.Builder
    member this.AsCorePackArgs = this :> ICorePackArgs
    interface IGuiPackArgs with
        member this.AppGui (* IGuiPack *) : Context.Args<IAppGui> = this.AppGui
    member this.AsGuiPackArgs = this :> IGuiPackArgs

(*
 * Generated: <ValueBuilder>
 *)
type AppArgsBuilder () =
    inherit ObjBuilder<AppArgs> ()
    override __.Zero () = AppArgs.Create ()
    [<CustomOperation("scope")>]
    member __.Scope (target : AppArgs, (* AppArgs *) scope : Scope) =
        target.WithScope scope
    [<CustomOperation("Setup")>]
    member __.Setup (target : AppArgs, (* AppArgs *) setup : IApp -> unit) =
        target.WithSetup setup
    [<CustomOperation("builder")>]
    member __.Builder (target : AppArgs, (* ICorePack *) builder : Context.Args<IBuilder>) =
        target.WithBuilder builder
    [<CustomOperation("app_gui")>]
    member __.AppGui (target : AppArgs, (* IGuiPack *) appGui : Context.Args<IAppGui>) =
        target.WithAppGui appGui

let app_args = new AppArgsBuilder ()