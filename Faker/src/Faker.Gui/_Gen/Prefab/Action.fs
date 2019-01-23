[<AutoOpen>]
module Faker.Gui.Prefab.Action

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let ActionKind = "Action"

let ActionJson = parseJson """
{
    "prefab": "action",
    "styles": [],
    "layout": "horizontal_stack",
    "children": {
        "exec": {
            "prefab": "",
            "styles": [],
            "disabled": false,
            "text": "Exec"
        },
        "execSingle": {
            "prefab": "",
            "styles": [],
            "disabled": false,
            "text": "Single"
        }
    }
}
"""

type ActionProps = StackProps

type IAction =
    inherit IPrefab<ActionProps>
    abstract Target : IStack with get
    abstract Exec : IButton with get
    abstract ExecSingle : IButton with get

type Action (logging : ILogging) =
    inherit WrapCombo<Action, ActionProps, IStack> (ActionKind, ActionProps.Create, logging)
    let exec : IButton = base.AsComboLayout.Add "exec" Feature.create<IButton>
    let execSingle : IButton = base.AsComboLayout.Add "execSingle" Feature.create<IButton>
    do (
        base.Model.AsProperty.LoadJson ActionJson
    )
    static member Create l = new Action (l)
    static member Create () = new Action (getLogging ())
    override this.Self = this
    override __.Spawn l = Action.Create l
    member __.Exec : IButton = exec
    member __.ExecSingle : IButton = execSingle
    interface IFallback
    interface IAction with
        member this.Target = this.Target
        member __.Exec : IButton = exec
        member __.ExecSingle : IButton = execSingle