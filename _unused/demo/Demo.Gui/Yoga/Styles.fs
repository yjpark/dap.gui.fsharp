module Demo.Gui.Yoga.Styles

open System
open System.Runtime.InteropServices
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Yoga

open Demo.Gui.Prefab

let register (theme : Theme) =
    theme.AddClassStyle<ILabel, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Row
            margin_horizontal (point 20.0f)
        }
    ]
    theme.AddClassStyle<IContact, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Row
        }
    ]

    theme.AddClassStyle<IContacts, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Column
        }
    ]

    theme.AddClassStyle<IHomePanel, YogaStyle> [
        yoga {
            flex_direction YogaFlexDirection.Column
        }
    ]
