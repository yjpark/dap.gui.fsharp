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
        },
        "actions": {
            "prefab": "actions",
            "styles": [],
            "layout": "full_table",
            "item_prefab": "button"
        }
    }
}
"""

type HomePanelProps = StackProps

type IHomePanel =
    inherit IPrefab<HomePanelProps>
    abstract Projects : IProjects with get
    abstract Actions : IActions with get

type HomePanel (logging : ILogging) =
    inherit WrapCombo<HomePanel, HomePanelProps, IStack> (HomePanelKind, HomePanelProps.Create, logging)
    let projects : IProjects = base.AsComboLayout.Add "projects" Feature.create<IProjects>
    let actions : IActions = base.AsComboLayout.Add "actions" Feature.create<IActions>
    do (
        base.Model.AsProperty.LoadJson HomePanelJson
    )
    static member Create l = new HomePanel (l)
    static member Create () = new HomePanel (getLogging ())
    override this.Self = this
    override __.Spawn l = HomePanel.Create l
    member __.Projects : IProjects = projects
    member __.Actions : IActions = actions
    interface IFallback
    interface IHomePanel with
        member __.Projects : IProjects = projects
        member __.Actions : IActions = actions