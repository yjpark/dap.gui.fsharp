[<AutoOpen>]
module Dap.Gui.Mac.Prefab.Stack

//SILP: GTK_OPENS
open Dap.Gui.Gtk                                                      //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type PanelWidget = Gtk.Fixed

//SILP: CONTAINER_HEADER_MIDDLE(Panel, Gtk.Widget)
type Panel (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Panel, PanelWidget, Gtk.Widget>             //__SILP__
        (PanelKind, logging, new PanelWidget ())                      //__SILP__
    do (                                                              //__SILP__
        let kind = PanelKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : Gtk.Widget) =
        this.Widget.Put(child, 0, 0)
    //SILP: PREFAB_FOOTER(Panel)
    static member Create l = new Panel (l)                            //__SILP__
    static member Create () = new Panel (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Panel.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    override this.RemoveChild (child : Gtk.Widget) =
        child.Parent <- null
    interface IPanel
