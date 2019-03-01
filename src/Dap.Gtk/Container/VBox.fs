[<AutoOpen>]
module Dap.Gtk.Prefab.VBox

//SILP: GTK_OPENS
open Dap.Gtk                                                          //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type VBoxWidget = Gtk.VBox

//SILP: CONTAINER_HEADER_MIDDLE(VBox, Widget)
type VBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<VBox, VBoxWidget, Widget>                   //__SILP__
        (VBoxKind, logging, new VBoxWidget ())                        //__SILP__
    do (                                                              //__SILP__
        let kind = VBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : Widget) =
        this.Widget.PackStart(child, false, false, (uint32) 0)
    override this.RemoveChild (child : Widget) =
        child.Parent <- null
    //SILP: PREFAB_FOOTER(VBox)
    static member Create l = new VBox (l)                             //__SILP__
    static member Create () = new VBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = VBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IVBox
