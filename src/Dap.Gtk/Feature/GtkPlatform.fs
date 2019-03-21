[<RequireQualifiedAccess>]
module Dap.Gtk.Feature.GtkPlatform

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Dap.Gui
open Dap.Gui.App
open Dap.Gtk

type Context (logging : ILogging) =
    inherit GuiPlatform.Context<GtkParam, Gtk.Window> (logging, DotNetCore_Gtk)
    let mutable application : Gtk.Application option = None
    let mutable window : Gtk.Window option = None
    override this.DoInit (param : GtkParam) =
        Gtk.Application.Init ()
        application <- Some <| new Gtk.Application (param.Name, param.Flags)
        application.Value.Register (GLib.Cancellable.Current) |> ignore
        window <- Some <| new Gtk.Window (param.Title)
        window.Value.SetDefaultSize (param.Width, param.Height)
    override this.DoShow (param : GtkParam, presenter : IPresenter) =
        window.Value.Child <- presenter.Prefab0.Widget0 :?> Widget
        window.Value
    override this.DoRun (param : GtkParam) =
        window.Value.ShowAll ()
        Gtk.Application.Run ()
        0
    interface IGtkPlatform with
        member this.Param = this.Param
        member __.Application = application.Value
        member __.Window = window.Value
    member this.AsGtkPlatform = this :> IGtkPlatform
