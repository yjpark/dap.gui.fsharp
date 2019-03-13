[<RequireQualifiedAccess>]
module Dap.Fabulous.Builder.TableView

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

type Builder () =
    inherit View.Builder<TableView> ()
    //SILP: FABULOUS_BUILDER_BUILD(TableView)
    override __.Build (builder : AttributesBuilder) =                                      //__SILP__
        ViewElement.Create<TableView>                                                      //__SILP__
            (ViewBuilders.CreateFuncTableView, ViewBuilders.UpdateFuncTableView, builder)  //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TableView, TableIntent, Intent, intent)
    [<CustomOperation("intent")>]                                                  //__SILP__
    member __.Intent (attributes : Attributes<TableView>, intent : TableIntent) =  //__SILP__
        attributes.With (ViewAttributes.IntentAttribKey, intent)                   //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TableView, bool, HasUnevenRows, hasUnevenRows)
    [<CustomOperation("hasUnevenRows")>]                                                  //__SILP__
    member __.HasUnevenRows (attributes : Attributes<TableView>, hasUnevenRows : bool) =  //__SILP__
        attributes.With (ViewAttributes.HasUnevenRowsAttribKey, hasUnevenRows)            //__SILP__
    //SILP: FABULOUS_BUILDER_OPERATION(TableView, int, RowHeight, rowHeight)
    [<CustomOperation("rowHeight")>]                                             //__SILP__
    member __.RowHeight (attributes : Attributes<TableView>, rowHeight : int) =  //__SILP__
        attributes.With (ViewAttributes.RowHeightAttribKey, rowHeight)           //__SILP__
    [<CustomOperation("items")>]
    member __.Items (attributes : Attributes<TableView>, items : (string * ViewElement list) list) =
        attributes.With (ViewAttributes.TableRootAttribKey, (fun es ->
            es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es))) (items))
