[<AutoOpen>]
module Dap.Gui.App.Types

open Dap.Prelude
open Dap.Platform
open Dap.Gui

//Note: It's IGuiPlatform's responsibility to start the app at right time
type IGuiPlatform =
    inherit IFeature
    abstract Runtime : GuiRuntime with get
    abstract App : IBaseApp with get
    abstract Param0 : obj with get
    abstract Display : IDisplay option with get
    abstract Init : IBaseApp -> obj -> unit
    abstract Show<'presenter when 'presenter :> IPresenter> : 'presenter -> IDisplay<'presenter>
    abstract OnDidAttach : IPack -> unit
    abstract Run : unit -> int

type Display<'presenter, 'output when 'presenter :> IPresenter> (output : 'output) =
    inherit BaseDisplay<'presenter, 'output> (output)