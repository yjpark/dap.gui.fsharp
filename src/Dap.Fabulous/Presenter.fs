[<AutoOpen>]
module Dap.Gui.Fabulous.Presenter

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

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

type Presenter<'app when 'app :> IPack and 'app :> INeedSetupAsync> (prefab : IMainForm) =
    inherit BasePresenter<'app, IMainForm> (prefab)

let newPresenter<'app when 'app :> IPack and 'app :> INeedSetupAsync> (env : IEnv) : Presenter<'app> =
    let mainForm = new MainForm (env.Logging)
    new Presenter<'app> (mainForm)