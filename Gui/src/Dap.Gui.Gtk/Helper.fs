[<AutoOpen>]
module Dap.Gui.Gtk.Helper

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type AssemblyKeeper (logging : ILogging) =
    inherit EmptyContext (logging, "AssemblyKeeper")
    static member Keep l =
        new AssemblyKeeper (l) |> ignore

let runGtk<'presenter, 'app when 'presenter :> IPresenter<'app> and 'app :> IPack and 'app :> INeedSetupAsync>
    (newPresenter : IEnv -> 'presenter) (app : 'app) =
    //Needed, otherwise the dll might not be included in AppDomain
    AssemblyKeeper.Keep (app.Env.Logging)
    GuiApp<'presenter, 'app>.Run newPresenter app

let setGtkParam (param : ApplicationParam) =
    setParam param