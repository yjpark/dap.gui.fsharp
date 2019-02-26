[<AutoOpen>]
module Dap.Gui.App.Thread

open System.Threading
open System.Threading.Tasks
open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

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

let internal setupGuiContext' (logger : ILogger) =
    match guiContext with
    | Some guiContext' ->
        logError logger "setupGuiContext'" "Already_Setup" guiContext'
    | None ->
        let guiContext' = SynchronizationContext.Current
        if guiContext' =? null then
            let guiContext' = GuiSynchronizationContext.Create (logger)
            logError logger "setupGuiContext'" "Created" guiContext'
        guiThread <- Some Thread.CurrentThread.ManagedThreadId
        guiContext <- Some guiContext'
        logWarn logger "setupGuiContext'" "Succeed" guiContext'

let internal isGuiThread () =
    match guiThread with
    | None -> false
    | Some thread ->
        thread = Thread.CurrentThread.ManagedThreadId

let internal getGuiContext () = guiContext |> Option.get

let internal hasGuiContext () = guiContext.IsSome

let internal runGuiFunc (func : unit -> unit) : unit =
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

(*
 * Can compile, but running has issues, left here in case needed in the future, also as reference
 *
let internal getGuiTask (getTask : unit -> Task<'res>) : Task<'res> =
    match guiContext with
    | Some context ->
        if isGuiThread () then
            getTask ()
        else
            let onDone = new TaskCompletionSource<'res> ()
            let callback = SendOrPostCallback(fun _ ->
                let task = getTask ()
                if not task.IsCompleted then
                    task.Wait ()
                onDone.SetResult task.Result
            )
            context.Send (callback, null)
            onDone.Task
    | None ->
        logError (getLogging ()) "Thread.getGuiTask" "GuiContext_Not_Exist" ()
        getTask ()
*)
