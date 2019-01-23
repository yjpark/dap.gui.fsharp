[<AutoOpen>]
module Faker.Gui.Prefab.Clips

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ProjectsKind = "Projects"

let ProjectsJson = parseJson """
{
    "prefab": "projects",
    "styles": [],
    "layout": "full_table",
    "item_prefab": "project",
    "items": []
}
"""

type ProjectsProps = ListProps<ProjectProps>

type IProjects =
    inherit IListPrefab<ProjectsProps, ProjectProps>
    inherit IListLayout<ProjectsProps, IProject>
    abstract Target : IFullTable with get
    abstract ResizeItems : int -> unit

type Projects (logging : ILogging) =
    inherit WrapList<Projects, ProjectsProps, IProject, ProjectProps, IFullTable> (ProjectsKind, ProjectsProps.CreateOf ProjectProps.Create, logging)
    do (
        base.Model.AsProperty.LoadJson ProjectsJson
    )
    static member Create l = new Projects (l)
    static member Create () = new Projects (getLogging ())
    override this.Self = this
    override __.Spawn l = Projects.Create l
    interface IFallback
    interface IProjects with
        member this.Target = this.Target
        member this.ResizeItems size = this.ResizeItems size