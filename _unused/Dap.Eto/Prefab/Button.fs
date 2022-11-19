[<AutoOpen>]
module Dap.Eto.Prefab.Button

//SILP: COMMON_OPENS
open System                                                           //__SILP__
open Eto.Forms                                                        //__SILP__
open Dap.Prelude                                                      //__SILP__
open Dap.Context                                                      //__SILP__
open Dap.Platform                                                     //__SILP__
open Dap.Gui                                                          //__SILP__
open Dap.Gui.Prefab                                                   //__SILP__
open Dap.Gui.Internal                                                 //__SILP__
open Eto.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab
open Dap.Gui.Internal

type ButtonWidget = Eto.Forms.Button

//SILP: PREFAB_HEADER(Button)
type Button (logging : ILogging) =                                      //__SILP__
    inherit BasePrefab<Button, ButtonProps, ButtonWidget>               //__SILP__
        (ButtonKind, ButtonProps.Create, logging, new ButtonWidget ())  //__SILP__
    let onClick = IButton.AddChannels base.Channels
    //SILP: PREFAB_MIDDLE(Button)
    do (                                                              //__SILP__
        let kind = ButtonKind                                         //__SILP__
        let owner = base.AsOwner                                      //__SILP__
        let model = base.Model                                        //__SILP__
        let widget = base.Widget                                      //__SILP__
        model.Text.OnChanged.AddWatcher owner kind (fun evt ->
            widget.Text <- evt.New
        )
        widget.Click.Add (fun _ ->
            onClick.FireEvent ()
        )
    )
    member __.OnClick : IChannel<unit> = onClick
    //SILP: PREFAB_FOOTER(Button)
    static member Create l = new Button (l)                           //__SILP__
    static member Create () = new Button (getLogging ())              //__SILP__
    override this.Self = this                                         //__SILP__
    override __.Spawn l = Button.Create l                             //__SILP__
    interface IFallback                                               //__SILP__
    interface IButton with
        member __.OnClick = onClick