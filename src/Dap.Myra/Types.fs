[<AutoOpen>]
module Dap.Myra.Types

open System

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Graphics

open Myra
open Myra.Graphics2D.UI

open Dap.Prelude
open Dap.Gui
open Dap.Gui.App

type Color = Microsoft.Xna.Framework.Color
type Vector2 = Microsoft.Xna.Framework.Vector2
type Rectangle = Microsoft.Xna.Framework.Rectangle

type GamePad = Microsoft.Xna.Framework.Input.GamePad
type Keyboard = Microsoft.Xna.Framework.Input.Keyboard
type Keys = Microsoft.Xna.Framework.Input.Keys

type MyraWidget = Myra.Graphics2D.UI.Widget
type MyraPanel = Myra.Graphics2D.UI.Panel

type Proportion = Myra.Graphics2D.UI.Grid.Proportion
type ProportionType = Myra.Graphics2D.UI.Grid.ProportionType

type IMyraWindow =
    abstract Xna : Microsoft.Xna.Framework.Game with get
    abstract GraphicsManager : GraphicsDeviceManager with get
    abstract Graphics : GraphicsDevice with get
    abstract Desktop : Desktop with get
    abstract Width : int with get
    abstract Height : int with get
    abstract Quitting : bool with get

type IMyraPlatform =
    inherit IGuiPlatform
    abstract Param : MyraParam with get
    abstract Window : IMyraWindow with get

and MyraParam = {
    Name : string
    Title : string
    Width : int
    Height : int
    ClearColor : Color option
    ExitKey : Keys option
    Actions : (IMyraPlatform -> unit) list
} with
    static member Create (name : string, ?title : string, ?width : int, ?height : int, ?clearColor : Color, ?exitKey : Keys) : MyraParam =
        {
            Name = name
            Title = defaultArg title name
            Width = defaultArg width 1280
            Height = defaultArg height 720
            ClearColor = clearColor
            ExitKey = exitKey
            Actions = []
        }
