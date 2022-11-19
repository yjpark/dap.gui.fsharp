open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators

open Dap.Build

open FSharp.Data
open Dap.Prelude
open Dap.Context.Generator.Util

let feed =
    NuGet.Feed.Create (
        apiKey = NuGet.Environment "API_KEY_nuget_org"
    )

let projects =
    !! "../src/Dap.Skia/*.fsproj"
    ++ "../src/Dap.Gui/*.fsproj"
    ++ "../src/Dap.Gtk/*.fsproj"
    ++ "../src/Dap.UWP.Cli/*.csproj"
    ++ "../src/Dap.UWP/*.fsproj"

type Ionicons = XmlProvider<"../src/Dap.Skia/Data/ionicons.svg">
type Glyph = {
    Name : string
    Code : string
} with
    static member Create name code : Glyph =
        {
            Name = name
            Code = code
        }

let createProjects () =
    NuGet.create NuGet.release feed projects

    DotNet.createPrepares [
        ["Dap.Gui"], fun _ ->
            Dap.Gui.Dsl.Models.compile ["../src" ; "Dap.Gui"]
            |> List.iter traceSuccess
            Dap.Gui.Dsl.PaletteParam.compile ["../src" ; "Dap.Gui"]
            |> List.iter traceSuccess
            Dap.Gui.Dsl.Prefabs.compile ["../src" ; "Dap.Gui"]
            |> List.iter traceSuccess
    ]

    Target.create "IoniconsGlyph" (fun _ ->
        let ionicons = Ionicons.Parse (System.IO.File.ReadAllText "../src/Dap.Skia/Data/ionicons.svg")
        let glyphs =
            ionicons.Defs.Font.Glyphs
            |> Array.map (fun glyph ->
                let code = ((int) glyph.Unicode.[0]) .ToString ("x")
                Glyph.Create glyph.GlyphName code
            )
        let filterGlyphs (prefix : string) =
            glyphs
            |> Array.choose (fun glyph ->
                if glyph.Name.StartsWith (prefix) then
                    Some {glyph with Name = glyph.Name.Replace (prefix, "")}
                else
                    None
            )
        let mdIcons = filterGlyphs "ion-md-"
        let iosIcons = filterGlyphs "ion-ios-"
        let logoIcons = filterGlyphs "ion-logo-"
        let otherIcons =
            glyphs
            |> Array.filter (fun g ->
                let name = g.Name
                not (name.StartsWith "ion-md-")
                    && not (name.StartsWith "ion-ios-")
                    && not (name.StartsWith "ion-logo-")
            )
        let getGlyphMembers (glyphs : Glyph array) =
            glyphs
            |> Array.toList
            |> List.map (fun g -> {g with Name = g.Name.Replace ("-", "_")})
            |> List.map (fun g -> {g with Name = g.Name.AsCodeMemberName})
            |> List.sortBy (fun g -> g.Name)
            |> List.map (fun g ->
                sprintf "    member __.%s = '\\u%s'.ToString ()" g.Name g.Code
            )
        let getOtherIcons () =
            if otherIcons.Length = 0 then
                [
                    "type OtherIcons () = class"
                    "    end"
                ]
            else
                [
                    "type OtherIcons () ="
                ] @ getGlyphMembers otherIcons
        [
            "module Dap.Skia.IoniconsGlyph"
            "//Auto Generated, Do NOT Edit"
            ""
            "type MDIcons () ="
        ] @ getGlyphMembers mdIcons @ [
            ""
            "type IOSIcons () ="
        ] @ getGlyphMembers iosIcons @ [
            ""
            "type LogoIcons () ="
        ] @ getGlyphMembers logoIcons @ [
            ""
        ] @ getOtherIcons ()
        |> String.concat "\n"
        |> Dap.Local.TextFile.save "../src/Dap.Skia/Fonts/IoniconsGlyph.fs"
    )

Target.runOrDefault DotNet.Build
