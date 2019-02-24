[<AutoOpen>]
module Dap.Mac.Prefab.Table

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

type TableWidget = Gtk.ListBox

//SILP: CONTAINER_HEADER_MIDDLE(Table, Gtk.Widget)
type Table (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Table, TableWidget, Gtk.Widget>             //__SILP__
        (TableKind, logging, new TableWidget ())                      //__SILP__
    do (                                                              //__SILP__
        let kind = TableKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : Gtk.Widget) =
        this.Widget.Add(child)
    override this.RemoveChild (child : Gtk.Widget) =
        child.Parent <- null
    //SILP: PREFAB_FOOTER(Table)
    static member Create l = new Table (l)                            //__SILP__
    static member Create () = new Table (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Table.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface ITable
