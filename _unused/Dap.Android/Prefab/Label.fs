[<AutoOpen>]
module Dap.Android.Prefab.Label

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

type LabelWidget = Android.Widget.TextView

//SILP: PREFAB_HEADER_MIDDLE_CREATE(Label)
type Label (logging : ILogging) =                                        //__SILP__
    inherit BasePrefab<Label, LabelProps, LabelWidget>                   //__SILP__
        (LabelKind, LabelProps.Create, logging, IPrefab.CreateLabel ())  //__SILP__
    do (                                                                 //__SILP__
        let kind = LabelKind                                             //__SILP__
        let owner = base.AsOwner                                         //__SILP__
        let model = base.Model                                           //__SILP__
        let widget = base.Widget                                         //__SILP__
        model.Text.OnChanged.AddWatcher owner kind (fun evt ->
            runGuiFunc (fun () ->
                widget.Text <- evt.New
            )
        )
    )
    //SILP: PREFAB_FOOTER(Label)
    static member Create l = new Label (l)                            //__SILP__
    static member Create () = new Label (getLogging ())               //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Label.Create l                              //__SILP__
    interface IFallback                                               //__SILP__
    interface ILabel