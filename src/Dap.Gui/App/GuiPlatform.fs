[<RequireQualifiedAccess>]
module Dap.Gui.App.GuiPlatform

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui

[<AbstractClass>]
type Context<'param, 'output> (logging : ILogging, kind : string) =
    inherit EmptyContext (logging, kind)
    let mutable app : IBaseApp option = None
    let mutable param : 'param option = None
    let mutable output : 'output option = None
    let mutable display : IDisplay option = None
    abstract member ShouldStartAppBeforeRun : unit -> bool
    abstract member DoInit : 'param -> unit
    abstract member DoShow : 'param * IPresenter -> 'output
    abstract member DoRun : 'param -> int
    abstract member OnDidAttach : IPack -> unit
    default __.ShouldStartAppBeforeRun () = true
    default __.OnDidAttach (_app : IPack) = ()
    member __.App = app.Value
    member __.Param = param.Value
    member __.Output = output.Value
    member __.Display = display
    interface IGuiPlatform with
        member __.App = app.Value
        member __.Param0 = param.Value :> obj
        member __.Display = display
        member this.Init app' param' =
            if param.IsSome then
                failWith "Already_Init" (param, param')
            app <- Some app'
            param <- Some (param' :?> 'param)
            this.DoInit param.Value
        member this.Show presenter' =
            if display.IsSome then
                failWith "Already_Shown" (display, presenter')
            let output' = this.DoShow (param.Value, presenter')
            output <- Some output'
            let display' = new Display<'presenter, 'output> (output')
            display'.SetPresenter presenter'
            display <- Some (display' :> IDisplay)
            display' :> IDisplay<'presenter>
        member this.OnDidAttach app = this.OnDidAttach app
        member this.Run () =
            if this.ShouldStartAppBeforeRun () then
                Feature.tryStartApp app.Value
            this.DoRun param.Value
    member this.AsGuiPlatform = this :> IGuiPlatform