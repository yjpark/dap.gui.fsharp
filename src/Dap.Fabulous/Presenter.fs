[<AutoOpen>]
module Dap.Fabulous.Presenter

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

module ViewTypes = Dap.Fabulous.View.Types
module ViewLogic = Dap.Fabulous.View.Logic

[<Literal>]
let MainFormKind = "MainForm"

type IMainForm =
    inherit IPrefab

type MainForm (logging : ILogging) =
    inherit BaseCombo<MainForm, ComboProps, IPanel> (MainFormKind, ComboProps.Create, logging)
    override this.Self = this
    override __.Spawn l = new MainForm (l)
    interface IFallback
    interface IMainForm

type Presenter<'pack, 'model, 'msg
        when 'pack :> IPack and 'model : not struct and 'msg :> IMsg>
        (prefab : IMainForm) =
    inherit BasePresenter<'pack, IMainForm> (prefab)
    override this.OnDisAttach () =
        let viewArgs = ViewLogic.newArgs ()
        let! view' = app.Env |> Env.addServiceAsync (Dap.Fabulous.View.Logic.spec (app :> IApp) viewArgs)

let private newApplication () =
    if isRealForms () then
        let application = new Application ()
        let emptyPage = View.ContentPage (content = View.Label (text = "TEST"))
        let page = emptyPage.Create ()
        application.MainPage <- page :?> Page
        application
    else
        failWith "newApplication" "Is_Not_Real_Forms"

let newPresenter<'app when 'app :> IPack and 'app :> INeedSetupAsync> () =
    fun (env : IEnv) ->
        let mainForm = new MainForm (env.Logging)
        new Presenter<'app> (mainForm)