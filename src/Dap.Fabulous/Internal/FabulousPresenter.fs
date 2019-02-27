[<AutoOpen>]
module Dap.Fabulous.Internal.FabulousPresenter

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Fabulous

module ViewTypes = Dap.Fabulous.View.Types
module ViewLogic = Dap.Fabulous.View.Logic

type FabulousPresenter<'app, 'model, 'msg
        when 'app :> IPack and 'model : not struct and 'msg :> IMsg>
        (param : FabulousParam<'app, 'model, 'msg>, env : IEnv) =
    inherit BasePresenter<'app, ILoadingForm> (param.LoadingForm)
    let mutable view : ViewTypes.View<'app, 'model, 'msg> option = None
    override this.OnDidAttach () =
        let app = this.Domain.Value
        logWarn app "FabulousPresenter" "OnDidAttach" (app)
        env.RunTask0 ignoreOnFailed (fun _ -> task {
            let! view' = env |> Env.addServiceAsync (ViewLogic.spec app param.View) FabulousKind NoKey
            logWarn app "FabulousPresenter" "View_Created" (view')
            view <- Some view'
            do! view'.StartAsync ()
        })
