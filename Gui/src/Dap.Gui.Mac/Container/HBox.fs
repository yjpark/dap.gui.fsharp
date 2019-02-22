[<AutoOpen>]
module Dap.Gui.Mac.Prefab.HBox

//SILP: MAC_OPENS
open Foundation                                                       //__SILP__
open AppKit                                                           //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type HBoxWidget = NSStackView

//SILP: CONTAINER_HEADER_MIDDLE(HBox, NSView)
type HBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<HBox, HBoxWidget, NSView>                   //__SILP__
        (HBoxKind, logging, new HBoxWidget ())                        //__SILP__
    do (                                                              //__SILP__
        let kind = HBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        widget.Orientation <- NSUserInterfaceLayoutOrientation.Horizontal
    )
    override this.AddChild (child : NSView) =
        this.Widget.AddArrangedSubview (child)
    override this.RemoveChild (child : NSView) =
        child.RemoveFromSuperview ()
    //SILP: CONTAINER_FOOTER(HBox)
    static member Create l = new HBox (l)                             //__SILP__
    static member Create () = new HBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = HBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IHBox
