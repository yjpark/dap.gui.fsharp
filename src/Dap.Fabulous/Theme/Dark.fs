[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Fabulous.Theme.Dark

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform

let param : FabulousTheme = {
    Colors = {
        Primary = Color.White
        Secondary = Color.Gray
        Background = Color.Black
    }
}