[<AutoOpen>]
module Dap.Console.Delegates

open Terminal.Gui

type IKeyboardDelegate =
    abstract ProcessKey : (KeyEvent -> bool) option
    abstract ProcessHotKey : (KeyEvent -> bool) option
    abstract ProcessColdKey : (KeyEvent -> bool) option
