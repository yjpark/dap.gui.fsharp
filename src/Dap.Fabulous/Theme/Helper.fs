[<AutoOpen>]
module Dap.Fabulous.Theme.Helper

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.App

let getFabulousTheme (param : FabulousTheme) =
    (new Theme ()) .WithFabulous param

let getFabulousLightTheme () =
    (new Theme ()) .WithFabulous Light.param

let getFabulousDarkTheme () =
    (new Theme ()) .WithFabulous Dark.param

