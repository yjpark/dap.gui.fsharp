[<AutoOpen>]
module Dap.Gui.Myra.ApplicationParam

open Dap.Prelude

open Game.Engine.Addon

let withExitKey (key : Keys) (param : ApplicationParam) : ApplicationParam =
    {param with ExitKey = Some key}

let withSetup (setup : IApplication -> unit) (param : ApplicationParam) : ApplicationParam =
    {param with Initializers = param.Initializers @ [setup]}
