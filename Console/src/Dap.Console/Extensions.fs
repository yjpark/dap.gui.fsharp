[<AutoOpen>]
module Dap.Console.Extensions

open System
open NStack
open Terminal.Gui

type String with
    member this.ToUString () =
        ustring.Make (this)

let emptyUString = "".ToUString ()

type Terminal.Gui.Label with
    static member Create () =
        new Label (emptyUString)

type Terminal.Gui.Button with
    static member Create () =
        new Button (emptyUString)

type Terminal.Gui.TextField with
    static member Create () =
        new TextField (emptyUString)

type Terminal.Gui.ScrollView with
    static member Create () =
        new ScrollView (new Rect (0, 0, 10, 10))

type Panel(rect : Rect) =
    inherit Terminal.Gui.View (rect)
    static member Create () =
        new Panel (new Rect (0, 0, 10, 10))