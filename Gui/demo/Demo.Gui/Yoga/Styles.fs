module Demo.Gui.Yoga.Styles

open System
open System.Runtime.InteropServices
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Yoga

open Demo.Gui.Prefab

let register () =
    Styles.addClass<ILabel, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Row
            margin_horizontal (point 20.0f)
        }
    ]
    Styles.addClass<IContact, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Row
        }
    ]

    Styles.addClass<IContacts, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Column
        }
    ]

    Styles.addClass<IHomePanel, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Column
        }
    ]
