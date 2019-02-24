[<AutoOpen>]
module Demo.Gui.Prefab.HomePanel

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let HomePanelKind = "HomePanel"

let HomePanelJson = parseJson """
{
    "prefab": "home_panel",
    "styles": [],
    "container": "v_box",
    "children": {
        "title": {
            "prefab": "",
            "styles": [],
            "text": "Address Book"
        },
        "account": {
            "prefab": "contact",
            "styles": [],
            "container": "h_box",
            "children": {
                "name": {
                    "prefab": "",
                    "styles": [],
                    "text": "..."
                },
                "phone": {
                    "prefab": "",
                    "styles": [],
                    "text": "..."
                }
            }
        },
        "contacts_title": {
            "prefab": "",
            "styles": [],
            "text": "Contacts:"
        },
        "contacts": {
            "prefab": "contacts",
            "styles": [],
            "container": "table",
            "item_prefab": "contact"
        }
    }
}
"""

type HomePanelProps = ComboProps

type IHomePanel =
    inherit IComboPrefab<HomePanelProps>
    inherit IGroupPrefab<IVBox>
    abstract Title : ILabel with get
    abstract Account : IContact with get
    abstract ContactsTitle : ILabel with get
    abstract Contacts : IContacts with get

type HomePanel (logging : ILogging) =
    inherit BaseCombo<HomePanel, HomePanelProps, IVBox> (HomePanelKind, HomePanelProps.Create, logging)
    let title : ILabel = base.AsComboPrefab.Add "title" Feature.create<ILabel>
    let account : IContact = base.AsComboPrefab.Add "account" Feature.create<IContact>
    let contactsTitle : ILabel = base.AsComboPrefab.Add "contacts_title" Feature.create<ILabel>
    let contacts : IContacts = base.AsComboPrefab.Add "contacts" Feature.create<IContacts>
    do (
        base.LoadJson' HomePanelJson
    )
    static member Create l = new HomePanel (l)
    static member Create () = new HomePanel (getLogging ())
    override this.Self = this
    override __.Spawn l = HomePanel.Create l
    member __.Title : ILabel = title
    member __.Account : IContact = account
    member __.ContactsTitle : ILabel = contactsTitle
    member __.Contacts : IContacts = contacts
    interface IFallback
    interface IHomePanel with
        member this.Container = this.AsGroupPrefab.Container
        member __.Title : ILabel = title
        member __.Account : IContact = account
        member __.ContactsTitle : ILabel = contactsTitle
        member __.Contacts : IContacts = contacts