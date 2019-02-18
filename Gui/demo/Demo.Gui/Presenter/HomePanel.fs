[<RequireQualifiedAccess>]
module Demo.Gui.Presenter.HomePanel

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

open Demo.App
open Demo.Gui.Prefab

type Prefab = IHomePanel

type Presenter (env : IEnv) =
    inherit BasePresenter<IApp, Prefab> (Feature.create<Prefab> env.Logging)
    override this.OnDidAttach () =
        let prefab = this.Prefab
        let app = this.Domain.Value
        let contacts = app.AddressBook.Context.Properties.Contacts
        let contacts' = new Contacts.Presenter (prefab.Contacts, app)
        contacts.OnAdded.AddWatcher prefab "ContactsOnAdded" (fun _ ->
            contacts'.Attach contacts
        )
        if contacts.Count > 0 then
            contacts'.Attach contacts
        ()
    static member Create e = new Presenter (e)