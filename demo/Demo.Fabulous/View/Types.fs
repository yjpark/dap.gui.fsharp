module Demo.Fabulous.View.Types

open Fabulous.DynamicViews

open Dap.Platform
open Dap.Fabulous

module ViewTypes = Dap.Fabulous.View.Types

open Demo.App

type Page =
    | HomePage

type Args = ViewTypes.Args<IApp, Model, Msg>

and Model = {
    Page : Page
    Ver : int
}

and Msg =
    | DoRepaint
with interface IMsg

and View = ViewTypes.View<IApp, Model, Msg>
and Initer = ViewTypes.Initer<Model, Msg>
and Render = ViewTypes.Render<IApp, Model, Msg>
and Widget = ViewTypes.Widget

type Fabulous.DynamicViews.View with
    static member ScrollingContentPage(title, children) =
        View.ContentPage(title=title, content=View.ScrollView(View.StackLayout(padding=20.0, children=children) ), useSafeArea=true)

    static member NonScrollingContentPage(title, children, ?gestureRecognizers) =
        View.ContentPage(title=title, content=View.StackLayout(padding=20.0, children=children, ?gestureRecognizers=gestureRecognizers), useSafeArea=true)

