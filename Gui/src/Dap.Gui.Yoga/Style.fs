[<AutoOpen>]
module Dap.Gui.Yoga.Style

open System
open System.Runtime.InteropServices
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Facebook.Yoga
open Facebook.Yoga
open System.Data
open Facebook.Yoga

type IYogaUpdater =
    abstract Update : YogaNode -> unit

type IYogaStyle =
    inherit IStyle
    abstract Node : YogaNode option with get
    abstract ApplyWithoutCalc' : unit -> unit

let private adaptor : IAdaptor option =
    if RuntimeInformation.IsOSPlatform (OSPlatform.OSX) then
        Some <| Feature.create<IAdaptor> (getLogging ())
    else
        None

// Measure logic borrowed from Facebook.YogaKit YogaLayout.cs
let private sanitizeMeasurement (constrained : float32) (measured : float32) (mode : YogaMeasureMode) =
    match mode with
    | YogaMeasureMode.Exactly -> constrained
    | YogaMeasureMode.AtMost -> Math.Min (constrained, measured)
    | _ -> measured

let private measureView (adaptor : IAdaptor) (widget : obj) (node : YogaNode) (width : float32) (widthMode : YogaMeasureMode) (height : float32) (heightMode : YogaMeasureMode) : YogaSize =
    let constrainedWidth =
        match widthMode with
        | YogaMeasureMode.Undefined -> Single.MaxValue
        | _ -> width
    let constrainedHeight =
        match heightMode with
        | YogaMeasureMode.Undefined -> Single.MaxValue
        | _ -> height
    let (sizeThatFitsWidth, sizeThatFitsHeight) = adaptor.MeasureSize (widget, constrainedWidth, constrainedHeight)
    let finalWidth = sanitizeMeasurement constrainedWidth sizeThatFitsWidth widthMode
    let finalHeight = sanitizeMeasurement constrainedHeight sizeThatFitsHeight heightMode
    MeasureOutput.Make (finalWidth, finalHeight)

//type MeasureFunctionDelegate = delegate of (YogaNode * float32 * YogaMeasureMode * float32 * YogaMeasureMode) -> YogaSize

type IPrefab with
    member this.TryGetYogaNode () =
        if adaptor.IsSome then
            Some <| this.GetOrNewExtra<YogaNode> (fun _ -> new YogaNode ())
        else
            None

type NoYogaUpdater = NoYogaUpdater
with
    interface IYogaUpdater with
        member __.Update _node = ()

type YogaStyle<'prefab when 'prefab :> IPrefab> (kind : string, target : 'prefab, updater : IYogaUpdater) =
    inherit BaseStyle<'prefab>(kind, target)
    let node = target.TryGetYogaNode ()
    let mutable children : IYogaStyle list = []
    do (
        match node with
        | None -> ()
        | Some node ->
            node.Data <- target
            node.SetMeasureFunction <| new MeasureFunction (measureView adaptor.Value target.Widget0)
            updater.Update node
    )
    override __.OnChildAdded (child' : IPrefab) =
        match node with
        | None -> ()
        | Some node ->
            node.SetMeasureFunction (null)
            let child =
                child'.FilterStyles<IYogaStyle> ()
                |> function
                | [] ->
                    // In case there is no yoga style
                    let child = new YogaStyle<IPrefab> ("_IYogaStyle_", child', NoYogaUpdater) :> IYogaStyle
                    child'.SetStyles' <| child'.Styles @ [ child ]
                    child
                | _ as yogaStyles ->
                    List.head yogaStyles
            node.AddChild (child.Node.Value)
            children <- children @ [ child ]
    override __.OnChildRemoved (child' : IPrefab) =
        match node with
        | None -> ()
        | Some node ->
            child'.FilterStyles<IYogaStyle> ()
            |> function
            | [] ->
                ()
            | _ as yogaStyles ->
                let child = List.head yogaStyles
                node.RemoveChild (child.Node.Value)
                children <-
                    children
                    |> List.filter (fun c -> c <> child)
    override this.Apply () =
        match node with
        | None -> ()
        | Some node ->
            let (width, height) = adaptor.Value.GetSize (target.Widget0)
            node.Width <- YogaValue.Point width
            node.Height <- YogaValue.Point height
            node.CalculateLayout ()
            logWip target "Apply" (node.Data, node, width, height)
            this.ApplyWithoutCalc' ()
    member __.ApplyWithoutCalc' () =
        adaptor.Value.ApplyLayout (target.Widget0, node.Value)
        children
        |> List.iter (fun child ->
            child.ApplyWithoutCalc' ()
        )
    interface IYogaStyle with
        member __.Node = node
        member this.ApplyWithoutCalc' () = this.ApplyWithoutCalc' ()

type YogaStyle (kind : string, target : IPrefab, update : IYogaUpdater) =
    inherit YogaStyle<IPrefab>(kind, target, update)
