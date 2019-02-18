[<AutoOpen>]
module Dap.Gui.Mac.Prefab.FullTable

//SILP: MYRA_OPENS
open Dap.Gui.Myra                                                     //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type FullTableWidget = MyraPanel

//SILP: GROUP_HEADER_MIDDLE(FullList, FullTable, MyraWidget)
type FullTable (logging : ILogging) =                                             //__SILP__
    inherit BaseFullList<FullTable, FullTableProps, FullTableWidget, MyraWidget>  //__SILP__
        (FullTableKind, FullTableProps.Create, logging, new FullTableWidget ())   //__SILP__
    do (                                                                          //__SILP__
        let kind = FullTableKind                                                  //__SILP__
        let owner = base.AsOwner                                                  //__SILP__
        let model = base.Model                                                    //__SILP__
        let widget = base.Widget                                                  //__SILP__
        ()
    )
    override this.AddChild (child : MyraWidget) =
        this.Widget.Widgets.Add child
    override this.RemoveChild (child : MyraWidget) =
        this.Widget.RemoveChild child
    //SILP: PREFAB_FOOTER(FullTable)
    static member Create l = new FullTable (l)                        //__SILP__
    static member Create () = new FullTable (getLogging ())           //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = FullTable.Create l                          //__SILP__
    interface IFallback                                               //__SILP__
    interface IFullTable
