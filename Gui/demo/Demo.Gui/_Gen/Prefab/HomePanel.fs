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
    "layout": "horizontal_stack",
    "children": {
        "contacts": {
            "prefab": "contacts",
            "styles": [],
            "layout": "full_table",
            "item_prefab": "contact"
        }
    }
}
"""

type HomePanelProps = StackProps

type IHomePanel =
    inherit IPrefab<HomePanelProps>
    abstract Target : IStack with get
    abstract Contacts : IContacts with get

type HomePanel (logging : ILogging) =
    inherit WrapCombo<HomePanel, HomePanelProps, IStack> (HomePanelKind, HomePanelProps.Create, logging)
    let contacts : IContacts = base.AsComboLayout.Add "contacts" Feature.create<IContacts>
    do (
        base.Model.AsProperty.LoadJson HomePanelJson
    )
    static member Create l = new HomePanel (l)
    static member Create () = new HomePanel (getLogging ())
    override this.Self = this
    override __.Spawn l = HomePanel.Create l
    member __.Contacts : IContacts = contacts
    interface IFallback
    interface IHomePanel with
        member this.Target = this.Target
        member __.Contacts : IContacts = contacts