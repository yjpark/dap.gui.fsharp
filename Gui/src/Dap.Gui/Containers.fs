[<AutoOpen>]
module Dap.Gui.Containers

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Context.Generator.Util

type IPanel =
    inherit IContainer

type IHBox =
    inherit IContainer

type IVBox =
    inherit IContainer

type ITable =
    inherit IContainer


type ContainerKind = ContainerKind
with
    static member Panel = "panel"
    static member HBox = "h_box"
    static member VBox = "v_box"
    static member Table = "table"
    static member ParseToPrefab (kind : string) : string =
        kind.AsCodeMemberName
