[<AutoOpen>]
module Dap.Fabulous.Builder.Helper

open Xamarin.Forms

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

(* Views *)
let label = new Label.Builder ()
let button = new Button.Builder ()
let scroll_view = new ScrollView.Builder ()
let table_view = new TableView.Builder ()

(* Layouts *)
let stack_layout = new StackLayout.Builder ()

let text_cell = new TextCell.Builder ()
let switch_cell = new SwitchCell.Builder ()
let view_cell = new ViewCell.Builder ()

(* Pages *)
let content_page = new ContentPage.Builder ()
let navigation_page = new NavigationPage.Builder ()

(* Customized Builders *)
type HBoxBuilder () =
    inherit StackLayout.Builder ()
    override this.Zero () =
        this.StackOrientation (base.Zero (), StackOrientation.Horizontal)

type VBoxBuilder () =
    inherit StackLayout.Builder ()
    override this.Zero () =
        this.StackOrientation (base.Zero (), StackOrientation.Vertical)

let h_box = new HBoxBuilder ()
let v_box = new VBoxBuilder ()

(* Custom Control Builders *)
let text_action_cell = new TextActionCell.Builder ()