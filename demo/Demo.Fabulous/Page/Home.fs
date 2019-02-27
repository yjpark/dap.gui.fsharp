[<RequireQualifiedAccess>]
module Demo.Fabulous.Page.Home

open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform

open Demo.App
open Demo.Fabulous
open Demo.Fabulous.View.Types

let render (runner : View) (model : Model) =
    View.ContentPage (
        content = View.StackLayout (
            padding = 20.0,
            children = [
                View.Label (text = "TODO")
            ]
        )
    )