[<AutoOpen>]
module Dap.Fabulous.Util

open System.Threading.Tasks
open Xamarin.Essentials
open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform

let isMockForms () =
    try
        Device.Info = null
    with _ ->
        true

let isRealForms () =
    not <| isMockForms ()

let hasEssentials () =
    if isRealForms () then
        Device.RuntimePlatform = Device.iOS
            || Device.RuntimePlatform = Device.Android
            || Device.RuntimePlatform = Device.UWP
    else
        false

let getDeviceName () =
    if hasEssentials () then
        DeviceInfo.Name
    else
        System.Environment.MachineName

(*
 * All platform package should handle this by themselves
type ConsoleSinkArgs with
    static member FormsProvider (this : ConsoleSinkArgs) =
        if isRealForms () then
            let device = Device.RuntimePlatform
            not (device = Device.macOS || device = Device.iOS || device = Device.Android)
        else
            true
        |> function
            | true -> this.ToAddSink ()
            | false -> id
*)
