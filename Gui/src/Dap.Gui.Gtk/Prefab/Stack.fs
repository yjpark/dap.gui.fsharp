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
open Dap.Gui.Internal                                                 //__SILP__

type StackWidget = GtkPanel

//SILP: GROUP_HEADER_MIDDLE(Combo, Stack, GtkWidget)
type Stack (logging : ILogging) =                                     //__SILP__
    inherit BaseCombo<Stack, StackProps, StackWidget, GtkWidget>      //__SILP__
        (StackKind, StackProps.Create, logging, new StackWidget ())   //__SILP__
    do (                                                              //__SILP__
        let kind = StackKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let model = base.Model                                        //__SILP__
        let widget = base.Widget                                      //__SILP__
        model.Layout.OnChanged.AddWatcher owner kind (fun evt ->
            match evt.New with
            | LayoutConst.Combo_Horizontal_Stack ->
                ()
            | LayoutConst.Combo_Vertical_Stack ->
                ()
            | _ ->
                logError owner "Stack" "Invalid_Layout" evt.New
        )
    )
    override this.AddChild (child : GtkWidget) =
        this.Widget.PackStart(child, false, false, (uint32) 0)
    //SILP: PREFAB_FOOTER(Stack)
    static member Create l = new Stack (l)                            //__SILP__
    static member Create () = new Stack (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Stack.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IStack
