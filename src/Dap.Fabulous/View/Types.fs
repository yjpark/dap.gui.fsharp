module Dap.Fabulous.View.Types

open System.Threading.Tasks
open FSharp.Control.Tasks.V2
open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform
open Dap.Local

[<Literal>]
let Kind = "FormsView"

type Widget = Fabulous.DynamicViews.ViewElement

type Initer<'model, 'msg when 'model : not struct and 'msg :> IMsg> =
    IAgent<Msg<'model, 'msg>>

and Render<'pack, 'model, 'msg
            when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> =
    View<'pack, 'model, 'msg> -> 'model -> Widget

and ViewLogic<'pack, 'model, 'msg
            when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> =
    Logic<Initer<'model, 'msg>, View<'pack, 'model, 'msg>, unit, 'model, 'msg>

and Args<'pack, 'model, 'msg
            when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> = {
    Logic : ViewLogic<'pack, 'model, 'msg>
    Render : Render<'pack, 'model, 'msg>
    UseLiveUpdate : bool
    UseConsoleTrace : bool
} with
    static member Create init update subscribe render =
        {
            Logic =
                {
                    Init = init
                    Update = update
                    Subscribe = subscribe
                }
            Render = render
#if DEBUG
            UseLiveUpdate = true
            UseConsoleTrace = true
#else
            UseLiveUpdate = false
            UseConsoleTrace = false
#endif
        }

and Model<'model, 'msg
            when 'model : not struct and 'msg :> IMsg> = {

    Round : int
    mutable View : 'model
    Program : Program<'model, 'msg, 'model -> ('msg -> unit) -> Widget>
}

and Req =
    | DoRun of Callback<unit>
with interface IReq

and Evt = NoEvt

and Msg<'model, 'msg
            when 'model : not struct and 'msg :> IMsg> =
    | AppReq of Req
    | AppEvt of Evt
with interface IMsg

and View<'pack, 'model, 'msg when 'pack :> IPack and 'model : not struct and 'msg :> IMsg> (pack : 'pack, param) =
    inherit PackAgent<'pack, View<'pack, 'model, 'msg>, Args<'pack, 'model, 'msg>, Model<'model, 'msg>, Msg<'model, 'msg>, Req, Evt> (pack, param)
    let mutable react : ('msg -> unit) option = None
    let mutable formsRunner : obj option = None
    static member Spawn pack' param' = new View<'pack, 'model, 'msg> (pack', param')
    override this.Runner = this
    member this.Program = this.Actor.State.Program
    member this.ViewState = this.Actor.State.View
    member _this.HasFormsRunner = formsRunner.IsSome
    member this.SetFormsRunner' runner =
#if DEBUG
        if this.Actor.Args.UseLiveUpdate then
            () //TODO
            //runner.EnableLiveUpdate ()
#endif
        formsRunner <- Some runner
    member _this.SetReact' react' =
        react <- Some react'
    member _this.React (msg : 'msg) =
        react
        |> Option.iter (fun d -> d msg)
    member this.StartAsync () : Task<unit> = task {
        do! this.PostAsync DoRun
    }

let castEvt<'model, 'msg when 'model : not struct and 'msg :> IMsg>
                : CastEvt<Msg<'model, 'msg>, Evt> =
    function
    | AppEvt evt -> Some evt
    | _ -> None
