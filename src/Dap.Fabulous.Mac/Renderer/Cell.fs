[<AutoOpen>]
module Dap.Fabulous.Mac.Renderer.Cell

open System
open System.Reflection

open Foundation
open CoreGraphics
open AppKit

open Xamarin.Forms
open Xamarin.Forms.Platform.MacOS

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Fabulous.Controls

// Xamarin.Forms.Platform.MacOS.Cells/CellNSView.cs is internal class
// Use reflection here to access the AccessoryView of it
type CellView (tvc : NSView) =
    static let mutable fieldAccessoryView : FieldInfo option = None
    static let getFieldAccessoryView (tvc : NSView) =
        if fieldAccessoryView.IsNone then
            fieldAccessoryView <- Some <| (tvc.GetType ()) .GetField ("AccessoryView")
        fieldAccessoryView.Value
    member this.AccessoryView
        with get () : NSView =
            (getFieldAccessoryView tvc) .GetValue (tvc, null)
            :?> NSView
        and set (value : NSView) =
            (getFieldAccessoryView tvc) .SetValue (tvc, value :> obj)
    member this.GetAccessoryView<'view when 'view :> NSView> () =
        match this.AccessoryView with
        | :? 'view as view -> Some view
        | _ -> None