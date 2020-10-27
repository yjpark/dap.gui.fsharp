[<AutoOpen>]
module Demo.App.IApp

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2
open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Platform

module Context = Dap.Platform.Context

(*
 * Generated: <App>
 *)

type AppKinds () =
    static member AddressBook (* ICorePack *) = "AddressBook"

type AppKeys () =
    static member AddressBook (* ICorePack *) = ""

type IApp =
    inherit IBaseApp
    inherit IRunner<IApp>
    inherit ICorePack
    abstract Args : AppArgs with get
    abstract AsCorePack : ICorePack with get

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
and AppArgs = {
    Scope : (* AppArgs *) Scope
    Setup : (* AppArgs *) IApp -> unit
    AddressBook : (* ICorePack *) Context.Args<IAddressBook>
} with
    static member Create
        (
            ?scope : (* AppArgs *) Scope,
            ?setup : (* AppArgs *) IApp -> unit,
            ?addressBook : (* ICorePack *) Context.Args<IAddressBook>
        ) : AppArgs =
        {
            Scope = (* AppArgs *) scope
                |> Option.defaultWith (fun () -> NoScope)
            Setup = (* AppArgs *) setup
                |> Option.defaultWith (fun () -> ignore)
            AddressBook = (* ICorePack *) addressBook
                |> Option.defaultWith (fun () -> Feature.addToAgent<IAddressBook>)
        }
    static member SetScope ((* AppArgs *) scope : Scope) (this : AppArgs) =
        {this with Scope = scope}
    static member SetSetup ((* AppArgs *) setup : IApp -> unit) (this : AppArgs) =
        {this with Setup = setup}
    static member SetAddressBook ((* ICorePack *) addressBook : Context.Args<IAddressBook>) (this : AppArgs) =
        {this with AddressBook = addressBook}
    static member JsonEncoder : JsonEncoder<AppArgs> =
        fun (this : AppArgs) ->
            E.object [
                yield "scope", Scope.JsonEncoder (* AppArgs *) this.Scope
            ]
    static member JsonDecoder : JsonDecoder<AppArgs> =
        D.object (fun get ->
            {
                Scope = get.Optional.Field (* AppArgs *) "scope" Scope.JsonDecoder
                    |> Option.defaultValue NoScope
                Setup = (* (* AppArgs *)  *) ignore
                AddressBook = (* (* ICorePack *)  *) Feature.addToAgent<IAddressBook>
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
    member this.WithAddressBook ((* ICorePack *) addressBook : Context.Args<IAddressBook>) =
        this |> AppArgs.SetAddressBook addressBook
    interface ICorePackArgs with
        member this.AddressBook (* ICorePack *) : Context.Args<IAddressBook> = this.AddressBook
    member this.AsCorePackArgs = this :> ICorePackArgs

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
    [<CustomOperation("address_book")>]
    member __.AddressBook (target : AppArgs, (* ICorePack *) addressBook : Context.Args<IAddressBook>) =
        target.WithAddressBook addressBook

let app_args = new AppArgsBuilder ()