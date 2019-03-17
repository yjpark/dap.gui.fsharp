[<AutoOpen>]
module Dap.Gui.Util

open Xamarin.Essentials

open Dap.Prelude
open Dap.Platform

let hasEssentials () =
    DeviceInfo.Platform <> DevicePlatform.Unknown

let getDeviceName () =
    if hasEssentials () then
        DeviceInfo.Name
    else
        System.Environment.MachineName