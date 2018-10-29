[<AutoOpen>]
module Dap.Forms.Runner

open System.Threading.Tasks
open FSharp.Control.Tasks.V2
open Xamarin.Forms

open Dap.Prelude
open Dap.Platform

[<Literal>]
let DefaultTimeout = 0.1<second>

type IRunner<'runner when 'runner :> IRunner> with
    member this.RunFormsFunc (func : Func<'runner, unit>) : unit =
        Device.BeginInvokeOnMainThread (fun () ->
            runFunc' this.Runner func
            |> ignore
        )
    member this.GetFormsTask' (timeout : float<second>)
                            (onFailed : OnFailed<'runner>)
                            (getTask : GetTask<'runner, unit>)
                            : GetTask<'runner, unit> =
        fun runner -> task {
            Device.BeginInvokeOnMainThread (fun () ->
                try
                    let task = getTask runner
                    let timeout' = System.TimeSpan.FromMilliseconds (1000.0 * float timeout)
                    if (task.Wait (timeout')) then
                        failWith "RunFormsTask" "Timeout" (task, timeout)
                with e ->
                    onFailed runner e
            )
        }
    member this.GetFormsTask (onFailed : OnFailed<'runner>)
                            (getTask : GetTask<'runner, unit>)
                            : GetTask<'runner, unit> =
        this.GetFormsTask' DefaultTimeout onFailed getTask
    member this.AddFormsTask' : float<second> -> OnFailed<'runner> -> GetTask<'runner, unit> -> unit =
        fun timeout onFailed getTask ->
            this.AddTask onFailed <| this.GetFormsTask' timeout onFailed getTask
    member this.AddFormsTask : OnFailed<'runner> -> GetTask<'runner, unit> -> unit =
        fun onFailed getTask ->
            this.AddTask onFailed <| this.GetFormsTask onFailed getTask
    member this.RunFormsTask' : float<second> -> OnFailed<'runner> -> GetTask<'runner, unit> -> unit =
        fun timeout onFailed getTask ->
            this.RunTask onFailed <| this.GetFormsTask' timeout onFailed getTask
    member this.RunFormsTask : OnFailed<'runner> -> GetTask<'runner, unit> -> unit =
        fun onFailed getTask ->
            this.RunTask onFailed <| this.GetFormsTask onFailed getTask