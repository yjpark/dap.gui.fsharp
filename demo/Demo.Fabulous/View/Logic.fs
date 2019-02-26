[<RequireQualifiedAccess>]
module Demo.Fabulous.View.Logic

open FSharp.Control.Tasks.V2

open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform

open Demo.App
open Demo.Fabulous.View.Types
open Demo.Fabulous.Page

type LayoutOptions = Xamarin.Forms.LayoutOptions

let private init : Init<Initer, unit, Model, Msg> =
    fun initer () ->
        ({
            Page = HomePage
            Ver = 1
        }, noCmd)

let private update : Update<View, Model, Msg> =
    fun runner msg model ->
        logWarn runner "View" "update" (msg, model)
        let model = {model with Ver = model.Ver + 1}
        match msg with
        | DoRepaint ->
            (model, noCmd)

let private render : Render =
    fun runner model ->
        logWarn runner "View" "render" model.Page
        match model.Page with
        | HomePage ->
            Home.render runner model

let args application =
    Args.Create init update noSubscription render application

let newArgs () =
    Dap.Fabulous.Util.newApplication ()
    |> args