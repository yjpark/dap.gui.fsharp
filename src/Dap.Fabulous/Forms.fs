[<AutoOpen>]
module Dap.Fabulous.BaseForm

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Internal
open Dap.Fabulous

module ViewTypes = Dap.Fabulous.View.Types
module ViewLogic = Dap.Fabulous.View.Logic

[<AbstractClass>]
type BaseForm<'form, 'page when 'form :> IPrefab and 'page :> Page> (logging : ILogging, newPage : unit -> 'page) =
    inherit BasePrefab<'form, LabelProps, 'page> (FormKind, LabelProps.Create, logging, newPage ())
    member this.Page = this.Widget
    interface IForm<'page> with
        member this.Page = this.Page
    interface IForm with
        member this.Page0 = this.Page :> Page

type LoadingForm (logging : ILogging) =
    inherit BaseForm<LoadingForm, ContentPage> (logging, LoadingForm.CreatePage)
    static member CreatePage () =
        let page =
            View.ContentPage (
                content = View.StackLayout (
                    padding = 20.0,
                    children = [
                        View.Label (text = "Loading...")
                    ]
                )
            )
        page.Create () :?> ContentPage
    override this.Self = this
    override __.Spawn l = new LoadingForm (l)
    interface ILoadingForm
    interface IFallback
