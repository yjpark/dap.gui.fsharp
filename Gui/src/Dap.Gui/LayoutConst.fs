[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.LayoutConst

open Dap.Prelude

[<Literal>]
let List_Table = "table"

[<Literal>]
let List_Full_Table = "full_table"

[<Literal>]
let Combo_Horizontal_Stack = "horizontal_stack"

[<Literal>]
let Combo_Vertical_Stack = "vertical_stack"

[<Literal>]
let Combo_Panel = "panel"

type ComboLayoutKind =
    | Stack
    | Panel
with
    static member Parse (layout : string) : ComboLayoutKind =
        match layout with
        | Combo_Horizontal_Stack -> Stack
        | Combo_Vertical_Stack -> Stack
        | Combo_Panel -> Panel
        | _ -> Stack
    static member ParseToPrefab (layout : string) : string =
        (ComboLayoutKind.Parse layout) .ToPrefab ()
    member this.ToPrefab () : string =
        Union.getKind this

type ListLayoutKind =
    | Table
    | FullTable
    static member Parse (layout : string) : ListLayoutKind =
        match layout with
        | List_Table -> Table
        | List_Full_Table -> FullTable
        | _ -> Table
    static member ParseToPrefab (layout : string) : string =
        (ListLayoutKind.Parse layout) .ToPrefab ()
    member this.ToPrefab () : string =
        Union.getKind this