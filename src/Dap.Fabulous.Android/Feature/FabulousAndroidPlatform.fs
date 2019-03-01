[<RequireQualifiedAccess>]
module Dap.Fabulous.Android.Feature.FabulousAndroidPlatform

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Fabulous
open Dap.Fabulous.Android
open Dap.Android
open Dap.Android.Feature

type Context (logging : ILogging) =
    inherit AndroidPlatform.Context (logging, FabulousAndroidPlatformKind)
    override this.DoShow (param : AndroidParam, presenter : IPresenter) =
        if hasFabulousParam () then
            param.Activity
        else
            base.DoShow (param, presenter)
    interface IOverride