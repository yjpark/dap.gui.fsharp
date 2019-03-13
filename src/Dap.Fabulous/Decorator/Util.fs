[<RequireQualifiedAccess>]
module Dap.Fabulous.Decorator.Util

open System.Reflection

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let mutable private fields : Map<string, Result<FieldInfo, exn>> = Map.empty

let private getField'<'target> (isStatic : bool) (logger : ILogger) (fieldName : string) : FieldInfo option =
    let key = sprintf "<%s>.%s" (typeof<'target> .FullName) fieldName
    fields
    |> Map.tryFind key
    |> function
    | None ->
        try
            let field =
                typeof<'target> .GetField
                    (fieldName, BindingFlags.NonPublic ||| (if isStatic then BindingFlags.Static else BindingFlags.Instance))
            if field <> null then
                fields <-
                    fields |> Map.add key (Ok field)
                Some field
            else
                failWith "FieldInfo_Not_Found" fieldName
        with e ->
            logException logger "Util.getField" "Exception_Raised" key e
            fields <-
                fields |> Map.add key (Error e)
            None
    | Some field ->
        match field with
        | Ok f -> Some f
        | Error _ -> None

let getStaticField<'target> = getField'<'target> true

let getInstanceField<'target> = getField'<'target> false

let getStaticValue<'target, 'value> logger fieldName =
    getStaticField<'target> logger fieldName
    |> Option.bind (fun field ->
        try
            let v = field.GetValue ()
            Some (v :?> 'value)
        with e ->
            logException logger "Cell.getStaticValue" "Exception_Raised" (fieldName, typeof<'value>.FullName, field) e
            None
    )

let getInstanceValue<'target, 'value> logger fieldName (target : 'target) =
    getInstanceField<'target> logger fieldName
    |> Option.bind (fun field ->
        try
            let v = field.GetValue (target)
            Some (v :?> 'value)
        with e ->
            logException logger "Cell.getInstanceValue" "Exception_Raised" (fieldName, typeof<'value>.FullName, field) e
            None
    )

let getBindableProperty<'target> logger fieldName =
    getStaticValue<'target, BindableProperty> logger fieldName

let getBindableValue<'target, 'value> logger fieldName (target : BindableObject) =
    getBindableProperty<'target> logger fieldName
    |> Option.bind (fun prop ->
        try
            Some (target.GetValue prop :?> 'value)
        with e ->
            logException logger "Cell.getBindableValue" "Exception_Raised" (prop, typeof<'value>.FullName) e
            None
    )
