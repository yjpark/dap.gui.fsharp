[<AutoOpen>]
module Dap.Myra.Prefab.HBox

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

type HBoxWidget = Myra.Graphics2D.UI.Grid

//SILP: CONTAINER_HEADER_MIDDLE(HBox, MyraWidget)
type HBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<HBox, HBoxWidget, MyraWidget>               //__SILP__
        (HBoxKind, logging, new HBoxWidget ())                        //__SILP__
    do (                                                              //__SILP__
        let kind = HBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        ()
    )
    override this.AddChild (child : MyraWidget) =
        child.GridColumn <- this.Widget.Widgets.Count
        this.Widget.ColumnsProportions.Add (new Proportion(ProportionType.Auto))
        this.Widget.Widgets.Add child
    override this.RemoveChild (child : MyraWidget) =
        this.Widget.RemoveChild child
    //SILP: CONTAINER_FOOTER(HBox)
    static member Create l = new HBox (l)                             //__SILP__
    static member Create () = new HBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = HBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IHBox
