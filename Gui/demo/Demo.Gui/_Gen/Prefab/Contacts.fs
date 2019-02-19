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
    "styles": [
        "yoga:contacts"
    ],
    "layout": "full_table",
    "item_prefab": "contact",
    "items": []
}
"""

type ContactsProps = ListProps<ContactProps>

type IContacts =
    inherit IListPrefab<ContactsProps, ContactProps>
    inherit IListLayout<ContactsProps, IContact>
    abstract Target : IFullTable with get
    abstract ResizeItems : int -> unit

type Contacts (logging : ILogging) =
    inherit WrapList<Contacts, ContactsProps, IContact, ContactProps, IFullTable> (ContactsKind, ContactsProps.CreateOf ContactProps.Create, logging)
    do (
        base.LoadJson' ContactsJson
    )
    static member Create l = new Contacts (l)
    static member Create () = new Contacts (getLogging ())
    override this.Self = this
    override __.Spawn l = Contacts.Create l
    interface IFallback
    interface IContacts with
        member this.Target = this.Target
        member this.ResizeItems size = this.ResizeItems size