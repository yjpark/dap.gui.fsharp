[<AutoOpen>]
module Dap.Fabulous.Types

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

module ViewTypes = Dap.Fabulous.View.Types

[<Literal>]
let FormKind = "Form"

[<Literal>]
let FabulousKind = "Fabulous"

type IForm =
    inherit IPrefab
    abstract Page0 : Page with get

type IForm<'page when 'page :> Page> =
    inherit IForm
    inherit IFeature
    abstract Page : 'page with get

type ILoadingForm =
    inherit IForm
    inherit IFeature

type IFabulousParam =
    abstract Application : Xamarin.Forms.Application with get
    abstract LoadingForm : ILoadingForm with get

type FabulousParam<'pack, 'model, 'msg
        when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> (view : ViewTypes.Args<'pack, 'model, 'msg>) =
    let mutable application : Application option = None
    let mutable loadingForm : ILoadingForm option = None
    member private __.Init () =
        application <- Some <| new Application ()
        loadingForm <- Some <| Feature.create<ILoadingForm> (getLogging ())
        application.Value.MainPage <- loadingForm.Value.Page0
    member this.Application =
        if application.IsNone then
            this.Init ()
        application.Value
    member this.LoadingForm =
        if loadingForm.IsNone then
            this.Init ()
        loadingForm.Value
    member __.View = view
    interface IFabulousParam with
        member this.Application = this.Application
        member this.LoadingForm = this.LoadingForm
