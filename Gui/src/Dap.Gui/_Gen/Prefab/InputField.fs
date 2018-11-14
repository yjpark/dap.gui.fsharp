[<AutoOpen>]
module Dap.Gui.Prefab.InputField

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab

[<Literal>]
let InputFieldKind = "InputField"

let InputFieldJson = parseJson """
{
    "prefab": "input_field",
    "styles": [
        "style3"
    ],
    "layout": "horizontal_stack",
    "children": {
        "label": {
            "prefab": "",
            "styles": [],
            "text": "Label"
        },
        "value": {
            "prefab": "",
            "styles": [],
            "disabled": false,
            "text": ""
        }
    }
}
"""

type InputFieldProps = StackProps

type IInputField =
    inherit IPrefab<InputFieldProps>
    abstract Label : ILabel with get
    abstract Value : ITextField with get

type InputField (logging : ILogging) =
    inherit WrapCombo<InputField, InputFieldProps, IStack> (InputFieldKind, InputFieldProps.Create, logging)
    let label : ILabel = base.AsComboLayout.Add "label" Feature.create<ILabel>
    let value : ITextField = base.AsComboLayout.Add "value" Feature.create<ITextField>
    do (
        base.Model.AsProperty.LoadJson InputFieldJson
    )
    static member Create l = new InputField (l)
    static member Create () = new InputField (getLogging ())
    override this.Self = this
    override __.Spawn l = InputField.Create l
    member __.Label : ILabel = label
    member __.Value : ITextField = value
    interface IFallback
    interface IInputField with
        member __.Label : ILabel = label
        member __.Value : ITextField = value