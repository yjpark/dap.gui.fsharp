module Faker.App.Feature.Tasks

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Faker.App

let private addProject (project : string) (actions : string list) (projects : IListProperty<IVarProperty<Project>>) =
    let project = Project.Create (project, actions)
    projects.Add ()
    |> fun p -> p.SetValue project
    projects

let setupReloadAsync (builder : IBuilder) =
    let handler = builder.ReloadAsync
    let projects = builder.Properties.Projects
    handler.SetupHandler (fun () -> task {
        //TODO: Get Real Values
        projects.Clear ()
        projects
        |> addProject "[All]" [ "Prepare" ; "Clean" ; "Restore" ; "Build"]
        |> addProject "Faker.App" [ "Prepare" ; "Clean" ; "Restore" ; "Build"]
        |> addProject "Faker.Gui" [ "Prepare" ; "Clean" ; "Restore" ; "Build"]
        |> addProject "Faker.Console" [ "Prepare" ; "Clean" ; "Restore" ; "Build" ; "Run"]
        |> ignore
        return ()
    })


