[<AutoOpen>]
module Dap.Gui.Mac.Prefab.Stack

//SILP: MAC_OPENS
open Foundation                                                       //__SILP__
open AppKit                                                           //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type StackWidget = NSStackView

//SILP: CONTAINER_HEADER_MIDDLE(Stack, NSView)
type Stack (logging : ILogging) =                                     //__SILP__
    inherit BaseContainer<Stack, StackWidget, NSView>                 //__SILP__
        (StackKind, logging, new StackWidget ())                      //__SILP__
    do (                                                              //__SILP__
        let kind = StackKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        model.Layout.OnChanged.AddWatcher owner kind (fun evt ->
            match evt.New with
            | LayoutConst.Combo_Horizontal_Stack ->
                widget.Orientation <- NSUserInterfaceLayoutOrientation.Horizontal
            | LayoutConst.Combo_Vertical_Stack ->
                widget.Orientation <- NSUserInterfaceLayoutOrientation.Vertical
            | _ ->
                logError owner "Stack" "Invalid_Layout" evt.New
        )
    )
    override this.AddChild (child : NSView) =
        match this.Model.Layout.Value with
        | LayoutConst.Combo_Horizontal_Stack ->
            this.Widget.AddView (child, NSStackViewGravity.Trailing)
        | LayoutConst.Combo_Vertical_Stack ->
            this.Widget.AddView (child, NSStackViewGravity.Bottom)
        | _ as layout ->
            logError this "Stack" "Invalid_Layout" layout
    //SILP: CONTAINER_FOOTER(Stack)
    static member Create l = new Stack (l)                            //__SILP__
    static member Create () = new Stack (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Stack.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IStack
