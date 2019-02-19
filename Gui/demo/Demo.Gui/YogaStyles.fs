module Demo.Gui.YogaStyles

open System
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Yoga

open Demo.Gui.Prefab

let register () =
    Styles.register<YogaStyle, IPrefab> Yoga_Leaf [
        node {
            flex_direction YogaFlexDirection.Row
        }
        None
    ]

    Styles.register<YogaStyle, IPrefab> Yoga_Contact [
        node {
            flex_direction YogaFlexDirection.Row
        }
        None
    ]

    Styles.register<YogaStyle, IPrefab> Yoga_Contacts [
        node {
            flex_direction YogaFlexDirection.Column
        }
        None
    ]

    Styles.register<YogaStyle, IPrefab> Yoga_HomePanel [
        node {
            flex_direction YogaFlexDirection.Column
        }
        None
    ]
