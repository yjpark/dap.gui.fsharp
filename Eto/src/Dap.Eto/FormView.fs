[<AutoOpen>]
module Dap.Eto.FormView

open Eto
open Eto.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type FormView<'presenter when 'presenter :> IPresenter> (presenter : 'presenter) =
    inherit Form ()
    do (
        base.Content <- presenter.Prefab0.Widget0 :?> Control
    )
    member __.Presenter = presenter
    interface IView<'presenter, Form> with
        member this.Display = this :> Form
    interface IView<'presenter> with
        member this.Presenter = this.Presenter
    interface IView with
        member this.Display0 = this :> obj
        member this.Presenter0 = presenter :> IPresenter