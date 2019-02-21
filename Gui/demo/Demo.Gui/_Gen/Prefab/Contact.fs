[<AutoOpen>]
module Demo.Gui.Prefab.Clip

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ContactKind = "Contact"

let ContactJson = parseJson """
{
    "prefab": "contact",
    "styles": [
        "yoga:contact"
    ],
    "container": "h_box",
    "children": {
        "name": {
            "prefab": "",
            "styles": [
                "yoga:leaf"
            ],
            "text": "..."
        },
        "phone": {
            "prefab": "",
            "styles": [
                "yoga:leaf"
            ],
            "text": "..."
        }
    }
}
"""

type ContactProps = ComboProps

type IContact =
    inherit IComboPrefab<ContactProps>
    inherit IGroupPrefab<IHBox>
    abstract Name : ILabel with get
    abstract Phone : ILabel with get

type Contact (logging : ILogging) =
    inherit BaseCombo<Contact, ContactProps, IHBox> (ContactKind, ContactProps.Create, logging)
    let name : ILabel = base.AsComboPrefab.Add "name" Feature.create<ILabel>
    let phone : ILabel = base.AsComboPrefab.Add "phone" Feature.create<ILabel>
    do (
        base.LoadJson' ContactJson
    )
    static member Create l = new Contact (l)
    static member Create () = new Contact (getLogging ())
    override this.Self = this
    override __.Spawn l = Contact.Create l
    member __.Name : ILabel = name
    member __.Phone : ILabel = phone
    interface IFallback
    interface IContact with
        member this.Container = this.AsGroupPrefab.Container
        member __.Name : ILabel = name
        member __.Phone : ILabel = phone