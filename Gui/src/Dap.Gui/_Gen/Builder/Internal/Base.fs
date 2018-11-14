[<AutoOpen>]
module Dap.Gui.Builder.Internal.Base

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Gui

(*
 * Generated: <ComboBuilder>
 *)
type ListPropsBuilder () =
    inherit ObjBuilder<ListProps> ()
    override __.Zero () = ListProps.Create ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : ListProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : ListProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("layout")>]
    member __.Layout (target : ListProps, (* IGroupProps *) layout : string) =
        target.Layout.SetValue layout
        target
    [<CustomOperation("item_prefab")>]
    member __.ItemPrefab (target : ListProps, (* ListProps *) itemPrefab : string) =
        target.ItemPrefab.SetValue itemPrefab
        target

let list_props = new ListPropsBuilder ()

(*
 * Generated: <ComboBuilder>
 *)
type ComboPropsBuilder () =
    inherit ObjBuilder<ComboProps> ()
    override __.Zero () = ComboProps.Create ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : ComboProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : ComboProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("layout")>]
    member __.Layout (target : ComboProps, (* IGroupProps *) layout : string) =
        target.Layout.SetValue layout
        target
    [<CustomOperation("children")>]
    member __.Children (target : ComboProps, (* ComboProps *) children : IComboProperty) =
        target.Children.SyncWith children
        target

let combo_props = new ComboPropsBuilder ()