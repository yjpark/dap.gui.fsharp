#r "paket: groupref Build //"
#load ".fake/build.fsx/intellisense.fsx"
#load "src/Dap.Forms/Builder/Helper.fs"
#load "src/Dap.Forms/Generator/Gui.fs"
#load "src/Dap.Forms/Generator/Helper.fs"
#load "src/Dap.Forms/Dsl/Prefabs.fs"

open Fake.Core
open Fake.IO.Globbing.Operators

open Dap.Build

let feed =
    NuGet.Feed.Create (
        server = NuGet.ProGet "https://nuget.yjpark.org/nuget/dap",
        apiKey = NuGet.Environment "API_KEY_nuget_yjpark_org"
    )

let projects =
    !! "src/Dap.Forms/*.fsproj"

NuGet.create NuGet.release feed projects

DotNet.createPrepares [
    ["Dap.Forms"], fun _ ->
        Dap.Forms.Dsl.Prefabs.compile ["src" ; "Dap.Forms"]
        |> List.iter traceSuccess
]

Target.runOrDefault DotNet.Build
