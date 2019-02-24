[<AutoOpen>]
module Faker.Gui.Prefab.HomePanel

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
        "projects": {
            "prefab": "projects",
            "styles": [],
            "layout": "full_table",
            "item_prefab": "project"
        }
    }
}
"""

type HomePanelProps = StackProps

type IHomePanel =
    inherit IPrefab<HomePanelProps>
    abstract Target : IStack with get
    abstract Projects : IProjects with get

type HomePanel (logging : ILogging) =
    inherit WrapCombo<HomePanel, HomePanelProps, IStack> (HomePanelKind, HomePanelProps.Create, logging)
    let projects : IProjects = base.AsComboLayout.Add "projects" Feature.create<IProjects>
    do (
        base.Model.AsProperty.LoadJson HomePanelJson
    )
    static member Create l = new HomePanel (l)
    static member Create () = new HomePanel (getLogging ())
    override this.Self = this
    override __.Spawn l = HomePanel.Create l
    member __.Projects : IProjects = projects
    interface IFallback
    interface IHomePanel with
        member this.Target = this.Target
        member __.Projects : IProjects = projects