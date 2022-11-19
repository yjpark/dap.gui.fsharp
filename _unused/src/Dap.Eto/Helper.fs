[<AutoOpen>]
module Dap.Eto.Helper

open Eto
open Eto.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let createEtoApplication (platform : Eto.Platform) =
    new Application (platform)
