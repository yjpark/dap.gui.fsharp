[<AutoOpen>]
module Dap.Gui.Thread

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

type GuiSynchronizationContext (logger : ILogger) =
    inherit SynchronizationContext ()
    let mainThread = Thread.CurrentThread.ManagedThreadId;
    let pendingCallbacks = new System.Collections.Generic.Queue<SendOrPostCallback * obj> ()
    static member Create l =
        let context = new GuiSynchronizationContext (l)
        SynchronizationContext.SetSynchronizationContext context
        context
    override this.Send (callback : SendOrPostCallback, state : obj) =
        if mainThread = Thread.CurrentThread.ManagedThreadId then
            this.Invoke (callback, state)
        else
            this.Post (callback, state)
    override __.Post (callback : SendOrPostCallback, state : obj) =
        lock pendingCallbacks (fun () ->
            pendingCallbacks.Enqueue (callback, state)
        )
    member __.Invoke (callback : SendOrPostCallback, state : obj) =
        try
            callback.Invoke (state)
        with e ->
            logError logger "GuiSynchronizationContext" "Exception_Raised" (callback, state, e)
    member this.Execute (?maxActionCount : int) =
        let maxActionCount = defaultArg maxActionCount -1
        lock pendingCallbacks (fun () ->
            let mutable count = 0
            while pendingCallbacks.Count > 0 && (maxActionCount < 0 || count <= maxActionCount) do
                let (callback, state) = pendingCallbacks.Dequeue ()
                this.Invoke (callback, state)
                count <- count + 1
        )

let mutable private guiThread : int option = None
let mutable private guiContext : SynchronizationContext option = None
let mutable private guiLogger : ILogger option = None

let internal setupGuiContext' (logger : ILogger) =
    match guiContext with
    | Some guiContext' ->
        logError logger "setupGuiContext'" "Already_Setup" guiContext'
    | None ->
        let mutable guiContext' = SynchronizationContext.Current
        if guiContext' =? null then
            guiContext' <- GuiSynchronizationContext.Create (logger)
            logError logger "setupGuiContext'" "Created" guiContext'
        guiThread <- Some Thread.CurrentThread.ManagedThreadId
        guiContext <- Some guiContext'
        guiLogger <- Some logger
        logWarn logger "setupGuiContext'" "Succeed" guiContext'

let isGuiThread () =
    match guiThread with
    | None -> false
    | Some thread ->
        thread = Thread.CurrentThread.ManagedThreadId

let executeGuiActions' () =
    match guiContext with
    | Some context ->
        match context with
        | :? GuiSynchronizationContext as context ->
            if isGuiThread () then
                context.Execute ()
            else
                logError guiLogger.Value "Thread.executeGuiActions" "Is_Not_GuiThread" (context, guiThread)
        | _ ->
            logError guiLogger.Value "Thread.executeGuiActions" "Is_Not_GuiSynchronizationContext" (context)
    | None ->
        logError (getLogging ()) "Thread.executeGuiActions" "GuiContext_Not_Exist" ()

let getGuiContext () = guiContext |> Option.get

let hasGuiContext () = guiContext.IsSome

let runGuiFunc (func : unit -> unit) : unit =
    match guiContext with
    | Some context ->
        if isGuiThread () then
            func ()
        else
            let callback = SendOrPostCallback(fun _ ->
                func ()
            )
            context.Post (callback, null)
    | None ->
        logError (getLogging ()) "Thread.runGuiFunc" "GuiContext_Not_Exist" ()
        func ()

let runGuiFunc' (func : unit -> unit) : unit =
    match guiContext with
    | Some context ->
        let callback = SendOrPostCallback(fun _ ->
            func ()
        )
        context.Post (callback, null)
    | None ->
        logError (getLogging ()) "Thread.runGuiFunc'" "GuiContext_Not_Exist" ()
        func ()

//TODO: Replace the async usage with standard dotnet core logic
let getGuiTask (getTask : unit -> Task<'res>) : Task<'res> = task {
    return! async {
        (*
        while guiContext.IsNone do
            do! Async.Sleep 50
        *)
        do! Async.SwitchToContext (getGuiContext ())
        return! Async.AwaitTask (getTask ())
    }
}
