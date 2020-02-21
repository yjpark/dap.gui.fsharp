[<AutoOpen>]
module Dap.Gui.Palette.SchemeParam

open Dap.Prelude
open Dap.Context

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type SurfaceColorParam = {
    Brush : (* SurfaceColorParam *) ColorHex
    Normal : (* SurfaceColorParam *) ColorHex
    Variant : (* SurfaceColorParam *) ColorHex option
} with
    static member Create
        (
            ?brush : (* SurfaceColorParam *) ColorHex,
            ?normal : (* SurfaceColorParam *) ColorHex,
            ?variant : (* SurfaceColorParam *) ColorHex
        ) : SurfaceColorParam =
        {
            Brush = (* SurfaceColorParam *) brush
                |> Option.defaultWith (fun () -> "#000000")
            Normal = (* SurfaceColorParam *) normal
                |> Option.defaultWith (fun () -> "#000000")
            Variant = (* SurfaceColorParam *) variant
        }
    static member SetBrush ((* SurfaceColorParam *) brush : ColorHex) (this : SurfaceColorParam) =
        {this with Brush = brush}
    static member SetNormal ((* SurfaceColorParam *) normal : ColorHex) (this : SurfaceColorParam) =
        {this with Normal = normal}
    static member SetVariant ((* SurfaceColorParam *) variant : ColorHex option) (this : SurfaceColorParam) =
        {this with Variant = variant}
    static member JsonEncoder : JsonEncoder<SurfaceColorParam> =
        fun (this : SurfaceColorParam) ->
            E.object [
                yield "brush", E.string (* SurfaceColorParam *) this.Brush
                yield "normal", E.string (* SurfaceColorParam *) this.Normal
                if this.Variant.IsSome then
                    yield "variant", (E.option E.string) (* SurfaceColorParam *) this.Variant
            ]
    static member JsonDecoder : JsonDecoder<SurfaceColorParam> =
        D.object (fun get ->
            {
                Brush = get.Optional.Field (* SurfaceColorParam *) "brush" D.string
                    |> Option.defaultValue "#000000"
                Normal = get.Optional.Field (* SurfaceColorParam *) "normal" D.string
                    |> Option.defaultValue "#000000"
                Variant = get.Optional.Field (* SurfaceColorParam *) "variant" D.string
            }
        )
    static member JsonSpec =
        FieldSpec.Create<SurfaceColorParam> (SurfaceColorParam.JsonEncoder, SurfaceColorParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = SurfaceColorParam.JsonEncoder this
    interface IObj
    member this.WithBrush ((* SurfaceColorParam *) brush : ColorHex) =
        this |> SurfaceColorParam.SetBrush brush
    member this.WithNormal ((* SurfaceColorParam *) normal : ColorHex) =
        this |> SurfaceColorParam.SetNormal normal
    member this.WithVariant ((* SurfaceColorParam *) variant : ColorHex option) =
        this |> SurfaceColorParam.SetVariant variant

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type BrushColorParam = {
    Normal : (* BrushColorParam *) ColorHex
    Dimmed : (* BrushColorParam *) ColorHex option
    Accent : (* BrushColorParam *) ColorHex option
    Surface : (* BrushColorParam *) ColorHex option
} with
    static member Create
        (
            ?normal : (* BrushColorParam *) ColorHex,
            ?dimmed : (* BrushColorParam *) ColorHex,
            ?accent : (* BrushColorParam *) ColorHex,
            ?surface : (* BrushColorParam *) ColorHex
        ) : BrushColorParam =
        {
            Normal = (* BrushColorParam *) normal
                |> Option.defaultWith (fun () -> "#000000")
            Dimmed = (* BrushColorParam *) dimmed
            Accent = (* BrushColorParam *) accent
            Surface = (* BrushColorParam *) surface
        }
    static member SetNormal ((* BrushColorParam *) normal : ColorHex) (this : BrushColorParam) =
        {this with Normal = normal}
    static member SetDimmed ((* BrushColorParam *) dimmed : ColorHex option) (this : BrushColorParam) =
        {this with Dimmed = dimmed}
    static member SetAccent ((* BrushColorParam *) accent : ColorHex option) (this : BrushColorParam) =
        {this with Accent = accent}
    static member SetSurface ((* BrushColorParam *) surface : ColorHex option) (this : BrushColorParam) =
        {this with Surface = surface}
    static member JsonEncoder : JsonEncoder<BrushColorParam> =
        fun (this : BrushColorParam) ->
            E.object [
                yield "normal", E.string (* BrushColorParam *) this.Normal
                if this.Dimmed.IsSome then
                    yield "dimmed", (E.option E.string) (* BrushColorParam *) this.Dimmed
                if this.Accent.IsSome then
                    yield "accent", (E.option E.string) (* BrushColorParam *) this.Accent
                if this.Surface.IsSome then
                    yield "surface", (E.option E.string) (* BrushColorParam *) this.Surface
            ]
    static member JsonDecoder : JsonDecoder<BrushColorParam> =
        D.object (fun get ->
            {
                Normal = get.Optional.Field (* BrushColorParam *) "normal" D.string
                    |> Option.defaultValue "#000000"
                Dimmed = get.Optional.Field (* BrushColorParam *) "dimmed" D.string
                Accent = get.Optional.Field (* BrushColorParam *) "accent" D.string
                Surface = get.Optional.Field (* BrushColorParam *) "surface" D.string
            }
        )
    static member JsonSpec =
        FieldSpec.Create<BrushColorParam> (BrushColorParam.JsonEncoder, BrushColorParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = BrushColorParam.JsonEncoder this
    interface IObj
    member this.WithNormal ((* BrushColorParam *) normal : ColorHex) =
        this |> BrushColorParam.SetNormal normal
    member this.WithDimmed ((* BrushColorParam *) dimmed : ColorHex option) =
        this |> BrushColorParam.SetDimmed dimmed
    member this.WithAccent ((* BrushColorParam *) accent : ColorHex option) =
        this |> BrushColorParam.SetAccent accent
    member this.WithSurface ((* BrushColorParam *) surface : ColorHex option) =
        this |> BrushColorParam.SetSurface surface

(*
 * Generated: <Record>
 *     IsJson, IsLoose
 *)
type ColorSchemeParam = {
    Primary : (* ColorSchemeParam *) SurfaceColorParam
    Secondary : (* ColorSchemeParam *) SurfaceColorParam
    Label : (* ColorSchemeParam *) BrushColorParam
    Button : (* ColorSchemeParam *) BrushColorParam
    TextField : (* ColorSchemeParam *) BrushColorParam
    Switch : (* ColorSchemeParam *) BrushColorParam
    Box : (* ColorSchemeParam *) BrushColorParam
    Table : (* ColorSchemeParam *) BrushColorParam
    Section : (* ColorSchemeParam *) BrushColorParam
    Panel : (* ColorSchemeParam *) BrushColorParam
    Toolbar : (* ColorSchemeParam *) BrushColorParam
    Error : (* ColorSchemeParam *) BrushColorParam
    Background : (* ColorSchemeParam *) ColorHex
} with
    static member Create
        (
            ?primary : (* ColorSchemeParam *) SurfaceColorParam,
            ?secondary : (* ColorSchemeParam *) SurfaceColorParam,
            ?label : (* ColorSchemeParam *) BrushColorParam,
            ?button : (* ColorSchemeParam *) BrushColorParam,
            ?textField : (* ColorSchemeParam *) BrushColorParam,
            ?switch : (* ColorSchemeParam *) BrushColorParam,
            ?box : (* ColorSchemeParam *) BrushColorParam,
            ?table : (* ColorSchemeParam *) BrushColorParam,
            ?section : (* ColorSchemeParam *) BrushColorParam,
            ?panel : (* ColorSchemeParam *) BrushColorParam,
            ?toolbar : (* ColorSchemeParam *) BrushColorParam,
            ?error : (* ColorSchemeParam *) BrushColorParam,
            ?background : (* ColorSchemeParam *) ColorHex
        ) : ColorSchemeParam =
        {
            Primary = (* ColorSchemeParam *) primary
                |> Option.defaultWith (fun () -> (SurfaceColorParam.Create ()))
            Secondary = (* ColorSchemeParam *) secondary
                |> Option.defaultWith (fun () -> (SurfaceColorParam.Create ()))
            Label = (* ColorSchemeParam *) label
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Button = (* ColorSchemeParam *) button
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            TextField = (* ColorSchemeParam *) textField
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Switch = (* ColorSchemeParam *) switch
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Box = (* ColorSchemeParam *) box
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Table = (* ColorSchemeParam *) table
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Section = (* ColorSchemeParam *) section
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Panel = (* ColorSchemeParam *) panel
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Toolbar = (* ColorSchemeParam *) toolbar
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Error = (* ColorSchemeParam *) error
                |> Option.defaultWith (fun () -> (BrushColorParam.Create ()))
            Background = (* ColorSchemeParam *) background
                |> Option.defaultWith (fun () -> "#FFFFFF")
        }
    static member SetPrimary ((* ColorSchemeParam *) primary : SurfaceColorParam) (this : ColorSchemeParam) =
        {this with Primary = primary}
    static member SetSecondary ((* ColorSchemeParam *) secondary : SurfaceColorParam) (this : ColorSchemeParam) =
        {this with Secondary = secondary}
    static member SetLabel ((* ColorSchemeParam *) label : BrushColorParam) (this : ColorSchemeParam) =
        {this with Label = label}
    static member SetButton ((* ColorSchemeParam *) button : BrushColorParam) (this : ColorSchemeParam) =
        {this with Button = button}
    static member SetTextField ((* ColorSchemeParam *) textField : BrushColorParam) (this : ColorSchemeParam) =
        {this with TextField = textField}
    static member SetSwitch ((* ColorSchemeParam *) switch : BrushColorParam) (this : ColorSchemeParam) =
        {this with Switch = switch}
    static member SetBox ((* ColorSchemeParam *) box : BrushColorParam) (this : ColorSchemeParam) =
        {this with Box = box}
    static member SetTable ((* ColorSchemeParam *) table : BrushColorParam) (this : ColorSchemeParam) =
        {this with Table = table}
    static member SetSection ((* ColorSchemeParam *) section : BrushColorParam) (this : ColorSchemeParam) =
        {this with Section = section}
    static member SetPanel ((* ColorSchemeParam *) panel : BrushColorParam) (this : ColorSchemeParam) =
        {this with Panel = panel}
    static member SetToolbar ((* ColorSchemeParam *) toolbar : BrushColorParam) (this : ColorSchemeParam) =
        {this with Toolbar = toolbar}
    static member SetError ((* ColorSchemeParam *) error : BrushColorParam) (this : ColorSchemeParam) =
        {this with Error = error}
    static member SetBackground ((* ColorSchemeParam *) background : ColorHex) (this : ColorSchemeParam) =
        {this with Background = background}
    static member JsonEncoder : JsonEncoder<ColorSchemeParam> =
        fun (this : ColorSchemeParam) ->
            E.object [
                yield "primary", SurfaceColorParam.JsonEncoder (* ColorSchemeParam *) this.Primary
                yield "secondary", SurfaceColorParam.JsonEncoder (* ColorSchemeParam *) this.Secondary
                yield "label", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Label
                yield "button", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Button
                yield "text_field", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.TextField
                yield "switch", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Switch
                yield "box", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Box
                yield "table", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Table
                yield "section", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Section
                yield "panel", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Panel
                yield "toolbar", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Toolbar
                yield "error", BrushColorParam.JsonEncoder (* ColorSchemeParam *) this.Error
                yield "background", E.string (* ColorSchemeParam *) this.Background
            ]
    static member JsonDecoder : JsonDecoder<ColorSchemeParam> =
        D.object (fun get ->
            {
                Primary = get.Optional.Field (* ColorSchemeParam *) "primary" SurfaceColorParam.JsonDecoder
                    |> Option.defaultValue (SurfaceColorParam.Create ())
                Secondary = get.Optional.Field (* ColorSchemeParam *) "secondary" SurfaceColorParam.JsonDecoder
                    |> Option.defaultValue (SurfaceColorParam.Create ())
                Label = get.Optional.Field (* ColorSchemeParam *) "label" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Button = get.Optional.Field (* ColorSchemeParam *) "button" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                TextField = get.Optional.Field (* ColorSchemeParam *) "text_field" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Switch = get.Optional.Field (* ColorSchemeParam *) "switch" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Box = get.Optional.Field (* ColorSchemeParam *) "box" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Table = get.Optional.Field (* ColorSchemeParam *) "table" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Section = get.Optional.Field (* ColorSchemeParam *) "section" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Panel = get.Optional.Field (* ColorSchemeParam *) "panel" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Toolbar = get.Optional.Field (* ColorSchemeParam *) "toolbar" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Error = get.Optional.Field (* ColorSchemeParam *) "error" BrushColorParam.JsonDecoder
                    |> Option.defaultValue (BrushColorParam.Create ())
                Background = get.Optional.Field (* ColorSchemeParam *) "background" D.string
                    |> Option.defaultValue "#FFFFFF"
            }
        )
    static member JsonSpec =
        FieldSpec.Create<ColorSchemeParam> (ColorSchemeParam.JsonEncoder, ColorSchemeParam.JsonDecoder)
    interface IJson with
        member this.ToJson () = ColorSchemeParam.JsonEncoder this
    interface IObj
    member this.WithPrimary ((* ColorSchemeParam *) primary : SurfaceColorParam) =
        this |> ColorSchemeParam.SetPrimary primary
    member this.WithSecondary ((* ColorSchemeParam *) secondary : SurfaceColorParam) =
        this |> ColorSchemeParam.SetSecondary secondary
    member this.WithLabel ((* ColorSchemeParam *) label : BrushColorParam) =
        this |> ColorSchemeParam.SetLabel label
    member this.WithButton ((* ColorSchemeParam *) button : BrushColorParam) =
        this |> ColorSchemeParam.SetButton button
    member this.WithTextField ((* ColorSchemeParam *) textField : BrushColorParam) =
        this |> ColorSchemeParam.SetTextField textField
    member this.WithSwitch ((* ColorSchemeParam *) switch : BrushColorParam) =
        this |> ColorSchemeParam.SetSwitch switch
    member this.WithBox ((* ColorSchemeParam *) box : BrushColorParam) =
        this |> ColorSchemeParam.SetBox box
    member this.WithTable ((* ColorSchemeParam *) table : BrushColorParam) =
        this |> ColorSchemeParam.SetTable table
    member this.WithSection ((* ColorSchemeParam *) section : BrushColorParam) =
        this |> ColorSchemeParam.SetSection section
    member this.WithPanel ((* ColorSchemeParam *) panel : BrushColorParam) =
        this |> ColorSchemeParam.SetPanel panel
    member this.WithToolbar ((* ColorSchemeParam *) toolbar : BrushColorParam) =
        this |> ColorSchemeParam.SetToolbar toolbar
    member this.WithError ((* ColorSchemeParam *) error : BrushColorParam) =
        this |> ColorSchemeParam.SetError error
    member this.WithBackground ((* ColorSchemeParam *) background : ColorHex) =
        this |> ColorSchemeParam.SetBackground background