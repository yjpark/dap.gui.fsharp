[<AutoOpen>]
module Dap.Android.Prefab.HBox

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

type HBoxWidget = Android.Widget.LinearLayout


//SILP: CONTAINER_HEADER_MIDDLE_CREATE(HBox, Widget)
type HBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<HBox, HBoxWidget, Widget>                   //__SILP__
        (HBoxKind, logging, IContainer.CreateHBox ())                 //__SILP__
    do (                                                              //__SILP__
        let kind = HBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        runGuiFunc (fun () ->
            widget.Orientation <- Android.Widget.Orientation.Horizontal
        )
    )
    override this.AddChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.AddView (child)
        )
    override this.RemoveChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.RemoveView (child)
        )
    //SILP: CONTAINER_FOOTER(HBox)
    static member Create l = new HBox (l)                             //__SILP__
    static member Create () = new HBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = HBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IHBox
