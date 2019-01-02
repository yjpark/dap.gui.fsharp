[<AutoOpen>]
module Faker.Gui.Prefab.LinkStatus

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
    "item_prefab": "button",
    "items": []
}
"""

type ActionsProps = ListProps<ButtonProps>

type IActions =
    inherit IListPrefab<ActionsProps, ButtonProps>
    abstract Target : IFullTable with get
    abstract ResizeItems : int -> unit

type Actions (logging : ILogging) =
    inherit WrapList<Actions, ActionsProps, IButton, ButtonProps, IFullTable> (ActionsKind, ActionsProps.CreateOf ButtonProps.Create, logging)
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