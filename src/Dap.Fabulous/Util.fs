[<AutoOpen>]
module Dap.Fabulous.Util

open System.Threading.Tasks
open Xamarin.Essentials
open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform
open Dap.Gui

let isMockForms () =
    try
        Device.Info = null
    with _ ->
        true

let isRealForms () =
    not <| isMockForms ()

type ITheme with
    member this.DecorateFabulous<'widget when 'widget :> Element> (widget : 'widget) =
        let kinds =
            if System.String.IsNullOrEmpty (widget.ClassId) then
                []
            else
                widget.ClassId.Split [| ';' |]
                |> Array.map (fun c -> c.Trim ())
                |> Array.toList
        this.DecorateWidget (widget, kinds)