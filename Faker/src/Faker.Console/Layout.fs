[<AutoOpen>]
[<RequireQualifiedAccess>]
module Faker.Console.Layout

open FSharp.Control.Tasks.V2

open Terminal.Gui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Console
open Dap.Console.Prefab

open Faker.Gui.Prefab

let private fixAction (index : int) (view : IAction) =
    //view.Target.AsStack.Widget.ColorScheme <- Colors.Dialog
    view.Target.AsStack.Widget.Frame <- Rect (0, index, 80, 1)
    view.Exec.AsButton.Widget.Frame <- Rect (0, 0, 20, 1)
    view.ExecSingle.AsButton.Widget.Frame <- Rect (30, 0, 20, 1)

let mutable top : int = 0

let private addTop (offset : int) =
    top <- top + offset

let private fixProject (view : IProject) =
    view.Target.AsStack.Widget.ColorScheme <- Colors.Dialog
    view.Target.AsStack.Widget.Frame <- Rect (1, top, 80, 7)
    addTop 8
    view.Name.AsLabel.Widget.ColorScheme <- Colors.Menu
    view.Name.AsLabel.Widget.TextAlignment <- TextAlignment.Centered
    view.Name.AsLabel.Widget.Frame <- Rect (0, 0, 80, 1)
    view.Actions.Target.AsFullTable.Widget.Frame <- Rect (0, 1, 80, 6)
    view.Actions.Target.AsFullTable.Widget.ContentSize <- Size (80, 6)
    view.Actions.Prefabs
    |> List.iteri fixAction

let fixHome (view : IHomePanel) =
    top <- 0
    view.Target.AsStack.Widget.Frame <- Rect (0, 0, 81, 32)
    view.Projects.Target.AsFullTable.Widget.Frame <- Rect (0, 0, 81, 32)
    view.Projects.Target.AsFullTable.Widget.ContentSize <- Size (81, 32)
    view.Projects.Prefabs
    |> List.iter fixProject
    logLayout view
