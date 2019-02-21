[<AutoOpen>]
module Dap.Gui.Gtk.Internal.Application

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.Gtk

type Application (param : ApplicationParam) =
    inherit Gtk.Application (param.Name, param.Flags)
    let logger : ILogger = getLogger param.Name
    let window = new Gtk.Window (param.Title)
    do (
        window.SetDefaultSize (param.Width, param.Height)
    )
    let mutable presenter : IPresenter option = None
    static member Init p =
        Gtk.Application.Init ()
        let app = new Application (p)
        setupGuiContext' app
        app.Setup ()
        app
    member private this.Setup () =
        this.Register (GLib.Cancellable.Current)
        |> ignore
    member __.SetPresenter (presenter' : IPresenter) =
        presenter <- Some presenter'
        window.Child <- presenter'.Prefab0.Widget0 :?> Gtk.Widget
    member __.Run () =
        window.ShowAll ()
        Gtk.Application.Run ()
    interface IApplication with
        member __.Param = param
        member __.Window = window
        member __.Presenter = presenter.Value
    member this.AsApplication = this :> IApplication
    interface ILogger with
        member __.Log evt = logger.Log evt
