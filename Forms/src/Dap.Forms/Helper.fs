[<AutoOpen>]
module Dap.Forms.Helper

open System.IO
open Xamarin.Forms

open Dap.Prelude
open Dap.Platform
open Dap.Local
open Dap.Forms.Feature

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
