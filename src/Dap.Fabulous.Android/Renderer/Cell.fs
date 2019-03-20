[<AutoOpen>]
module Dap.Fabulous.Android.Renderer.Cell

open Android.Content
open Android.Views

open Xamarin.Forms
open Xamarin.Forms.Platform.Android

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Fabulous
open Dap.Fabulous.Controls

type AContext = Android.Content.Context
type AView = Android.Views.View
type ALayoutDirection = Android.Views.LayoutDirection

type PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs

[<AbstractClass>]
type CellView<'cell when 'cell :> Cell> (cell : 'cell, renderer : CellRenderer, context : AContext) =
    inherit BaseCellView (context, cell)
    static let mutable logger : ILogger option = None
    abstract DoUpdate : unit -> unit
    default this.DoUpdate () =
        this.UpdateHeight ()
        this.UpdateFlowDirection ()
    abstract OnCellPropertyChanged : string -> unit
    default this.OnCellPropertyChanged prop =
        if prop = Cell.IsEnabledProperty.PropertyName then
            this.UpdateIsEnabled ()
        elif prop = "RenderHeight" then
            this.UpdateHeight ()
        elif prop = VisualElement.FlowDirectionProperty.PropertyName then
            this.UpdateFlowDirection ()
    member this.UpdateIsEnabled () =
        this.SetIsEnabled cell.IsEnabled
    member this.UpdateHeight () =
        this.SetRenderHeight cell.RenderHeight
    member this.UpdateFlowDirection () =
        // Xamarin.Forms.Platform.Android/FlowDirectionExtensions.cs (internal class)
        if ((int) Android.OS.Build.VERSION.SdkInt) >= 17 then
            let controller = renderer.ParentView :> IVisualElementController
            if controller.EffectiveFlowDirection.IsRightToLeft () then
                this.LayoutDirection <- ALayoutDirection.Rtl
            elif controller.EffectiveFlowDirection.IsLeftToRight () then
                this.LayoutDirection <- ALayoutDirection.Ltr
    member this.Logger =
        if logger.IsNone then
            logger <-
                Bootstrap.getKind <| this.GetType ()
                |> (fun x -> x.Replace ("Dap.Fabulous.Android.Renderer.", ""))
                |> (getLogging ()) .GetLogger
                |> Some
        logger.Value

type CellRenderer<'cell, 'view when 'cell :> Cell and 'view :> CellView<'cell>> () =
    inherit CellRenderer ()
    let mutable cellView : 'view option = None
    abstract CreateView : 'cell -> AContext -> 'view
    default this.CreateView cell context =
        System.Activator.CreateInstance (typeof<'view>, [| cell :> obj ; this :> obj ; context :> obj |])
        :?> 'view
    override this.GetCellCore (cell' : Cell, convertView : AView, parent : ViewGroup, context : AContext) =
        let cell = cell' :?> 'cell
        let view =
            if cellView.IsNone then
                (* Reuse convertView after figured out how to cleanup old handlers of view
                match convertView with
                | :? 'view as x -> x
                | _ ->
                *)
                cellView <- Some <| this.CreateView cell context
            cellView.Value
        view.DoUpdate ()
        view :> AView
    override this.OnCellPropertyChanged (sender : obj, args : PropertyChangedEventArgs) =
        base.OnCellPropertyChanged (sender, args)
        cellView |> Option.iter (fun x -> x.OnCellPropertyChanged args.PropertyName)

type TextCellView<'cell when 'cell :> TextCell> (cell : 'cell, renderer : CellRenderer, context : AContext) =
    inherit CellView<'cell> (cell, renderer, context)
    member this.UpdateText () =
        this.MainText <- cell.Text
    member this.UpdateTextColor () =
        this.SetMainTextColor cell.TextColor
    member this.UpdateDetail () =
        this.DetailText <- cell.Detail
    member this.UpdateDetailColor () =
        this.SetDetailTextColor cell.DetailColor
    override this.DoUpdate () =
        base.DoUpdate ()
        this.UpdateText ()
        this.UpdateTextColor ()
        this.UpdateDetail ()
        this.UpdateDetailColor ()
    override this.OnCellPropertyChanged prop =
        base.OnCellPropertyChanged prop
        if prop = TextCell.TextProperty.PropertyName then
            this.UpdateText ()
        elif prop = TextCell.TextColorProperty.PropertyName then
            this.UpdateTextColor ()
        elif prop = TextCell.DetailProperty.PropertyName then
            this.UpdateDetail ()
        elif prop = TextCell.DetailColorProperty.PropertyName then
            this.UpdateDetailColor ()

