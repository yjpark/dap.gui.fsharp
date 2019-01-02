[<AutoOpen>]
module Dap.Console.Prefab.Stack

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

type StackWidget = Panel

//SILP: GROUP_HEADER_MIDDLE(Combo, Stack)
type Stack (logging : ILogging) =                                       //__SILP__
    inherit BaseCombo<Stack, StackProps, StackWidget, View>             //__SILP__
        (StackKind, StackProps.Create, logging, StackWidget.Create ())  //__SILP__
    do (                                                                //__SILP__
        let kind = StackKind                                            //__SILP__
        let owner = base.AsOwner                                        //__SILP__
        let model = base.Model                                          //__SILP__
        let widget = base.Widget                                        //__SILP__
        model.Layout.OnChanged.AddWatcher owner kind (fun evt ->
            logError owner "Stack" "Invalid_Layout" evt.New
        )
    )
    override this.AddChild (child : View) =
        this.Widget.Add (child)
    //SILP: PREFAB_FOOTER(Stack)
    static member Create l = new Stack (l)                            //__SILP__
    static member Create () = new Stack (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Stack.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IStack
