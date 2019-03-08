[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Fabulous.Theme.Light

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform

let param : FabulousTheme = {
    Colors = {
        Primary = Color.Black
        Secondary = Color.Gray
        Background = Color.White
    }
}