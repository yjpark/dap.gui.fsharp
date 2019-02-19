[<AutoOpen>]
module Dap.Gui.Internal.BasePrefab

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePrefab<'prefab, 'model, 'widget when 'prefab :> IPrefab and 'model :> IViewProps>
        (kind : Kind, spawner, logging : ILogging, widget : 'widget) as self =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let mutable wrapper : IPrefab option = None
    let mutable styles : IStyle list = []
    do (
        base.Properties.Styles.OnAdded.AddWatcher base.AsOwner "Styles_OnAdded" (fun (style', _index) ->
            Styles.create self style'.Value
            |> Option.iter (fun style ->
                styles <- styles @ [ style ]
                logWarn self "Style_Added" style'.Value style
            )
        )
    )
    member __.Wrapper = wrapper
    member __.Widget = widget
    member __.Styles = styles
    member this.Model = this.Properties
    member this.SetWrapper' wrapper' json =
        wrapper <- Some wrapper'
        logWip this "DDDDDDDDDDDDDDDDDDDDDDDDD" (E.encode 4 json)
        this.Model.LoadJson json
        logWip this "EEEEEEEEEEEEEEEEEEEEEEEEE" (encodeJson 4 this.Model)
    interface IPrefab<'model, 'widget> with
        member this.Widget = this.Widget
    interface IPrefab with
        member __.Wrapper = wrapper
        member __.Widget0 = widget :> obj
        member __.Styles = styles
        member __.ApplyStyles () =
            styles
            |> List.iter (fun s -> s.Apply ())
        member this.SetWrapper' wrapper' json = this.SetWrapper' wrapper' json
    member this.AsPrefab = this :> IPrefab<'model, 'widget>
