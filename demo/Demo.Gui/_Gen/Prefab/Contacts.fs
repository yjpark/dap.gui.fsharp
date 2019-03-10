[<AutoOpen>]
module Demo.Gui.Prefab.Clips

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ContactsKind = "Contacts"

let ContactsJson = parseJson """
{
    "prefab": "contacts",
    "theme": null,
    "styles": [],
    "container": "table",
    "item_prefab": "contact",
    "items": []
}
"""

type ContactsProps = ListProps

type IContacts =
    inherit IListPrefab<ContactsProps, IContact>
    inherit IGroupPrefab<ITable>

type Contacts (logging : ILogging) =
    inherit BaseList<Contacts, ContactsProps, IContact, ContactProps, ITable> (ContactsKind, ContactsProps.Create, logging)
    do (
        base.LoadJson' ContactsJson
    )
    static member Create l = new Contacts (l)
    static member Create () = new Contacts (getLogging ())
    override this.Self = this
    override __.Spawn l = Contacts.Create l
    interface IFallback
    interface IContacts with
        member this.Container = this.AsGroupPrefab.Container