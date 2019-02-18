module Demo.App.Feature.AddressBook

open FSharp.Control.Tasks.V2

open Dap.Prelude
open Dap.Context
open Dap.Platform

open Demo.App

let private addContact (name : string) (phone : string) (contacts : IListProperty<IVarProperty<Contact>>) =
    let contact = Contact.Create (name, phone)
    contacts.Add ()
    |> fun p -> p.SetValue contact
    contacts

let private setupReloadAsync (addressBook : IAddressBook) =
    let handler = addressBook.ReloadAsync
    let contacts = addressBook.Properties.Contacts
    handler.SetupHandler (fun () -> task {
        contacts.Clear ()
        contacts
        |> addContact "YJ Park" "12345678"
        |> addContact "John Doe" "12345678"
        |> addContact "Jane Doe" "12345678"
        |> ignore
        return ()
    })

type Context (logging : ILogging) =
    inherit BaseAddressBook<Context> (logging)
    do (
        let addressBook = base.AsAddressBook
        setupReloadAsync addressBook
    )
    override this.Self = this
    override __.Spawn l = new Context (l)
    static member AddToAgent (agent : IAgent) =
        new Context (agent.Env.Logging) :> IAddressBook
