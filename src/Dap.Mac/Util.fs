[<AutoOpen>]
module Dap.Mac.Util

open System.IO

open Foundation
open AppKit

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let rec calcLayoutInfo (prefix : string) (widget : Widget) : string list =
    let viewType = (widget.GetType ()) .Name
    [
        yield sprintf "%s%s %A" prefix viewType widget
        for child in widget.Subviews do
            for line in calcLayoutInfo (prefix + "\t") child do
                yield line
    ]

let logLayout (prefab : IPrefab) =
    let widget = prefab.Widget0 :?> Widget
    let info =
        calcLayoutInfo "" widget
        |> String.concat "\n"
    logWip prefab "Layout" info

let tryGetAppBundleID () =
    try
        Some <| NSBundle.MainBundle.BundleIdentifier
    with e ->
        logException (getLogging ()) "Mac.Util.getAppBundleID" "Exception_Raised" () e
        None

let getAppDirectory (directory : NSSearchPathDirectory) =
    let appFolder = Path.Combine ("..", "..")
    match tryGetAppBundleID () with
    | None ->
        match directory with
        | NSSearchPathDirectory.ApplicationSupportDirectory ->
            "data"
        | NSSearchPathDirectory.CachesDirectory ->
            "cache"
        | _ ->
            directory.ToString ()
        |> (fun x -> Path.Combine (appFolder, x))
    | Some bundleID ->
        try
            let fileManager = NSFileManager.DefaultManager
            fileManager.GetUrls (directory, NSSearchPathDomain.User)
            |> Array.tryHead
            |> Option.map (fun url -> url.Path)
            |> Option.map (fun x -> Path.Combine (x, bundleID))
            |> Option.defaultValue appFolder
        with e ->
            logException (getLogging ()) "Mac.Util.getAppDirectory" "Exception_Raised" (directory, appFolder, bundleID) e
            appFolder