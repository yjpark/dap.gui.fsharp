[<AutoOpen>]
module Dap.Console.ConsoleView

open Terminal.Gui

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type IConsoleView =
    abstract KeyboardDelegate : IKeyboardDelegate option with get
    abstract SetKeyboardDelegate : IKeyboardDelegate -> unit
    abstract ResetKeyboardDelegate : unit -> unit

type ConsoleView<'presenter when 'presenter :> IPresenter> (presenter : 'presenter) =
    inherit FrameView (emptyUString)
    do (
        base.Add (presenter.Prefab0.Widget0 :?> View)
    )
    let mutable keyboardDelegate : IKeyboardDelegate option = None
    member __.Presenter = presenter
    override __.ProcessKey (kb : KeyEvent) =
        keyboardDelegate
        |> Option.bind (fun d -> d.ProcessKey)
        |> Option.map (fun f -> f kb)
        |> Option.defaultValue false
    override __.ProcessHotKey (kb : KeyEvent) =
        keyboardDelegate
        |> Option.bind (fun d -> d.ProcessHotKey)
        |> Option.map (fun f -> f kb)
        |> Option.defaultValue false
    override __.ProcessColdKey (kb : KeyEvent) =
        keyboardDelegate
        |> Option.bind (fun d -> d.ProcessColdKey)
        |> Option.map (fun f -> f kb)
        |> Option.defaultValue false
    member __.KeyboardDelegate = keyboardDelegate
    member __.SetKeyboardDelegate d = keyboardDelegate <- Some d
    member __.ResetKeyboardDelegate () = keyboardDelegate <- None

    interface IView<'presenter, FrameView> with
        member this.Display = this :> FrameView
    interface IView<'presenter> with
        member this.Presenter = this.Presenter
    interface IView with
        member this.Display0 = this :> obj
        member this.Presenter0 = presenter :> IPresenter
    interface IConsoleView with
        member __.KeyboardDelegate = keyboardDelegate
        member this.SetKeyboardDelegate d = this.SetKeyboardDelegate d
        member this.ResetKeyboardDelegate () = this.ResetKeyboardDelegate ()