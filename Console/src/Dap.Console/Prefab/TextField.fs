[<AutoOpen>]
module Dap.Console.Prefab.TextField

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

type TextFieldWidget = Terminal.Gui.TextField

//SILP: PREFAB_HEADER_MIDDLE(TextField)
type TextField (logging : ILogging) =                                               //__SILP__
    inherit BasePrefab<TextField, TextFieldProps, TextFieldWidget>                  //__SILP__
        (TextFieldKind, TextFieldProps.Create, logging, TextFieldWidget.Create ())  //__SILP__
    do (                                                                            //__SILP__
        let kind = TextFieldKind                                                    //__SILP__
        let owner = base.AsOwner                                                    //__SILP__
        let model = base.Model                                                      //__SILP__
        let widget = base.Widget                                                    //__SILP__
        model.Text.OnChanged.AddWatcher owner kind (fun evt ->
            widget.Text <- evt.New.ToUString ()
        )
        widget.Changed.AddHandler (new EventHandler (fun _sender _args ->
            model.Text.SetValue <| widget.Text.ToString ()
        ))
    )
    //SILP: PREFAB_FOOTER(TextField)
    static member Create l = new TextField (l)                        //__SILP__
    static member Create () = new TextField (getLogging ())           //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = TextField.Create l                          //__SILP__
    interface IFallback                                               //__SILP__
    interface ITextField