[<AutoOpen>]
module Dap.Gui.Builder.Helper

open Microsoft.FSharp.Quotations

open Dap.Context
open Dap.Context.Meta.Util
open Dap.Gui
module Base = Dap.Gui.Builder.Internal.Base

let label = label_props
let button = button_props
let text_field = text_field_props

type ComboPrefabBuilder (prefab : string, props : ComboProps) =
    inherit Base.ComboPropsBuilder ()
    override this.Zero () =
        props
        |> fun t -> this.Prefab (t, prefab)

type ComboPropsBuilder (layout : string) =
    inherit Base.ComboPropsBuilder ()
    override this.Zero () =
        base.Zero ()
        |> fun t -> this.Layout (t, layout)
        |> fun t -> this.Prefab (t, ComboLayoutKind.ParseToPrefab layout)
    [<CustomOperation("child")>]
    member __.Child (target : ComboProps, key, prop : ICustomProperty) =
        target.Children.AddAny key prop.Clone0 |> ignore
        target

let h_stack = new ComboPropsBuilder (LayoutConst.Combo_Horizontal_Stack)

let v_stack = new ComboPropsBuilder (LayoutConst.Combo_Vertical_Stack)

type ListPropsBuilder (layout : string) =
    inherit Base.ListPropsBuilder ()
    override this.Zero () =
        base.Zero ()
        |> fun t -> this.Layout (t, LayoutConst.List_Table)
        |> fun t -> this.Prefab (t, ListLayoutKind.ParseToPrefab layout)
    [<CustomOperation("item")>]
    member __.Item<'props when 'props :> IViewProps> (target : ListProps, expr : Expr<'props>) =
        let (_, meta) = unquotePropertyGetExpr expr
        target.ItemPrefab.SetValue meta.Prefab.Value
        target

let table = new ListPropsBuilder (LayoutConst.List_Table)
let f_table = new ListPropsBuilder (LayoutConst.List_Full_Table)
