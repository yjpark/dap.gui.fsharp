[<AutoOpen>]
module Dap.Gui.Mac.Prefab.Table

//SILP: MAC_OPENS
open Foundation                                                       //__SILP__
open AppKit                                                           //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

//TODO: Create real table based on GridView or ListControl

type TableWidget = NSStackView

//SILP: GROUP_HEADER_MIDDLE(FullList, Table, NSView)
type Table (logging : ILogging) =                                     //__SILP__
    inherit BaseFullList<Table, TableProps, TableWidget, NSView>      //__SILP__
        (TableKind, TableProps.Create, logging, new TableWidget ())   //__SILP__
    do (                                                              //__SILP__
        let kind = TableKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let model = base.Model                                        //__SILP__
        let widget = base.Widget                                      //__SILP__
        widget.Orientation <- NSUserInterfaceLayoutOrientation.Vertical
    )
    override this.AddChild (child : NSView) =
        this.Widget.AddView (child, NSStackViewGravity.Bottom)
    override this.RemoveChild (child : NSView) =
        this.Widget.RemoveView (child)
    //SILP: PREFAB_FOOTER(Table)
    static member Create l = new Table (l)                            //__SILP__
    static member Create () = new Table (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Table.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IFullTable
