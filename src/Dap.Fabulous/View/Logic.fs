[<RequireQualifiedAccess>]
module Dap.Gui.Fabulous.View.Logic

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform
open Dap.Gui.Fabulous
open Dap.Gui.Fabulous.Forms

open Dap.Gui.Fabulous.View.Types

type ActorOperate<'pack, 'model, 'msg when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> =
    Operate<View<'pack, 'model, 'msg>, Model<'model, 'msg>, Msg<'model, 'msg>>

let private doRun req (callback: Callback<unit>) : ActorOperate<'pack, 'model, 'msg> =
    fun runner (model, cmd) ->
        if isRealForms () then
            if runner.HasFormsRunner then
                reply runner callback <| nak req "Already_Running" ()
            else
                let args = runner.Actor.Args
                runner.RunFormsFunc (fun _ ->
                    model.Program
                    |> if args.UseConsoleTrace then Program.withConsoleTrace else id
                    |> Program.runWithDynamicView runner.Actor.Args.Application
                    |> runner.SetFormsRunner'
                    reply runner callback <| ack req ()
                )
        else
            reply runner callback <| nak req "Is_Mock_Forms" ()
        (model, cmd)

let private handleReq req : ActorOperate<'pack, 'model, 'msg> =
    match req with
    | DoRun a -> doRun req a

let private update : Update<View<'pack, 'model, 'msg>, Model<'model, 'msg>, Msg<'model, 'msg>> =
    fun runner msg model ->
        match msg with
        | AppReq req -> handleReq req
        | AppEvt _evt -> noOperation
        <| runner <| (model, [])

let private initProgram (initer : Initer<'model, 'msg>) (args : Args<'pack, 'model, 'msg>) ((initModel, initCmd) : 'model * Cmd<'msg>) =
    let init = fun () ->
        (initModel, initCmd)
    let runner = initer :?> View<'pack, 'model, 'msg>
    let update = fun (msg : 'msg) (model : 'model) ->
        let (model, cmd) = args.Logic.Update runner msg model
        runner.Actor.State.View <- model
        (model, cmd)
    let mutable firstView = true
    let view = fun (model : 'model) (dispatch : 'msg -> unit) ->
        if (firstView) then
            runner.SetReact' dispatch
            firstView <- false
        args.Render runner model
    let subscribe = fun (model : 'model) ->
        args.Logic.Subscribe runner model
    let program =
        Program.mkProgram init update view
        |> Program.withSubscription subscribe
    program

let private init : ActorInit<Args<'pack, 'model, 'msg>, Model<'model, 'msg>, Msg<'model, 'msg>> =
    fun initer args ->
        let (model, cmd) = args.Logic.Init initer ()
        let program = initProgram initer args (model, cmd)
        ({
            Round = 1
            View = model
            Program = program
        }, noCmd)

let spec<'pack, 'model, 'msg when 'pack :> IPack and 'model : not struct and 'msg :> IMsg>
    (pack : 'pack) (args : Args<'pack, 'model, 'msg>) =
    new ActorSpec<View<'pack, 'model, 'msg>, Args<'pack, 'model, 'msg>, Model<'model, 'msg>, Msg<'model, 'msg>, Req, Evt>
        (View<'pack, 'model, 'msg>.Spawn pack, args, AppReq, castEvt<'model, 'msg>, init, update)
