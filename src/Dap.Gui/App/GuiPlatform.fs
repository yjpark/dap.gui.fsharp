[<RequireQualifiedAccess>]
module Dap.Gui.App.GuiPlatform

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui

[<AbstractClass>]
type Context<'param, 'output> (logging : ILogging, kind : string) =
    inherit EmptyContext (logging, kind)
    let mutable param : 'param option = None
    let mutable output : 'output option = None
    let mutable display : IDisplay option = None
    abstract member DoInit : 'param -> unit
    abstract member DoSetup : 'param -> IPresenter -> 'output
    abstract member DoRun : 'param -> int
    abstract member OnDidAttach : IPack -> unit
    default __.OnDidAttach (_app : IPack) = ()
    member __.Param = param.Value
    member __.Output = output.Value
    interface IGuiPlatform with
        member __.Param0 = param :> obj
        member __.Display = display.Value
        member this.Init param' =
            if param.IsSome then
                failWith "Already_Init" (param, param')
            param <- Some (param' :?> 'param)
            this.DoInit param.Value
        member this.Setup presenter' =
            if display.IsSome then
                failWith "Already_Setup" (display, presenter')
            let output' = this.DoSetup param.Value presenter'
            output <- Some output'
            let display' = new Display<'presenter, 'output> (output')
            display'.SetPresenter presenter'
            display <- Some (display' :> IDisplay)
            display' :> IDisplay<'presenter>
        member this.OnDidAttach app = this.OnDidAttach app
        member this.Run () = this.DoRun param.Value
    member this.AsGuiPlatform = this :> IGuiPlatform