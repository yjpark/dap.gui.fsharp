[<AutoOpen>]
module Dap.Gui.Internal.BasePrefab

open Dap.Prelude
open Dap.Context
open Dap.Gui

[<AbstractClass>]
type BasePrefab<'prefab, 'model, 'widget when 'prefab :> IPrefab and 'model :> IViewProps>
        (kind : Kind, spawner, logging : ILogging, widget : 'widget) =
    inherit CustomContext<'prefab, ContextSpec<'model>, 'model> (logging, new ContextSpec<'model> (kind, spawner))
    let mutable parent : IPrefab option = None
    let mutable path : string option = None
    let mutable key : string option = None
    let mutable extras : Map<string, obj> = Map.empty
    let mutable styles : IStyle list = []
    abstract member OnSetup : unit -> unit
    default __.OnSetup () = ()
    member __.Widget = widget
    member __.Styles = styles
    member this.Model = this.Properties
    member this.Setup' (parent' : IPrefab option) (key' : string) =
        if path.IsSome then
            logError this "SetParent" "Already_Set" (parent, path, key, parent', key')
        else
            parent <- parent'
            key <- Some key'
            path <- Some (
                match parent' with
                | None ->
                    key'
                | Some p ->
                    sprintf "%s/%s" p.Path key'
            )
            styles <- Styles.init this
            base.Properties.Styles.OnAdded.AddWatcher base.AsOwner "Styles_OnAdded" (fun (style', _index) ->
                styles <- styles @ Styles.create this style'.Value
            )
            this.OnSetup ()
    member this.LoadJson' (json : Json) =
        (this.Model :> IProperty) .LoadJson json
        //logWip this "LoadJson_Model" (encodeJson 4 this.Model)
    interface IPrefab<'model, 'widget> with
        member this.Widget = this.Widget
    interface IPrefab<'model> with
        member this.Model = this.Model
    interface IPrefab with
        member __.Parent = parent
        member __.Path = path |> Option.defaultValue ""
        member __.Key = key |> Option.defaultValue ""
        member this.Setup' p k = this.Setup' p k
        member __.Widget0 = widget :> obj
        member __.Extras = extras
        member __.SetExtras' extras' = extras <- extras'
        member __.Styles = styles
        member __.SetStyles' styles' = styles <- styles'
        member __.ApplyStyles () =
            styles
            |> List.iter (fun s -> s.Apply ())
    member this.AsPrefab = this :> IPrefab<'model, 'widget>
    member this.AsPrefab0 = this :> IPrefab
