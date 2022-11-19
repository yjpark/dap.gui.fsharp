[<AutoOpen>]
module Dap.Android.Prefab.Table

//SILP: ANDROID_OPENS
open Dap.Android                                                      //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

//TODO: Create real table based on GridView or ListControl

type TableWidget = Android.Widget.LinearLayout

//SILP: CONTAINER_HEADER_MIDDLE_CREATE(Table, Widget)
type Table (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Table, TableWidget, Widget>                 //__SILP__
        (TableKind, logging, IContainer.CreateTable ())               //__SILP__
    do (                                                              //__SILP__
        let kind = TableKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        runGuiFunc (fun () ->
            widget.Orientation <- Android.Widget.Orientation.Vertical
        )
    )
    override this.AddChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.AddView (child)
        )
    override this.RemoveChild (child : Widget) =
        runGuiFunc (fun () ->
            this.Widget.RemoveView (child)
        )
    //SILP: CONTAINER_FOOTER(Table)
    static member Create l = new Table (l)                            //__SILP__
    static member Create () = new Table (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Table.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface ITable
