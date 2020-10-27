[<AutoOpen>]
module Demo.App.Types

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
type Contact = {
    Name : (* Contact *) string
    Phone : (* Contact *) string
} with
    static member Create
        (
            ?name : (* Contact *) string,
            ?phone : (* Contact *) string
        ) : Contact =
        {
            Name = (* Contact *) name
                |> Option.defaultWith (fun () -> "")
            Phone = (* Contact *) phone
                |> Option.defaultWith (fun () -> "")
        }
    static member SetName ((* Contact *) name : string) (this : Contact) =
        {this with Name = name}
    static member SetPhone ((* Contact *) phone : string) (this : Contact) =
        {this with Phone = phone}
    static member JsonEncoder : JsonEncoder<Contact> =
        fun (this : Contact) ->
            E.object [
                yield "name", E.string (* Contact *) this.Name
                yield "phone", E.string (* Contact *) this.Phone
            ]
    static member JsonDecoder : JsonDecoder<Contact> =
        D.object (fun get ->
            {
                Name = get.Required.Field (* Contact *) "name" D.string
                Phone = get.Required.Field (* Contact *) "phone" D.string
            }
        )
    static member JsonSpec =
        FieldSpec.Create<Contact> (Contact.JsonEncoder, Contact.JsonDecoder)
    interface IJson with
        member this.ToJson () = Contact.JsonEncoder this
    interface IObj
    member this.WithName ((* Contact *) name : string) =
        this |> Contact.SetName name
    member this.WithPhone ((* Contact *) phone : string) =
        this |> Contact.SetPhone phone

(*
 * Generated: <Combo>
 *)
type AddressBookProps (owner : IOwner, key : Key) =
    inherit WrapProperties<AddressBookProps, IComboProperty> ()
    let target' = Properties.combo (owner, key)
    let contacts = target'.AddList<(* AddressBookProps *) Contact> (Contact.JsonEncoder, Contact.JsonDecoder, "contacts", (Contact.Create ()), None)
    do (
        base.Setup (target')
    )
    static member Create (o, k) = new AddressBookProps (o, k)
    static member Create () = AddressBookProps.Create (noOwner, NoKey)
    static member AddToCombo key (combo : IComboProperty) =
        combo.AddCustom<AddressBookProps> (AddressBookProps.Create, key)
    override this.Self = this
    override __.Spawn (o, k) = AddressBookProps.Create (o, k)
    override __.SyncTo t = target'.SyncTo t.Target
    member __.Contacts (* AddressBookProps *) : IListProperty<IVarProperty<Contact>> = contacts

(*
 * Generated: <Context>
 *)
type IAddressBook =
    inherit IFeature
    inherit IContext<AddressBookProps>
    abstract AddressBookProps : AddressBookProps with get
    abstract ReloadAsync : IAsyncHandler<unit, unit> with get

(*
 * Generated: <Context>
 *)
[<Literal>]
let AddressBookKind = "AddressBook"

[<AbstractClass>]
type BaseAddressBook<'context when 'context :> IAddressBook> (logging : ILogging) =
    inherit CustomContext<'context, ContextSpec<AddressBookProps>, AddressBookProps> (logging, new ContextSpec<AddressBookProps>(AddressBookKind, AddressBookProps.Create))
    let reloadAsync = base.AsyncHandlers.Add<unit, unit> (E.unit, D.unit, E.unit, D.unit, "reload")
    member this.AddressBookProps : AddressBookProps = this.Properties
    member __.ReloadAsync : IAsyncHandler<unit, unit> = reloadAsync
    interface IAddressBook with
        member this.AddressBookProps : AddressBookProps = this.Properties
        member __.ReloadAsync : IAsyncHandler<unit, unit> = reloadAsync
    interface IFeature
    member this.AsAddressBook = this :> IAddressBook

(*
 * Generated: <Pack>
 *)
type ICorePackArgs =
    abstract AddressBook : Context.Args<IAddressBook> with get

type ICorePack =
    inherit IPack
    abstract Args : ICorePackArgs with get
    abstract AddressBook : Context.Agent<IAddressBook> with get