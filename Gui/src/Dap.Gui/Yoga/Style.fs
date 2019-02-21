[<AutoOpen>]
module Dap.Gui.Yoga.Style

open System
open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Facebook.Yoga
open Facebook.Yoga
open System.Data
open Facebook.Yoga

type IYogaStyle =
    inherit IStyle
    abstract Node : YogaNode with get
    abstract ApplyWithoutCalc' : IAdaptor -> unit

let mutable private adaptor' : IAdaptor option = None

let private getAdaptor () =
    match adaptor' with
    | Some adaptor -> adaptor
    | None ->
        let adaptor = Feature.create<IAdaptor> (getLogging ())
        adaptor' <- Some adaptor
        adaptor

// Measure logic borrowed from Facebook.YogaKit YogaLayout.cs
let private sanitizeMeasurement (constrained : float32) (measured : float32) (mode : YogaMeasureMode) =
    match mode with
    | YogaMeasureMode.Exactly -> constrained
    | YogaMeasureMode.AtMost -> Math.Min (constrained, measured)
    | _ -> measured

let private measureView (widget : obj) (node : YogaNode) (width : float32) (widthMode : YogaMeasureMode) (height : float32) (heightMode : YogaMeasureMode) : YogaSize =
    let adaptor = getAdaptor ()
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

type YogaStyle<'prefab when 'prefab :> IPrefab> (kind : string, target : 'prefab, template : YogaNode, setup : (YogaNode -> unit) option) =
    inherit BaseStyle<'prefab>(kind, target)
    let node = new YogaNode (template)
    let mutable children : IYogaStyle list = []
    do (
        node.Data <- target
        node.SetMeasureFunction <| new MeasureFunction (measureView target.Widget0)
        setup
        |> Option.iter (fun setup -> setup node)
    )
    override __.OnChildAdded (child' : IPrefab) =
        node.SetMeasureFunction (null)
        child'.TryFindStyle<IYogaStyle> ()
        |> Option.iter (fun child ->
            logWarn target "TEST" "AAAAAAAAAAAAAAAAAAAAAAA" (child.Node.Data, child.Node)
            node.AddChild (child.Node)
            children <- children @ [ child ]
        )
    override __.OnChildRemoved (child' : IPrefab) =
        child'.TryFindStyle<IYogaStyle> ()
        |> Option.iter (fun child ->
            node.RemoveChild (child.Node)
            children <-
                children
                |> List.filter (fun c -> c <> child)
        )
    override this.Apply () =
        let adaptor = getAdaptor ()
        let (width, height) = adaptor.GetSize (target.Widget0)
        node.Width <- YogaValue.Point width
        node.Height <- YogaValue.Point height
        node.CalculateLayout ()
        logWip target "Apply" (node.Data, node, width, height)
        this.ApplyWithoutCalc' adaptor
    member __.ApplyWithoutCalc' (adaptor : IAdaptor) =
        adaptor.ApplyLayout (target.Widget0, node)
        children
        |> List.iter (fun child ->
            child.ApplyWithoutCalc' adaptor
        )
    interface IYogaStyle with
        member __.Node = node
        member this.ApplyWithoutCalc' adaptor = this.ApplyWithoutCalc' adaptor

type YogaStyle (kind : string, target : IPrefab, template : YogaNode, setup : (YogaNode -> unit) option) =
    inherit YogaStyle<IPrefab>(kind, target, template, setup)
