[<AutoOpen>]
module Dap.Gui.App.Types

open Dap.Prelude
open Dap.Platform
open Dap.Gui

type IGuiPlatform =
    inherit IFeature
    abstract Param0 : obj with get
    abstract Display : IDisplay option with get
    abstract Init : obj -> unit
    abstract Show<'presenter when 'presenter :> IPresenter> : 'presenter -> IDisplay<'presenter>
    abstract OnDidAttach : IPack -> unit
    abstract Run : unit -> int

type Display<'presenter, 'output when 'presenter :> IPresenter> (output : 'output) =
    inherit BaseDisplay<'presenter, 'output> (output)