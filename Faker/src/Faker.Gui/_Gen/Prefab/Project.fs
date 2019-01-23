[<AutoOpen>]
module Faker.Gui.Prefab.Clip

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ProjectKind = "Project"

let ProjectJson = parseJson """
{
    "prefab": "project",
    "styles": [],
    "layout": "vertical_stack",
    "children": {
        "name": {
            "prefab": "",
            "styles": [],
            "text": "..."
        },
        "actions": {
            "prefab": "actions",
            "styles": [],
            "layout": "full_table",
            "item_prefab": "action"
        }
    }
}
"""

type ProjectProps = StackProps

type IProject =
    inherit IPrefab<ProjectProps>
    abstract Name : ILabel with get
    abstract Target : IStack with get
    abstract Actions : IActions with get

type Project (logging : ILogging) =
    inherit WrapCombo<Project, ProjectProps, IStack> (ProjectKind, ProjectProps.Create, logging)
    let name : ILabel = base.AsComboLayout.Add "name" Feature.create<ILabel>
    let actions : IActions = base.AsComboLayout.Add "actions" Feature.create<IActions>
    do (
        base.Model.AsProperty.LoadJson ProjectJson
    )
    static member Create l = new Project (l)
    static member Create () = new Project (getLogging ())
    override this.Self = this
    override __.Spawn l = Project.Create l
    member __.Name : ILabel = name
    member __.Actions : IActions = actions
    interface IFallback
    interface IProject with
        member this.Target = this.Target
        member __.Name : ILabel = name
        member __.Actions : IActions = actions