(* FAKE: 5.12.0 *)
#r "paket: groupref Build //"
#load ".fake/build.fsx/intellisense.fsx"

#load "src/Dap.Gui/Dsl/Models.fs"
//(*
#load "src/Dap.Gui/_Gen/Models.fs"
#load "src/Dap.Gui/_Gen/Builder/Models.fs"
#load "src/Dap.Gui/_Gen/Builder/Internal/Base.fs"
#load "src/Dap.Gui/LayoutConst.fs"
#load "src/Dap.Gui/Builder/Helper.fs"
#load "src/Dap.Gui/Generator/Types.fs"
#load "src/Dap.Gui/Generator/Prefab.fs"
#load "src/Dap.Gui/Generator/Helper.fs"
#load "src/Dap.Gui/Dsl/Prefabs.fs"
//*)

open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO.Globbing.Operators

open Dap.Build

[<Literal>]
let Prepare = "Prepare"

let feed =
    NuGet.Feed.Create (
        server = NuGet.ProGet "https://nuget.yjpark.org/nuget/dap",
        apiKey = NuGet.Environment "API_KEY_nuget_yjpark_org"
    )

let projects =
    !! "src/Dap.Gui/*.fsproj"

NuGet.create NuGet.release feed projects

DotNet.createPrepares [
    ["Dap.Gui"], fun _ ->
        Dap.Gui.Dsl.Models.compile ["src" ; "Dap.Gui"]
        |> List.iter traceSuccess
        //(*
        Dap.Gui.Dsl.Prefabs.compile ["src" ; "Dap.Gui"]
        |> List.iter traceSuccess
        //*)
]

Target.runOrDefault DotNet.Build
