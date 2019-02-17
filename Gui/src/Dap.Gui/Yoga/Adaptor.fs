[<AutoOpen>]
module Dap.Gui.Yoga.Adaptor

open Facebook.Yoga

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

[<Literal>]
let YogaAdaptorKind = "YogaAdaptor"

type IAdaptor =
    inherit IFeature
    abstract GetSize : obj -> float32 * float32
    abstract MeasureSize : obj * float32 * float32 -> float32 * float32
    abstract ApplyLayout : obj * YogaNode -> unit

[<AbstractClass>]
type BaseAdaptor<'widget> (logging : ILogging) =
    inherit EmptyContext (logging, YogaAdaptorKind)
    let mutable pointScale : float32 = 1.0f
    abstract GetSize : 'widget -> float32 * float32
    abstract MeasureSize : 'widget * float32 * float32 -> float32 * float32
    abstract ApplyLayout : 'widget * YogaNode -> unit
    member this.SetPointScale (scale : float32) =
        if scale > 0.0f then
            pointScale <- scale
        else
            logWarn this "SetNativePointScale" "Invalid_Point_Scale" scale
    member __.RoundPointValue (v : float32) : float =
        System.Math.Round ((float) v * (float) pointScale) / (float) pointScale
    interface IAdaptor with
        member this.GetSize (widget : obj) =
            match widget with
            | :? 'widget as widget ->
                this.GetSize widget
            | _ ->
                logWarn this "IAdaptor.GetSize" "Type_Mismatched"
                    (typeof<'widget>.FullName, widget.GetType().FullName)
                (64.0f, 64.0f)
        member this.MeasureSize (widget : obj, constrainWidth : float32,  constrainHeight : float32) =
            match widget with
            | :? 'widget as widget ->
                this.MeasureSize (widget, constrainWidth, constrainHeight)
            | _ ->
                logWarn this "IAdaptor.MeasureSize" "Type_Mismatched"
                    (typeof<'widget>.FullName, widget.GetType().FullName)
                (constrainWidth, constrainHeight)
        member this.ApplyLayout (widget : obj, node : YogaNode) =
            match widget with
            | :? 'widget as widget ->
                this.ApplyLayout (widget, node)
            | _ ->
                logWarn this "IAdaptor.ApplyLayout" "Type_Mismatched"
                    (typeof<'widget>.FullName, widget.GetType().FullName)

type InvalidAdaptor (logging : ILogging) =
    inherit BaseAdaptor<obj> (logging)
    override __.GetSize (widget : obj) =
        (64.0f, 64.0f)
    override __.MeasureSize (widget : obj, constrainWidth : float32,  constrainHeight : float32) =
        (constrainWidth, constrainHeight)
    override this.ApplyLayout (widget : obj, node : YogaNode) =
        logWarn this "InvalidAdaptor" "Yoga_Adaptor_Not_Exist" ()
        ()
    interface IFallback
