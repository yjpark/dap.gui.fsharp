[<AutoOpen>]
module Dap.Eto.Prefab.Table

//SILP: COMMON_OPENS
open System                                                           //__SILP__
open Eto.Forms                                                        //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

//TODO: Create real table based on GridView or ListControl

type TableWidget = Eto.Forms.StackLayout

//SILP: GROUP_HEADER_MIDDLE(FullList, Table)
type Table (logging : ILogging) =                                     //__SILP__
    inherit BaseFullList<Table, TableProps, TableWidget, Control>     //__SILP__
        (TableKind, TableProps.Create, logging, new TableWidget ())   //__SILP__
    do (                                                              //__SILP__
        let kind = TableKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let model = base.Model                                        //__SILP__
        let widget = base.Widget                                      //__SILP__
        widget.Orientation <- Orientation.Vertical
    )
    override this.AddChild (child : Control) =
        this.Widget.Items.Add <| new StackLayoutItem (child)
    override this.RemoveChild (child : Control) =
        this.Widget.Items
        |> Seq.filter (fun item -> item.Control = child)
        |> List.ofSeq
        |> List.iter (this.Widget.Items.Remove >> ignore)
    //SILP: PREFAB_FOOTER(Table)
    static member Create l = new Table (l)                            //__SILP__
    static member Create () = new Table (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Table.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IFullTable
