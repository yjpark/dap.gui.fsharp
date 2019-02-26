[<AutoOpen>]
module Dap.Gui.App.Types

open Dap.Prelude
open Dap.Platform
open Dap.Gui

type IGuiPlatform =
    inherit IFeature
    abstract Param0 : obj with get
    abstract Display : IDisplay with get
    abstract Setup<'presenter when 'presenter :> IPresenter> : obj -> 'presenter -> IDisplay<'presenter>
    abstract Run : unit -> int

type Display<'presenter, 'output when 'presenter :> IPresenter> (output : 'output) =
    inherit BaseDisplay<'presenter, 'output> (output)