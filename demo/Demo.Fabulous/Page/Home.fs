[<RequireQualifiedAccess>]
module Demo.Fabulous.Page.Home

open Xamarin.Forms
open Fabulous.DynamicViews

open Dap.Prelude
open Dap.Platform
open Dap.Fabulous.Builder

open Demo.App
open Demo.Fabulous
open Demo.Fabulous.View.Types

let mutable count = 0

let render (runner : View) (model : Model) =
    content_page {
        content (v_box {
            children [
                label {
                    text (sprintf "Count = %d" count)
                }
                table_view {
                    intent TableIntent.Menu
                    items [
                        ("First Section", [
                            text_action_cell {
                                text "Click to Plus"
                                detail "test"
                                action "Plus"
                                onAction (fun _ ->
                                    count <- count + 1
                                    runner.React DoRepaint
                                )
                            }
                        ])
                        ("Second Section", [
                            text_action_cell {
                                text "Click to Minus"
                                detail "test"
                                action "Minus"
                                onAction (fun _ ->
                                    count <- count - 1
                                    runner.React DoRepaint
                                )
                            }
                        ])
                    ]
                }
            ]
        })
    }