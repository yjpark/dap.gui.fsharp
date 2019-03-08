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
    "theme": null,
    "styles": [
        "style3"
    ],
    "container": "h_box",
    "children": {
        "label": {
            "prefab": "",
            "theme": null,
            "styles": [],
            "text": "Label"
        },
        "value": {
            "prefab": "",
            "theme": null,
            "styles": [],
            "disabled": false,
            "text": ""
        }
    }
}
"""

type InputFieldProps = ComboProps

type IInputField =
    inherit IComboPrefab<InputFieldProps>
    inherit IGroupPrefab<IHBox>
    abstract Label : ILabel with get
    abstract Value : ITextField with get

type InputField (logging : ILogging) =
    inherit BaseCombo<InputField, InputFieldProps, IHBox> (InputFieldKind, InputFieldProps.Create, logging)
    let label : ILabel = base.AsComboPrefab.Add "label" Feature.create<ILabel>
    let value : ITextField = base.AsComboPrefab.Add "value" Feature.create<ITextField>
    do (
        base.LoadJson' InputFieldJson
    )
    static member Create l = new InputField (l)
    static member Create () = new InputField (getLogging ())
    override this.Self = this
    override __.Spawn l = InputField.Create l
    member __.Label : ILabel = label
    member __.Value : ITextField = value
    interface IFallback
    interface IInputField with
        member this.Container = this.AsGroupPrefab.Container
        member __.Label : ILabel = label
        member __.Value : ITextField = value