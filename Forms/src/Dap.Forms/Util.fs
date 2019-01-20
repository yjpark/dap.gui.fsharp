[<AutoOpen>]
module Dap.Forms.Util

open System.Threading.Tasks
open Xamarin.Essentials
open Xamarin.Forms

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
