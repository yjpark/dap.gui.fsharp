#r "paket: groupref Build //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.IO.Globbing.Operators

open Dap.Build

#load "src/Faker.App/Dsl.fs"
#load "src/Faker.Gui/Dsl/Prefabs.fs"

let feed =
    NuGet.Feed.Create (
        server = NuGet.ProGet "https://nuget.yjpark.org/nuget/dap",
        apiKey = NuGet.Environment "API_KEY_nuget_yjpark_org"
    )

let projects =
    !! "src/Faker.App/*.fsproj"
    ++ "src/Faker.Gui/*.fsproj"
    ++ "src/Faker.Console/*.fsproj"

NuGet.create NuGet.release feed projects

DotNet.createPrepares [
    ["Faker.App"], fun _ ->
        Faker.App.Dsl.compile ["src" ; "Faker.App"]
        |> List.iter traceSuccess
    ["Faker.Gui"], fun _ ->
        Faker.Gui.Dsl.Prefabs.compile ["src" ; "Faker.Gui"]
        |> List.iter traceSuccess
]

Target.runOrDefault DotNet.Build
