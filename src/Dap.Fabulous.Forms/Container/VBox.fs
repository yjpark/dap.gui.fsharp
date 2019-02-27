[<AutoOpen>]
module Dap.Fabulous.Forms.Prefab.VBox

//SILP: FORMS_OPENS
open Xamarin.Forms                                                    //__SILP__
open System                                                           //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Container                                                //__SILP__
open Dap.Gui.Internal                                                 //__SILP__

type VBoxWidget = StackLayout

//SILP: CONTAINER_HEADER_MIDDLE(VBox, View)
type VBox (logging : ILogging) =                                      //__SILP__
    inherit BaseContainer<VBox, VBoxWidget, View>                     //__SILP__
        (VBoxKind, logging, new VBoxWidget ())                        //__SILP__
    do (                                                              //__SILP__
        let kind = VBoxKind                                           //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let widget = base.Widget                                      //__SILP__
        widget.Orientation <- StackOrientation.Vertical
    )
    override this.AddChild (child : View) =
        this.Widget.Children.Add (child)
    override this.RemoveChild (child : View) =
        this.Widget.Children.Remove (child) |> ignore
    //SILP: CONTAINER_FOOTER(VBox)
    static member Create l = new VBox (l)                             //__SILP__
    static member Create () = new VBox (getLogging ())                //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = VBox.Create l                               //__SILP__
    interface IFallback                                               //__SILP__
    interface IVBox
