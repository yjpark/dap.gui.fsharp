[<AutoOpen>]
[<RequireQualifiedAccess>]
module Dap.Gui.Palette.MaterialParam

open Dap.Prelude
open Dap.Context

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type GrayPaletteParam = {
    MiddleShadeNormal : (* GrayPaletteParam *) int
    Normal50 : (* GrayPaletteParam *) ColorHex
    Normal100 : (* GrayPaletteParam *) ColorHex
    Normal200 : (* GrayPaletteParam *) ColorHex
    Normal300 : (* GrayPaletteParam *) ColorHex
    Normal400 : (* GrayPaletteParam *) ColorHex
    Normal500 : (* GrayPaletteParam *) ColorHex
    Normal600 : (* GrayPaletteParam *) ColorHex
    Normal700 : (* GrayPaletteParam *) ColorHex
    Normal800 : (* GrayPaletteParam *) ColorHex
    Normal900 : (* GrayPaletteParam *) ColorHex
} with
    static member Create
        (
            ?middleShadeNormal : (* GrayPaletteParam *) int,
            ?normal50 : (* GrayPaletteParam *) ColorHex,
            ?normal100 : (* GrayPaletteParam *) ColorHex,
            ?normal200 : (* GrayPaletteParam *) ColorHex,
            ?normal300 : (* GrayPaletteParam *) ColorHex,
            ?normal400 : (* GrayPaletteParam *) ColorHex,
            ?normal500 : (* GrayPaletteParam *) ColorHex,
            ?normal600 : (* GrayPaletteParam *) ColorHex,
            ?normal700 : (* GrayPaletteParam *) ColorHex,
            ?normal800 : (* GrayPaletteParam *) ColorHex,
            ?normal900 : (* GrayPaletteParam *) ColorHex
        ) : GrayPaletteParam =
        {
            MiddleShadeNormal = (* GrayPaletteParam *) middleShadeNormal
                |> Option.defaultWith (fun () -> 350)
            Normal50 = (* GrayPaletteParam *) normal50
                |> Option.defaultWith (fun () -> "#000000")
            Normal100 = (* GrayPaletteParam *) normal100
                |> Option.defaultWith (fun () -> "#000000")
            Normal200 = (* GrayPaletteParam *) normal200
                |> Option.defaultWith (fun () -> "#000000")
            Normal300 = (* GrayPaletteParam *) normal300
                |> Option.defaultWith (fun () -> "#000000")
            Normal400 = (* GrayPaletteParam *) normal400
                |> Option.defaultWith (fun () -> "#000000")
            Normal500 = (* GrayPaletteParam *) normal500
                |> Option.defaultWith (fun () -> "#000000")
            Normal600 = (* GrayPaletteParam *) normal600
                |> Option.defaultWith (fun () -> "#000000")
            Normal700 = (* GrayPaletteParam *) normal700
                |> Option.defaultWith (fun () -> "#000000")
            Normal800 = (* GrayPaletteParam *) normal800
                |> Option.defaultWith (fun () -> "#000000")
            Normal900 = (* GrayPaletteParam *) normal900
                |> Option.defaultWith (fun () -> "#000000")
        }
    static member SetMiddleShadeNormal ((* GrayPaletteParam *) middleShadeNormal : int) (this : GrayPaletteParam) =
        {this with MiddleShadeNormal = middleShadeNormal}
    static member SetNormal50 ((* GrayPaletteParam *) normal50 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal50 = normal50}
    static member SetNormal100 ((* GrayPaletteParam *) normal100 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal100 = normal100}
    static member SetNormal200 ((* GrayPaletteParam *) normal200 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal200 = normal200}
    static member SetNormal300 ((* GrayPaletteParam *) normal300 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal300 = normal300}
    static member SetNormal400 ((* GrayPaletteParam *) normal400 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal400 = normal400}
    static member SetNormal500 ((* GrayPaletteParam *) normal500 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal500 = normal500}
    static member SetNormal600 ((* GrayPaletteParam *) normal600 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal600 = normal600}
    static member SetNormal700 ((* GrayPaletteParam *) normal700 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal700 = normal700}
    static member SetNormal800 ((* GrayPaletteParam *) normal800 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal800 = normal800}
    static member SetNormal900 ((* GrayPaletteParam *) normal900 : ColorHex) (this : GrayPaletteParam) =
        {this with Normal900 = normal900}
    static member JsonEncoder : JsonEncoder<GrayPaletteParam> =
        fun (this : GrayPaletteParam) ->
            E.object [
                "middle_shade_normal", E.int (* GrayPaletteParam *) this.MiddleShadeNormal
                "normal_50", E.string (* GrayPaletteParam *) this.Normal50
                "normal_100", E.string (* GrayPaletteParam *) this.Normal100
                "normal_200", E.string (* GrayPaletteParam *) this.Normal200
                "normal_300", E.string (* GrayPaletteParam *) this.Normal300
                "normal_400", E.string (* GrayPaletteParam *) this.Normal400
                "normal_500", E.string (* GrayPaletteParam *) this.Normal500
                "normal_600", E.string (* GrayPaletteParam *) this.Normal600
                "normal_700", E.string (* GrayPaletteParam *) this.Normal700
                "normal_800", E.string (* GrayPaletteParam *) this.Normal800
                "normal_900", E.string (* GrayPaletteParam *) this.Normal900
            ]
    static member JsonDecoder : JsonDecoder<GrayPaletteParam> =
        D.object (fun get ->
            {
                MiddleShadeNormal = get.Optional.Field (* GrayPaletteParam *) "middle_shade_normal" D.int
                    |> Option.defaultValue 350
                Normal50 = get.Optional.Field (* GrayPaletteParam *) "normal_50" D.string
                    |> Option.defaultValue "#000000"
                Normal100 = get.Optional.Field (* GrayPaletteParam *) "normal_100" D.string
                    |> Option.defaultValue "#000000"
                Normal200 = get.Optional.Field (* GrayPaletteParam *) "normal_200" D.string
                    |> Option.defaultValue "#000000"
                Normal300 = get.Optional.Field (* GrayPaletteParam *) "normal_300" D.string
                    |> Option.defaultValue "#000000"
                Normal400 = get.Optional.Field (* GrayPaletteParam *) "normal_400" D.string
                    |> Option.defaultValue "#000000"
                Normal500 = get.Optional.Field (* GrayPaletteParam *) "normal_500" D.string
                    |> Option.defaultValue "#000000"
                Normal600 = get.Optional.Field (* GrayPaletteParam *) "normal_600" D.string
                    |> Option.defaultValue "#000000"
                Normal700 = get.Optional.Field (* GrayPaletteParam *) "normal_700" D.string
                    |> Option.defaultValue "#000000"
                Normal800 = get.Optional.Field (* GrayPaletteParam *) "normal_800" D.string
                    |> Option.defaultValue "#000000"
                Normal900 = get.Optional.Field (* GrayPaletteParam *) "normal_900" D.string
                    |> Option.defaultValue "#000000"
            }
        )
    static member JsonSpec =
        FieldSpec.Create<GrayPaletteParam> (GrayPaletteParam.JsonEncoder, GrayPaletteParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = GrayPaletteParam.JsonEncoder this
    interface IObj
    member this.WithMiddleShadeNormal ((* GrayPaletteParam *) middleShadeNormal : int) =
        this |> GrayPaletteParam.SetMiddleShadeNormal middleShadeNormal
    member this.WithNormal50 ((* GrayPaletteParam *) normal50 : ColorHex) =
        this |> GrayPaletteParam.SetNormal50 normal50
    member this.WithNormal100 ((* GrayPaletteParam *) normal100 : ColorHex) =
        this |> GrayPaletteParam.SetNormal100 normal100
    member this.WithNormal200 ((* GrayPaletteParam *) normal200 : ColorHex) =
        this |> GrayPaletteParam.SetNormal200 normal200
    member this.WithNormal300 ((* GrayPaletteParam *) normal300 : ColorHex) =
        this |> GrayPaletteParam.SetNormal300 normal300
    member this.WithNormal400 ((* GrayPaletteParam *) normal400 : ColorHex) =
        this |> GrayPaletteParam.SetNormal400 normal400
    member this.WithNormal500 ((* GrayPaletteParam *) normal500 : ColorHex) =
        this |> GrayPaletteParam.SetNormal500 normal500
    member this.WithNormal600 ((* GrayPaletteParam *) normal600 : ColorHex) =
        this |> GrayPaletteParam.SetNormal600 normal600
    member this.WithNormal700 ((* GrayPaletteParam *) normal700 : ColorHex) =
        this |> GrayPaletteParam.SetNormal700 normal700
    member this.WithNormal800 ((* GrayPaletteParam *) normal800 : ColorHex) =
        this |> GrayPaletteParam.SetNormal800 normal800
    member this.WithNormal900 ((* GrayPaletteParam *) normal900 : ColorHex) =
        this |> GrayPaletteParam.SetNormal900 normal900

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type PaletteParam = {
    MiddleShadeNormal : (* GrayPaletteParam *) int
    Normal50 : (* GrayPaletteParam *) ColorHex
    Normal100 : (* GrayPaletteParam *) ColorHex
    Normal200 : (* GrayPaletteParam *) ColorHex
    Normal300 : (* GrayPaletteParam *) ColorHex
    Normal400 : (* GrayPaletteParam *) ColorHex
    Normal500 : (* GrayPaletteParam *) ColorHex
    Normal600 : (* GrayPaletteParam *) ColorHex
    Normal700 : (* GrayPaletteParam *) ColorHex
    Normal800 : (* GrayPaletteParam *) ColorHex
    Normal900 : (* GrayPaletteParam *) ColorHex
    MiddleShadeAccent : (* PaletteParam *) int
    Accent100 : (* PaletteParam *) ColorHex
    Accent200 : (* PaletteParam *) ColorHex
    Accent400 : (* PaletteParam *) ColorHex
    Accent700 : (* PaletteParam *) ColorHex
} with
    static member Create
        (
            ?middleShadeNormal : (* GrayPaletteParam *) int,
            ?normal50 : (* GrayPaletteParam *) ColorHex,
            ?normal100 : (* GrayPaletteParam *) ColorHex,
            ?normal200 : (* GrayPaletteParam *) ColorHex,
            ?normal300 : (* GrayPaletteParam *) ColorHex,
            ?normal400 : (* GrayPaletteParam *) ColorHex,
            ?normal500 : (* GrayPaletteParam *) ColorHex,
            ?normal600 : (* GrayPaletteParam *) ColorHex,
            ?normal700 : (* GrayPaletteParam *) ColorHex,
            ?normal800 : (* GrayPaletteParam *) ColorHex,
            ?normal900 : (* GrayPaletteParam *) ColorHex,
            ?middleShadeAccent : (* PaletteParam *) int,
            ?accent100 : (* PaletteParam *) ColorHex,
            ?accent200 : (* PaletteParam *) ColorHex,
            ?accent400 : (* PaletteParam *) ColorHex,
            ?accent700 : (* PaletteParam *) ColorHex
        ) : PaletteParam =
        {
            MiddleShadeNormal = (* GrayPaletteParam *) middleShadeNormal
                |> Option.defaultWith (fun () -> 350)
            Normal50 = (* GrayPaletteParam *) normal50
                |> Option.defaultWith (fun () -> "#000000")
            Normal100 = (* GrayPaletteParam *) normal100
                |> Option.defaultWith (fun () -> "#000000")
            Normal200 = (* GrayPaletteParam *) normal200
                |> Option.defaultWith (fun () -> "#000000")
            Normal300 = (* GrayPaletteParam *) normal300
                |> Option.defaultWith (fun () -> "#000000")
            Normal400 = (* GrayPaletteParam *) normal400
                |> Option.defaultWith (fun () -> "#000000")
            Normal500 = (* GrayPaletteParam *) normal500
                |> Option.defaultWith (fun () -> "#000000")
            Normal600 = (* GrayPaletteParam *) normal600
                |> Option.defaultWith (fun () -> "#000000")
            Normal700 = (* GrayPaletteParam *) normal700
                |> Option.defaultWith (fun () -> "#000000")
            Normal800 = (* GrayPaletteParam *) normal800
                |> Option.defaultWith (fun () -> "#000000")
            Normal900 = (* GrayPaletteParam *) normal900
                |> Option.defaultWith (fun () -> "#000000")
            MiddleShadeAccent = (* PaletteParam *) middleShadeAccent
                |> Option.defaultWith (fun () -> 150)
            Accent100 = (* PaletteParam *) accent100
                |> Option.defaultWith (fun () -> "#000000")
            Accent200 = (* PaletteParam *) accent200
                |> Option.defaultWith (fun () -> "#000000")
            Accent400 = (* PaletteParam *) accent400
                |> Option.defaultWith (fun () -> "#000000")
            Accent700 = (* PaletteParam *) accent700
                |> Option.defaultWith (fun () -> "#000000")
        }
    static member SetMiddleShadeNormal ((* GrayPaletteParam *) middleShadeNormal : int) (this : PaletteParam) =
        {this with MiddleShadeNormal = middleShadeNormal}
    static member SetNormal50 ((* GrayPaletteParam *) normal50 : ColorHex) (this : PaletteParam) =
        {this with Normal50 = normal50}
    static member SetNormal100 ((* GrayPaletteParam *) normal100 : ColorHex) (this : PaletteParam) =
        {this with Normal100 = normal100}
    static member SetNormal200 ((* GrayPaletteParam *) normal200 : ColorHex) (this : PaletteParam) =
        {this with Normal200 = normal200}
    static member SetNormal300 ((* GrayPaletteParam *) normal300 : ColorHex) (this : PaletteParam) =
        {this with Normal300 = normal300}
    static member SetNormal400 ((* GrayPaletteParam *) normal400 : ColorHex) (this : PaletteParam) =
        {this with Normal400 = normal400}
    static member SetNormal500 ((* GrayPaletteParam *) normal500 : ColorHex) (this : PaletteParam) =
        {this with Normal500 = normal500}
    static member SetNormal600 ((* GrayPaletteParam *) normal600 : ColorHex) (this : PaletteParam) =
        {this with Normal600 = normal600}
    static member SetNormal700 ((* GrayPaletteParam *) normal700 : ColorHex) (this : PaletteParam) =
        {this with Normal700 = normal700}
    static member SetNormal800 ((* GrayPaletteParam *) normal800 : ColorHex) (this : PaletteParam) =
        {this with Normal800 = normal800}
    static member SetNormal900 ((* GrayPaletteParam *) normal900 : ColorHex) (this : PaletteParam) =
        {this with Normal900 = normal900}
    static member SetMiddleShadeAccent ((* PaletteParam *) middleShadeAccent : int) (this : PaletteParam) =
        {this with MiddleShadeAccent = middleShadeAccent}
    static member SetAccent100 ((* PaletteParam *) accent100 : ColorHex) (this : PaletteParam) =
        {this with Accent100 = accent100}
    static member SetAccent200 ((* PaletteParam *) accent200 : ColorHex) (this : PaletteParam) =
        {this with Accent200 = accent200}
    static member SetAccent400 ((* PaletteParam *) accent400 : ColorHex) (this : PaletteParam) =
        {this with Accent400 = accent400}
    static member SetAccent700 ((* PaletteParam *) accent700 : ColorHex) (this : PaletteParam) =
        {this with Accent700 = accent700}
    static member JsonEncoder : JsonEncoder<PaletteParam> =
        fun (this : PaletteParam) ->
            E.object [
                "middle_shade_normal", E.int (* GrayPaletteParam *) this.MiddleShadeNormal
                "normal_50", E.string (* GrayPaletteParam *) this.Normal50
                "normal_100", E.string (* GrayPaletteParam *) this.Normal100
                "normal_200", E.string (* GrayPaletteParam *) this.Normal200
                "normal_300", E.string (* GrayPaletteParam *) this.Normal300
                "normal_400", E.string (* GrayPaletteParam *) this.Normal400
                "normal_500", E.string (* GrayPaletteParam *) this.Normal500
                "normal_600", E.string (* GrayPaletteParam *) this.Normal600
                "normal_700", E.string (* GrayPaletteParam *) this.Normal700
                "normal_800", E.string (* GrayPaletteParam *) this.Normal800
                "normal_900", E.string (* GrayPaletteParam *) this.Normal900
                "middle_shade_accent", E.int (* PaletteParam *) this.MiddleShadeAccent
                "accent_100", E.string (* PaletteParam *) this.Accent100
                "accent_200", E.string (* PaletteParam *) this.Accent200
                "accent_400", E.string (* PaletteParam *) this.Accent400
                "accent_700", E.string (* PaletteParam *) this.Accent700
            ]
    static member JsonDecoder : JsonDecoder<PaletteParam> =
        D.object (fun get ->
            {
                MiddleShadeNormal = get.Optional.Field (* GrayPaletteParam *) "middle_shade_normal" D.int
                    |> Option.defaultValue 350
                Normal50 = get.Optional.Field (* GrayPaletteParam *) "normal_50" D.string
                    |> Option.defaultValue "#000000"
                Normal100 = get.Optional.Field (* GrayPaletteParam *) "normal_100" D.string
                    |> Option.defaultValue "#000000"
                Normal200 = get.Optional.Field (* GrayPaletteParam *) "normal_200" D.string
                    |> Option.defaultValue "#000000"
                Normal300 = get.Optional.Field (* GrayPaletteParam *) "normal_300" D.string
                    |> Option.defaultValue "#000000"
                Normal400 = get.Optional.Field (* GrayPaletteParam *) "normal_400" D.string
                    |> Option.defaultValue "#000000"
                Normal500 = get.Optional.Field (* GrayPaletteParam *) "normal_500" D.string
                    |> Option.defaultValue "#000000"
                Normal600 = get.Optional.Field (* GrayPaletteParam *) "normal_600" D.string
                    |> Option.defaultValue "#000000"
                Normal700 = get.Optional.Field (* GrayPaletteParam *) "normal_700" D.string
                    |> Option.defaultValue "#000000"
                Normal800 = get.Optional.Field (* GrayPaletteParam *) "normal_800" D.string
                    |> Option.defaultValue "#000000"
                Normal900 = get.Optional.Field (* GrayPaletteParam *) "normal_900" D.string
                    |> Option.defaultValue "#000000"
                MiddleShadeAccent = get.Optional.Field (* PaletteParam *) "middle_shade_accent" D.int
                    |> Option.defaultValue 150
                Accent100 = get.Optional.Field (* PaletteParam *) "accent_100" D.string
                    |> Option.defaultValue "#000000"
                Accent200 = get.Optional.Field (* PaletteParam *) "accent_200" D.string
                    |> Option.defaultValue "#000000"
                Accent400 = get.Optional.Field (* PaletteParam *) "accent_400" D.string
                    |> Option.defaultValue "#000000"
                Accent700 = get.Optional.Field (* PaletteParam *) "accent_700" D.string
                    |> Option.defaultValue "#000000"
            }
        )
    static member JsonSpec =
        FieldSpec.Create<PaletteParam> (PaletteParam.JsonEncoder, PaletteParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = PaletteParam.JsonEncoder this
    interface IObj
    member this.WithMiddleShadeNormal ((* GrayPaletteParam *) middleShadeNormal : int) =
        this |> PaletteParam.SetMiddleShadeNormal middleShadeNormal
    member this.WithNormal50 ((* GrayPaletteParam *) normal50 : ColorHex) =
        this |> PaletteParam.SetNormal50 normal50
    member this.WithNormal100 ((* GrayPaletteParam *) normal100 : ColorHex) =
        this |> PaletteParam.SetNormal100 normal100
    member this.WithNormal200 ((* GrayPaletteParam *) normal200 : ColorHex) =
        this |> PaletteParam.SetNormal200 normal200
    member this.WithNormal300 ((* GrayPaletteParam *) normal300 : ColorHex) =
        this |> PaletteParam.SetNormal300 normal300
    member this.WithNormal400 ((* GrayPaletteParam *) normal400 : ColorHex) =
        this |> PaletteParam.SetNormal400 normal400
    member this.WithNormal500 ((* GrayPaletteParam *) normal500 : ColorHex) =
        this |> PaletteParam.SetNormal500 normal500
    member this.WithNormal600 ((* GrayPaletteParam *) normal600 : ColorHex) =
        this |> PaletteParam.SetNormal600 normal600
    member this.WithNormal700 ((* GrayPaletteParam *) normal700 : ColorHex) =
        this |> PaletteParam.SetNormal700 normal700
    member this.WithNormal800 ((* GrayPaletteParam *) normal800 : ColorHex) =
        this |> PaletteParam.SetNormal800 normal800
    member this.WithNormal900 ((* GrayPaletteParam *) normal900 : ColorHex) =
        this |> PaletteParam.SetNormal900 normal900
    member this.WithMiddleShadeAccent ((* PaletteParam *) middleShadeAccent : int) =
        this |> PaletteParam.SetMiddleShadeAccent middleShadeAccent
    member this.WithAccent100 ((* PaletteParam *) accent100 : ColorHex) =
        this |> PaletteParam.SetAccent100 accent100
    member this.WithAccent200 ((* PaletteParam *) accent200 : ColorHex) =
        this |> PaletteParam.SetAccent200 accent200
    member this.WithAccent400 ((* PaletteParam *) accent400 : ColorHex) =
        this |> PaletteParam.SetAccent400 accent400
    member this.WithAccent700 ((* PaletteParam *) accent700 : ColorHex) =
        this |> PaletteParam.SetAccent700 accent700

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type PalettesParam = {
    Black : (* PalettesParam *) ColorHex
    White : (* PalettesParam *) ColorHex
    Red : (* PalettesParam *) PaletteParam
    Pink : (* PalettesParam *) PaletteParam
    Purple : (* PalettesParam *) PaletteParam
    DeepPurple : (* PalettesParam *) PaletteParam
    Indigo : (* PalettesParam *) PaletteParam
    Blue : (* PalettesParam *) PaletteParam
    LightBlue : (* PalettesParam *) PaletteParam
    Cyan : (* PalettesParam *) PaletteParam
    Teal : (* PalettesParam *) PaletteParam
    Green : (* PalettesParam *) PaletteParam
    LightGreen : (* PalettesParam *) PaletteParam
    Lime : (* PalettesParam *) PaletteParam
    Yellow : (* PalettesParam *) PaletteParam
    Amber : (* PalettesParam *) PaletteParam
    Orange : (* PalettesParam *) PaletteParam
    DeepOrange : (* PalettesParam *) PaletteParam
    Brown : (* PalettesParam *) GrayPaletteParam
    Gray : (* PalettesParam *) GrayPaletteParam
    BlueGray : (* PalettesParam *) GrayPaletteParam
} with
    static member Create
        (
            ?black : (* PalettesParam *) ColorHex,
            ?white : (* PalettesParam *) ColorHex,
            ?red : (* PalettesParam *) PaletteParam,
            ?pink : (* PalettesParam *) PaletteParam,
            ?purple : (* PalettesParam *) PaletteParam,
            ?deepPurple : (* PalettesParam *) PaletteParam,
            ?indigo : (* PalettesParam *) PaletteParam,
            ?blue : (* PalettesParam *) PaletteParam,
            ?lightBlue : (* PalettesParam *) PaletteParam,
            ?cyan : (* PalettesParam *) PaletteParam,
            ?teal : (* PalettesParam *) PaletteParam,
            ?green : (* PalettesParam *) PaletteParam,
            ?lightGreen : (* PalettesParam *) PaletteParam,
            ?lime : (* PalettesParam *) PaletteParam,
            ?yellow : (* PalettesParam *) PaletteParam,
            ?amber : (* PalettesParam *) PaletteParam,
            ?orange : (* PalettesParam *) PaletteParam,
            ?deepOrange : (* PalettesParam *) PaletteParam,
            ?brown : (* PalettesParam *) GrayPaletteParam,
            ?gray : (* PalettesParam *) GrayPaletteParam,
            ?blueGray : (* PalettesParam *) GrayPaletteParam
        ) : PalettesParam =
        {
            Black = (* PalettesParam *) black
                |> Option.defaultWith (fun () -> "#000000")
            White = (* PalettesParam *) white
                |> Option.defaultWith (fun () -> "#FFFFFF")
            Red = (* PalettesParam *) red
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Pink = (* PalettesParam *) pink
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Purple = (* PalettesParam *) purple
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            DeepPurple = (* PalettesParam *) deepPurple
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Indigo = (* PalettesParam *) indigo
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Blue = (* PalettesParam *) blue
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            LightBlue = (* PalettesParam *) lightBlue
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Cyan = (* PalettesParam *) cyan
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Teal = (* PalettesParam *) teal
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Green = (* PalettesParam *) green
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            LightGreen = (* PalettesParam *) lightGreen
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Lime = (* PalettesParam *) lime
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Yellow = (* PalettesParam *) yellow
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Amber = (* PalettesParam *) amber
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Orange = (* PalettesParam *) orange
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            DeepOrange = (* PalettesParam *) deepOrange
                |> Option.defaultWith (fun () -> (PaletteParam.Create ()))
            Brown = (* PalettesParam *) brown
                |> Option.defaultWith (fun () -> (GrayPaletteParam.Create ()))
            Gray = (* PalettesParam *) gray
                |> Option.defaultWith (fun () -> (GrayPaletteParam.Create ()))
            BlueGray = (* PalettesParam *) blueGray
                |> Option.defaultWith (fun () -> (GrayPaletteParam.Create ()))
        }
    static member SetBlack ((* PalettesParam *) black : ColorHex) (this : PalettesParam) =
        {this with Black = black}
    static member SetWhite ((* PalettesParam *) white : ColorHex) (this : PalettesParam) =
        {this with White = white}
    static member SetRed ((* PalettesParam *) red : PaletteParam) (this : PalettesParam) =
        {this with Red = red}
    static member SetPink ((* PalettesParam *) pink : PaletteParam) (this : PalettesParam) =
        {this with Pink = pink}
    static member SetPurple ((* PalettesParam *) purple : PaletteParam) (this : PalettesParam) =
        {this with Purple = purple}
    static member SetDeepPurple ((* PalettesParam *) deepPurple : PaletteParam) (this : PalettesParam) =
        {this with DeepPurple = deepPurple}
    static member SetIndigo ((* PalettesParam *) indigo : PaletteParam) (this : PalettesParam) =
        {this with Indigo = indigo}
    static member SetBlue ((* PalettesParam *) blue : PaletteParam) (this : PalettesParam) =
        {this with Blue = blue}
    static member SetLightBlue ((* PalettesParam *) lightBlue : PaletteParam) (this : PalettesParam) =
        {this with LightBlue = lightBlue}
    static member SetCyan ((* PalettesParam *) cyan : PaletteParam) (this : PalettesParam) =
        {this with Cyan = cyan}
    static member SetTeal ((* PalettesParam *) teal : PaletteParam) (this : PalettesParam) =
        {this with Teal = teal}
    static member SetGreen ((* PalettesParam *) green : PaletteParam) (this : PalettesParam) =
        {this with Green = green}
    static member SetLightGreen ((* PalettesParam *) lightGreen : PaletteParam) (this : PalettesParam) =
        {this with LightGreen = lightGreen}
    static member SetLime ((* PalettesParam *) lime : PaletteParam) (this : PalettesParam) =
        {this with Lime = lime}
    static member SetYellow ((* PalettesParam *) yellow : PaletteParam) (this : PalettesParam) =
        {this with Yellow = yellow}
    static member SetAmber ((* PalettesParam *) amber : PaletteParam) (this : PalettesParam) =
        {this with Amber = amber}
    static member SetOrange ((* PalettesParam *) orange : PaletteParam) (this : PalettesParam) =
        {this with Orange = orange}
    static member SetDeepOrange ((* PalettesParam *) deepOrange : PaletteParam) (this : PalettesParam) =
        {this with DeepOrange = deepOrange}
    static member SetBrown ((* PalettesParam *) brown : GrayPaletteParam) (this : PalettesParam) =
        {this with Brown = brown}
    static member SetGray ((* PalettesParam *) gray : GrayPaletteParam) (this : PalettesParam) =
        {this with Gray = gray}
    static member SetBlueGray ((* PalettesParam *) blueGray : GrayPaletteParam) (this : PalettesParam) =
        {this with BlueGray = blueGray}
    static member JsonEncoder : JsonEncoder<PalettesParam> =
        fun (this : PalettesParam) ->
            E.object [
                "black", E.string (* PalettesParam *) this.Black
                "white", E.string (* PalettesParam *) this.White
                "red", PaletteParam.JsonEncoder (* PalettesParam *) this.Red
                "pink", PaletteParam.JsonEncoder (* PalettesParam *) this.Pink
                "purple", PaletteParam.JsonEncoder (* PalettesParam *) this.Purple
                "deep_purple", PaletteParam.JsonEncoder (* PalettesParam *) this.DeepPurple
                "indigo", PaletteParam.JsonEncoder (* PalettesParam *) this.Indigo
                "blue", PaletteParam.JsonEncoder (* PalettesParam *) this.Blue
                "light_blue", PaletteParam.JsonEncoder (* PalettesParam *) this.LightBlue
                "cyan", PaletteParam.JsonEncoder (* PalettesParam *) this.Cyan
                "teal", PaletteParam.JsonEncoder (* PalettesParam *) this.Teal
                "green", PaletteParam.JsonEncoder (* PalettesParam *) this.Green
                "light_green", PaletteParam.JsonEncoder (* PalettesParam *) this.LightGreen
                "lime", PaletteParam.JsonEncoder (* PalettesParam *) this.Lime
                "yellow", PaletteParam.JsonEncoder (* PalettesParam *) this.Yellow
                "amber", PaletteParam.JsonEncoder (* PalettesParam *) this.Amber
                "orange", PaletteParam.JsonEncoder (* PalettesParam *) this.Orange
                "deep_orange", PaletteParam.JsonEncoder (* PalettesParam *) this.DeepOrange
                "brown", GrayPaletteParam.JsonEncoder (* PalettesParam *) this.Brown
                "gray", GrayPaletteParam.JsonEncoder (* PalettesParam *) this.Gray
                "blue_gray", GrayPaletteParam.JsonEncoder (* PalettesParam *) this.BlueGray
            ]
    static member JsonDecoder : JsonDecoder<PalettesParam> =
        D.object (fun get ->
            {
                Black = get.Optional.Field (* PalettesParam *) "black" D.string
                    |> Option.defaultValue "#000000"
                White = get.Optional.Field (* PalettesParam *) "white" D.string
                    |> Option.defaultValue "#FFFFFF"
                Red = get.Optional.Field (* PalettesParam *) "red" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Pink = get.Optional.Field (* PalettesParam *) "pink" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Purple = get.Optional.Field (* PalettesParam *) "purple" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                DeepPurple = get.Optional.Field (* PalettesParam *) "deep_purple" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Indigo = get.Optional.Field (* PalettesParam *) "indigo" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Blue = get.Optional.Field (* PalettesParam *) "blue" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                LightBlue = get.Optional.Field (* PalettesParam *) "light_blue" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Cyan = get.Optional.Field (* PalettesParam *) "cyan" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Teal = get.Optional.Field (* PalettesParam *) "teal" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Green = get.Optional.Field (* PalettesParam *) "green" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                LightGreen = get.Optional.Field (* PalettesParam *) "light_green" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Lime = get.Optional.Field (* PalettesParam *) "lime" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Yellow = get.Optional.Field (* PalettesParam *) "yellow" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Amber = get.Optional.Field (* PalettesParam *) "amber" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Orange = get.Optional.Field (* PalettesParam *) "orange" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                DeepOrange = get.Optional.Field (* PalettesParam *) "deep_orange" PaletteParam.JsonDecoder
                    |> Option.defaultValue (PaletteParam.Create ())
                Brown = get.Optional.Field (* PalettesParam *) "brown" GrayPaletteParam.JsonDecoder
                    |> Option.defaultValue (GrayPaletteParam.Create ())
                Gray = get.Optional.Field (* PalettesParam *) "gray" GrayPaletteParam.JsonDecoder
                    |> Option.defaultValue (GrayPaletteParam.Create ())
                BlueGray = get.Optional.Field (* PalettesParam *) "blue_gray" GrayPaletteParam.JsonDecoder
                    |> Option.defaultValue (GrayPaletteParam.Create ())
            }
        )
    static member JsonSpec =
        FieldSpec.Create<PalettesParam> (PalettesParam.JsonEncoder, PalettesParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = PalettesParam.JsonEncoder this
    interface IObj
    member this.WithBlack ((* PalettesParam *) black : ColorHex) =
        this |> PalettesParam.SetBlack black
    member this.WithWhite ((* PalettesParam *) white : ColorHex) =
        this |> PalettesParam.SetWhite white
    member this.WithRed ((* PalettesParam *) red : PaletteParam) =
        this |> PalettesParam.SetRed red
    member this.WithPink ((* PalettesParam *) pink : PaletteParam) =
        this |> PalettesParam.SetPink pink
    member this.WithPurple ((* PalettesParam *) purple : PaletteParam) =
        this |> PalettesParam.SetPurple purple
    member this.WithDeepPurple ((* PalettesParam *) deepPurple : PaletteParam) =
        this |> PalettesParam.SetDeepPurple deepPurple
    member this.WithIndigo ((* PalettesParam *) indigo : PaletteParam) =
        this |> PalettesParam.SetIndigo indigo
    member this.WithBlue ((* PalettesParam *) blue : PaletteParam) =
        this |> PalettesParam.SetBlue blue
    member this.WithLightBlue ((* PalettesParam *) lightBlue : PaletteParam) =
        this |> PalettesParam.SetLightBlue lightBlue
    member this.WithCyan ((* PalettesParam *) cyan : PaletteParam) =
        this |> PalettesParam.SetCyan cyan
    member this.WithTeal ((* PalettesParam *) teal : PaletteParam) =
        this |> PalettesParam.SetTeal teal
    member this.WithGreen ((* PalettesParam *) green : PaletteParam) =
        this |> PalettesParam.SetGreen green
    member this.WithLightGreen ((* PalettesParam *) lightGreen : PaletteParam) =
        this |> PalettesParam.SetLightGreen lightGreen
    member this.WithLime ((* PalettesParam *) lime : PaletteParam) =
        this |> PalettesParam.SetLime lime
    member this.WithYellow ((* PalettesParam *) yellow : PaletteParam) =
        this |> PalettesParam.SetYellow yellow
    member this.WithAmber ((* PalettesParam *) amber : PaletteParam) =
        this |> PalettesParam.SetAmber amber
    member this.WithOrange ((* PalettesParam *) orange : PaletteParam) =
        this |> PalettesParam.SetOrange orange
    member this.WithDeepOrange ((* PalettesParam *) deepOrange : PaletteParam) =
        this |> PalettesParam.SetDeepOrange deepOrange
    member this.WithBrown ((* PalettesParam *) brown : GrayPaletteParam) =
        this |> PalettesParam.SetBrown brown
    member this.WithGray ((* PalettesParam *) gray : GrayPaletteParam) =
        this |> PalettesParam.SetGray gray
    member this.WithBlueGray ((* PalettesParam *) blueGray : GrayPaletteParam) =
        this |> PalettesParam.SetBlueGray blueGray