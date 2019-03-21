[<RequireQualifiedAccess>]
module Dap.UWP.Feature.UWPPlatform

open System
open System.Threading

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.UWP

type Context (logging : ILogging) =
    inherit GuiPlatform.Context<UWPParam, string> (logging, Windows_UWP)
    override this.DoInit (param : UWPParam) =
        ()
    override this.DoShow (param : UWPParam, presenter : IPresenter) =
        logWarn this "DoShow" param.Name (presenter)
        (*
        let view = presenter.Prefab0.Widget0 :?> Widget
        param.Activity.SetContentView (view)
        param.BackgroundColor
        |> Option.iter (fun color ->
            view.SetBackgroundColor (color)
        )
        param.Activity
        *)
        param.Name
    override this.DoRun (param : UWPParam) =
        param.Actions
        |> List.iter (fun action -> action this)
        //Note: UWP's Run will not block, since it's not called from main()
        0
    interface IUWPPlatform with
        member this.Param = this.Param
    member this.AsUWPPlatform = this :> IUWPPlatform
    interface IFallback
