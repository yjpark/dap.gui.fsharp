[<AutoOpen>]
module Dap.Gui.Builder.Helper

open Dap.Context
open Dap.Gui
module Base = Dap.Gui.Builder.Internal.Base

let label = label_props
let button = button_props
let text_field = text_field_props

type GroupBuilder () =
    inherit Base.GroupPropsBuilder ()
    [<CustomOperation("child")>]
    member __.Child (target : GroupProps, key, prop : ICustomProperty) =
        target.Children.AddAny key prop.Clone0 |> ignore
        target

let group = new GroupBuilder ()

type StackBuilder (layout : string) =
    inherit GroupBuilder ()
    override this.Zero () =
        base.Zero ()
        |> fun t -> this.Prefab (t, "stack")
        |> fun t -> this.Layout (t, layout)

let h_stack = new StackBuilder (LayoutConst.Horizontal_Stack)

let v_stack = new StackBuilder (LayoutConst.Vertical_Stack)
