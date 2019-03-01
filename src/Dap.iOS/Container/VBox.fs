[<AutoOpen>]
module Dap.iOS.Prefab.VBox

//SILP:IOS_OPENS
open Foundation                                                       //__SILP__
open UIKit                                                           //__SILP__
open Dap.iOS                                                          //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type VBoxWidget = UIStackView

//SILP: CONTAINER_HEADER_MIDDLE(VBox, UIView)
type VBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<VBox, VBoxWidget, UIView>                   //__SILP__
        (VBoxKind, logging, new VBoxWidget ())                        //__SILP__
    do (                                                              //__SILP__
        let kind = VBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        runGuiFunc (fun () ->
            widget.Axis <- UILayoutConstraintAxis.Vertical
        )
    )
    override this.AddChild (child : NSView) =
        runGuiFunc (fun () ->
            this.Widget.AddArrangedSubview (child)
        )
    override this.RemoveChild (child : NSView) =
        runGuiFunc (fun () ->
            child.RemoveFromSuperview ()
        )
    //SILP: CONTAINER_FOOTER(VBox)
    static member Create l = new VBox (l)                             //__SILP__
    static member Create () = new VBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = VBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IVBox
