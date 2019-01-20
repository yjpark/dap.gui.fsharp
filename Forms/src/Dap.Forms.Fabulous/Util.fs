[<AutoOpen>]
module Dap.Forms.Fabulous.Util

open System.Threading.Tasks
open Xamarin.Essentials
open Xamarin.Forms
open Fabulous.Core
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform
open Dap.Forms

let newApplication () =
    if isRealForms () then
        let application = new Application ()
        let emptyPage = View.ContentPage (content = View.Label (text = "TEST"))
        let page = emptyPage.Create ()
        application.MainPage <- page :?> Page
        application
    else
        failWith "newApplication" "Is_Not_Real_Forms"