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
    "styles": [],
    "layout": "horizontal_stack",
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
}
"""

type ContactProps = StackProps

type IContact =
    inherit IPrefab<ContactProps>
    abstract Target : IStack with get
    abstract Name : ILabel with get
    abstract Phone : ILabel with get

type Contact (logging : ILogging) =
    inherit WrapCombo<Contact, ContactProps, IStack> (ContactKind, ContactProps.Create, logging)
    let name : ILabel = base.AsComboLayout.Add "name" Feature.create<ILabel>
    let phone : ILabel = base.AsComboLayout.Add "phone" Feature.create<ILabel>
    do (
        base.Model.AsProperty.LoadJson ContactJson
    )
    static member Create l = new Contact (l)
    static member Create () = new Contact (getLogging ())
    override this.Self = this
    override __.Spawn l = Contact.Create l
    member __.Name : ILabel = name
    member __.Phone : ILabel = phone
    interface IFallback
    interface IContact with
        member this.Target = this.Target
        member __.Name : ILabel = name
        member __.Phone : ILabel = phone