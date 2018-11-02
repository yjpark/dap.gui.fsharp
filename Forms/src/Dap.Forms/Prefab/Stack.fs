[<AutoOpen>]
module Dap.Forms.Prefab.Stack

//SILP: COMMON_OPENS
open System                                                           //__SILP__
open Xamarin.Forms                                                    //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type StackWidget = Xamarin.Forms.StackLayout

//SILP: GROUP_HEADER_MIDDLE(Stack)
type Stack (logging : ILogging) =                                     //__SILP__
    inherit BaseGroup<Stack, StackProps, StackWidget, View>           //__SILP__
        (StackKind, StackProps.Create, logging, new StackWidget ())   //__SILP__
    do (                                                              //__SILP__
        let kind = StackKind                                          //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let model = base.Model                                        //__SILP__
        let widget = base.Widget                                      //__SILP__
        model.Layout.OnChanged.AddWatcher owner kind (fun evt ->
            match evt.New with
            | LayoutConst.Horizontal_Stack ->
                widget.Orientation <- StackOrientation.Horizontal
            | LayoutConst.Vertical_Stack ->
                widget.Orientation <- StackOrientation.Vertical
            | _ ->
                logError owner "Stack" "Invalid_Layout" evt.New
        )
    )
    override this.AddChild (child : View) =
        this.Widget.Children.Add child
    //SILP: PREFAB_FOOTER(Stack)
    static member Create l = new Stack (l)                            //__SILP__
    static member Create () = new Stack (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Stack.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface IStack