module Faker.App.Feature.Fake

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Faker.App

type Context (logging : ILogging) =
    inherit BaseBuilder<Context> (logging)
    do (
        // TODO
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
    static member AddToAgent (agent : IAgent) =
        new Context (agent.Env.Logging) :> IBuilder
