[<AutoOpen>]
module Dap.Console.Prefab.FullTable

//SILP: COMMON_OPENS
open System                                                           //__SILP__
open Terminal.Gui                                                     //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__
open Dap.Console                                                      //__SILP__

type FullTableWidget = Terminal.Gui.ScrollView


//SILP: GROUP_HEADER_MIDDLE(FullList, FullTable)
type FullTable (logging : ILogging) =                                               //__SILP__
    inherit BaseFullList<FullTable, FullTableProps, FullTableWidget, View>          //__SILP__
        (FullTableKind, FullTableProps.Create, logging, FullTableWidget.Create ())  //__SILP__
    do (                                                                            //__SILP__
        let kind = FullTableKind                                                    //__SILP__
        let owner = base.AsOwner                                                    //__SILP__
        let model = base.Model                                                      //__SILP__
        let widget = base.Widget                                                    //__SILP__
        ()
    )
    override this.AddChild (child : View) =
        this.Widget.Add (child)
    override this.RemoveChild (child : View) =
        this.Widget.Remove child
    interface IFullTable
//SILP: PREFAB_FOOTER(FullTable)
    static member Create l = new FullTable (l)                        //__SILP__
    static member Create () = new FullTable (getLogging ())           //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = FullTable.Create l                          //__SILP__
    interface IFallback                                               //__SILP__
                                                                      //__SILP__
type IFullTable with                                                  //__SILP__
    member this.AsFullTable = this :?> FullTable                      //__SILP__
