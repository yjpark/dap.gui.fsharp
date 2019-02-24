[<AutoOpen>]
module Dap.Mac.Container.Table

//SILP: MYRA_OPENS
open Dap.Myra                                                         //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type TableWidget = Myra.Graphics2D.UI.Grid

//SILP: CONTAINER_HEADER_MIDDLE(Table, MyraWidget)
type Table (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Table, TableWidget, MyraWidget>             //__SILP__
        (TableKind, logging, new TableWidget ())                      //__SILP__
    do (                                                              //__SILP__
        let kind = TableKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : MyraWidget) =
        child.GridRow <- this.Widget.Widgets.Count
        this.Widget.Widgets.Add child
        this.Widget.RowsProportions.Add (new Proportion(ProportionType.Auto))
    override this.RemoveChild (child : MyraWidget) =
        this.Widget.RemoveChild child
    //SILP: CONTAINER_FOOTER(Table)
    static member Create l = new Table (l)                            //__SILP__
    static member Create () = new Table (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Table.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface ITable
