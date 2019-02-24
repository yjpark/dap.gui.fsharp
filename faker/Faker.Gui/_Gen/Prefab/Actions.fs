[<AutoOpen>]
module Faker.Gui.Prefab.Actions

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ActionsKind = "Actions"

let ActionsJson = parseJson """
{
    "prefab": "actions",
    "styles": [],
    "layout": "full_table",
    "item_prefab": "action",
    "items": []
}
"""

type ActionsProps = ListProps<ActionProps>

type IActions =
    inherit IListPrefab<ActionsProps, ActionProps>
    inherit IListLayout<ActionsProps, IAction>
    abstract Target : IFullTable with get
    abstract ResizeItems : int -> unit

type Actions (logging : ILogging) =
    inherit WrapList<Actions, ActionsProps, IAction, ActionProps, IFullTable> (ActionsKind, ActionsProps.CreateOf ActionProps.Create, logging)
    do (
        base.Model.AsProperty.LoadJson ActionsJson
    )
    static member Create l = new Actions (l)
    static member Create () = new Actions (getLogging ())
    override this.Self = this
    override __.Spawn l = Actions.Create l
    interface IFallback
    interface IActions with
        member this.Target = this.Target
        member this.ResizeItems size = this.ResizeItems size