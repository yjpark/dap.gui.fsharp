[<AutoOpen>]
module Dap.Gui.Builder.Internal.Base

open Dap.Prelude
open Dap.Context
open Dap.Context.Builder
open Dap.Gui

(*
 * Generated: <ComboBuilder>
 *)
type GroupPropsBuilder () =
    inherit ObjBuilder<GroupProps> ()
    override __.Zero () = GroupProps.Default ()
    [<CustomOperation("prefab")>]
    member __.Prefab (target : GroupProps, (* IViewProps *) prefab : string) =
        target.Prefab.SetValue prefab
        target
    [<CustomOperation("styles")>]
    member __.Styles (target : GroupProps, (* IViewProps *) styles : string list) =
        styles
        |> List.iter (fun v ->
            let prop = target.Styles.Add ()
            prop.SetValue v
        )
        target
    [<CustomOperation("layout")>]
    member __.Layout (target : GroupProps, (* IGroupProps *) layout : string) =
        target.Layout.SetValue layout
        target
    [<CustomOperation("children")>]
    member __.Children (target : GroupProps, (* IGroupProps *) children : IComboProperty) =
        target.Children.SyncWith children
        target

let group_props = new GroupPropsBuilder ()