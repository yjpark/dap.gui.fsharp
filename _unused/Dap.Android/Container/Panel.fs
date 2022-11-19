[<AutoOpen>]
module Dap.Android.Prefab.Panel

//SILP: ANDROID_OPENS
open Dap.Android                                                      //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type PanelWidget = Android.Widget.FrameLayout


//SILP: CONTAINER_HEADER_MIDDLE_CREATE(Panel, Widget)
type Panel (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Panel, PanelWidget, Widget>                 //__SILP__
        (PanelKind, logging, IContainer.CreatePanel ())               //__SILP__
    do (                                                              //__SILP__
        let kind = PanelKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.AddView (child)
        )
    override this.RemoveChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.RemoveView (child)
        )
    //SILP: CONTAINER_FOOTER(Panel)
    static member Create l = new Panel (l)                            //__SILP__
    static member Create () = new Panel (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Panel.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IPanel
