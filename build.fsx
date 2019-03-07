(* FAKE: 5.12.1 *)
#r "paket: groupref Main //"
#load ".fake/build.fsx/intellisense.fsx"

#load "src/Dap.Gui/Dsl/Models.fs"
//(*
#load "src/Dap.Gui/_Gen/Models.fs"
#load "src/Dap.Gui/_Gen/Builder/Models.fs"
#load "src/Dap.Gui/_Gen/Builder/Internal/Base.fs"
#load "src/Dap.Gui/ContainerKind.fs"
#load "src/Dap.Gui/Builder/Helper.fs"
#load "src/Dap.Gui/Generator/Types.fs"
#load "src/Dap.Gui/Generator/Prefab.fs"
#load "src/Dap.Gui/Generator/Helper.fs"
#load "src/Dap.Gui/Dsl1/Prefabs.fs"

#load "demo/Demo.App/Dsl.fs"
#load "demo/Demo.Gui/Dsl/Prefabs.fs"
//*)

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators

open Dap.Build

[<Literal>]
let Prepare = "Prepare"

let feed =
    NuGet.Feed.Create (
        apiKey = NuGet.Environment "API_KEY_nuget_org"
        //server = NuGet.ProGet "https://nuget.yjpark.org/nuget/dap",
        //apiKey = NuGet.Environment "API_KEY_nuget_yjpark_org"
    )

let libProjects =
    !! "src/Dap.Gui/*.fsproj"
    ++ "src/Dap.Gtk/*.fsproj"
    ++ "src/Dap.Myra/*.fsproj"
    ++ "src/Dap.Fabulous/*.fsproj"
    ++ "src/Dap.Fabulous.Forms/*.fsproj"
    ++ "src/Dap.Fabulous.Ooui/*.fsproj"
    ++ "src/Dap.Yoga/*.fsproj"
    ++ "src/Dap.Yoga.Gtk/*.fsproj"
    ++ "src/Dap.Yoga.Myra/*.fsproj"

let allProjects =
    libProjects
    ++ "demo/Demo.App/*.fsproj"
    ++ "demo/Demo.Fabulous/*.fsproj"
    ++ "demo/Demo.Ooui/*.fsproj"
    ++ "demo/Demo.Gui/*.fsproj"
    ++ "demo/Demo.Myra/*.fsproj"
    ++ "demo/Demo.Gtk/*.fsproj"

DotNet.create (DotNet.mixed libProjects) allProjects

NuGet.extend NuGet.release feed libProjects

DotNet.createPrepares [
    ["Dap.Gui"], fun _ ->
        Dap.Gui.Dsl.Models.compile ["src" ; "Dap.Gui"]
        |> List.iter traceSuccess
        //(*
        Dap.Gui.Dsl.Prefabs.compile ["src" ; "Dap.Gui"]
        |> List.iter traceSuccess
        //*)
    //(*
    ["Demo.App"], fun _ ->
        Demo.App.Dsl.compile ["demo" ; "Demo.App"]
        |> List.iter traceSuccess
    ["Demo.Gui"], fun _ ->
        Demo.Gui.Dsl.Prefabs.compile ["demo" ; "Demo.Gui"]
        |> List.iter traceSuccess
    //*)
]

Target.runOrDefault DotNet.Build
