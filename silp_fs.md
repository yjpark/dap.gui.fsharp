# COMMON_OPENS #
```F#
open System
open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui
open Dap.Gui.Prefab
open Dap.Gui.Container
open Dap.Gui.Internal
```

# FORMS_OPENS #
```F#
open Xamarin.Forms
//SILP: COMMON_OPENS
```

# IOS_OPENS #
```F#
open Foundation
open UIKit
open Dap.iOS
//SILP: COMMON_OPENS
```

# ANDROID_OPENS #
```F#
open Dap.Android
//SILP: COMMON_OPENS
```

# MAC_OPENS #
```F#
open Foundation
open AppKit
open Dap.Mac
//SILP: COMMON_OPENS
```

# GTK_OPENS #
```F#
open Dap.Gtk
//SILP: COMMON_OPENS
```

# MYRA_OPENS #
```F#
open Dap.Myra
//SILP: COMMON_OPENS
```

# FORMS_OPENS #
```F#
open Xamarin.Forms
//SILP: COMMON_OPENS
```

# PREFAB_HEADER(prefab) #
```F#
type ${prefab} (logging : ILogging) =
    inherit BasePrefab<${prefab}, ${prefab}Props, ${prefab}Widget>
        (${prefab}Kind, ${prefab}Props.Create, logging, new ${prefab}Widget ())
```

# PREFAB_HEADER_CREATE(prefab) #
```F#
type ${prefab} (logging : ILogging) =
    inherit BasePrefab<${prefab}, ${prefab}Props, ${prefab}Widget>
        (${prefab}Kind, ${prefab}Props.Create, logging, IPrefab.Create${prefab} ())
```

# PREFAB_MIDDLE(prefab) #
```F#
    do (
        let kind = ${prefab}Kind
        let owner = base.AsOwner
        let model = base.Model
        let widget = base.Widget
```

# PREFAB_HEADER_MIDDLE(prefab) #
```F#
//SILP: PREFAB_HEADER(${prefab})
//SILP: PREFAB_MIDDLE(${prefab})
```

# PREFAB_HEADER_MIDDLE_CREATE(prefab) #
```F#
//SILP: PREFAB_HEADER_CREATE(${prefab})
//SILP: PREFAB_MIDDLE(${prefab})
```

# PREFAB_FOOTER(prefab) #
```F#
static member Create l = new ${prefab} (l)
static member Create () = new ${prefab} (getLogging ())
override this.Self = this
override __.Spawn l = ${prefab}.Create l
interface IFallback
```

# CONTAINER_HEADER(container, widget) #
```F#
type ${container} (logging : ILogging) =
    inherit BaseContainer<${container}, ${container}Widget, ${widget}>
        (${container}Kind, logging, new ${container}Widget ())
```

# CONTAINER_HEADER_CREATE(container, widget) #
```F#
type ${container} (logging : ILogging) =
    inherit BaseContainer<${container}, ${container}Widget, ${widget}>
        (${container}Kind, logging, IContainer.Create${container} ())
```

# CONTAINER_MIDDLE(container) #
```F#
    do (
        let kind = ${container}Kind
        let owner = base.AsOwner
        let widget = base.Widget
```

# CONTAINER_HEADER_MIDDLE(container, widget) #
```F#
//SILP: CONTAINER_HEADER(${container}, ${widget})
//SILP: CONTAINER_MIDDLE(${container})
```

# CONTAINER_HEADER_MIDDLE_CREATE(container, widget) #
```F#
//SILP: CONTAINER_HEADER_CREATE(${container}, ${widget})
//SILP: CONTAINER_MIDDLE(${container})
```

# CONTAINER_FOOTER(container) #
```F#
static member Create l = new ${container} (l)
static member Create () = new ${container} (getLogging ())
override this.Self = this
override __.Spawn l = ${container}.Create l
interface IFallback
```

# FABULOUS_BUILDER_BUILD(kind) #
```F#
override __.Build (builder : AttributesBuilder) =
    ViewElement.Create<${kind}>
        (ViewBuilders.CreateFunc${kind}, ViewBuilders.UpdateFunc${kind}, builder)
```

# FABULOUS_BUILDER_OPERATION(kind, type, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : ${type}) =
    attributes.With (ViewAttributes.${key}AttribKey, ${op})
```

# FABULOUS_BUILDER_OPERATION_ARRAY(kind, type, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : ${type} list) =
    attributes.With (ViewAttributes.${key}AttribKey, Array.ofList ${op})
```

# FABULOUS_BUILDER_OPERATION_COMMAND(kind, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : unit -> unit) =
    attributes.With (ViewAttributes.${key}AttribKey, makeCommand ${op})
```

# FABULOUS_BUILDER_OPERATION_EVENT(kind, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : unit -> unit) =
    attributes.With (ViewAttributes.${key}AttribKey, (fun f ->
        System.EventHandler (fun _sender _args -> f ())) (${op}))
```

# FABULOUS_BUILDER_OPERATION_EVENT_ARGS(kind, type, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : ${type} -> unit) =
    attributes.With (ViewAttributes.${key}AttribKey, (fun f ->
        System.EventHandler<${type}> (fun _sender args -> f args)) (${op}))
```

# FABULOUS_BUILDER_OPERATION_CALLBACK_ARGS(kind, type, key, op) #
```F#
[<CustomOperation("${op}")>]
member __.${key} (attributes : Attributes<${kind}>, ${op} : ${type} -> unit) =
    attributes.With (ViewAttributes.${key}AttribKey, (fun f ->
        FSharp.Control.Handler<_> (fun _sender args -> f args)) (${op}))
```

# FABULOUS_BUILDER_CONTROL_BUILD(kind) #
```F#
override __.Build (builder : AttributesBuilder) =
    ViewElement.Create<${kind}>
        (${kind}ViewBuilder.CreateFunc, ${kind}ViewBuilder.UpdateFunc, builder)
```

# FABULOUS_CONTROL_BINDING_PROPERTY(type, valueType, key, defaultValue) #
```F#
static member ${key}Property =
    BindableProperty.Create ("${key}", typeof<${valueType}>, typeof<${type}>, ${defaultValue})
```

# FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(type, valueType, key) #
```F#
member this.${key}
    with get () : ${valueType} =
        this.GetValue (${type}.${key}Property) :?> ${valueType}
    and set (value : ${valueType}) =
        this.SetValue (${type}.${key}Property, value :> obj)
```

# FABULOUS_CONTROL_VIEW_ATTRIB_KEY(type, valueType, key) #
```F#
static member ${key}AttribKey = AttributeKey<${valueType}> "${type}_${key}"
```

# FABULOUS_CONTROL_VIEW_BUILDER_HEAD(type, baseType) #
```F#
static member val CreateFunc : (unit -> ${type}) =
    (fun () -> ${type}ViewBuilder.Create()) with get, set
static member Create () : ${type} = new ${type}()
static member val UpdateFunc =
    (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: ${type}) ->
        ${type}ViewBuilder.Update (prevOpt, curr, target))
static member Update (prevOpt: ViewElement voption, curr: ViewElement, target: ${type}) =
    // update the inherited Cell element
    let baseElement =
        if ViewProto.Proto${baseType}.IsNone then
            ViewProto.Proto${baseType} <- Some (ViewBuilders.Construct${baseType}())
        ViewProto.Proto${baseType}.Value
    baseElement.UpdateInherited (prevOpt, curr, target)
```

# FABULOUS_CONTROL_VIEW_BUILDER_VAR(type, valueType, key) #
```F#
let mutable prev${key}Opt : ${valueType} voption = ValueNone
let mutable curr${key}Opt : ${valueType} voption = ValueNone
```

# FABULOUS_CONTROL_VIEW_BUILDER_CURR_HEAD(type) #
```F#
for kvp in curr.AttributesKeyed do
```

# FABULOUS_CONTROL_VIEW_BUILDER_CURR_SET(type, valueType, key) #
```F#
    if kvp.Key = ${type}.${key}AttribKey.KeyValue then
        curr${key}Opt <- ValueSome (kvp.Value :?> ${valueType})
```

# FABULOUS_CONTROL_VIEW_BUILDER_PREV_HEAD(type) #
```F#
match prevOpt with
| ValueNone -> ()
| ValueSome prev ->
    for kvp in prev.AttributesKeyed do
```

# FABULOUS_CONTROL_VIEW_BUILDER_PREV_SET(type, valueType, key) #
```F#
        if kvp.Key = ${type}.${key}AttribKey.KeyValue then
            prev${key}Opt <- ValueSome (kvp.Value :?> ${valueType})
```

# FABULOUS_CONTROL_VIEW_BUILDER_UPDATE(type, valueType, key) #
```F#
match prev${key}Opt, curr${key}Opt with
| ValueNone, ValueNone -> ()
| ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
| _, ValueSome currValue ->
    (* Update ${key} : ${valueType} *)
```

# FABULOUS_CONTROL_VIEW_BUILDER_RESET(type, valueType, key) #
```F#
| ValueSome _, ValueNone ->
    (* Reset ${key} : ${valueType} *)
```

# FABULOUS_CONTROL_VIEW_BUILDER_PROPERTY(type, valueType, key, defaultValue) #
```F#
//SILP: FABULOUS_CONTROL_VIEW_BUILDER_UPDATE(${type}, ${valueType}, ${key})
    target.${key} <- currValue
//SILP: FABULOUS_CONTROL_VIEW_BUILDER_RESET(${type}, ${valueType}, ${key})
    target.${key} <- ${defaultValue}
```

# FABULOUS_CONTROL_VIEW_BUILDER_EVENT(type, valueType, key) #
```F#
match prev${key}Opt, curr${key}Opt with
| ValueNone, ValueNone -> ()
| ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
| ValueSome prevValue, ValueNone ->
    target.${key}.RemoveHandler prevValue
| ValueNone, ValueSome currValue ->
    target.${key}.AddHandler currValue
| ValueSome prevValue, ValueSome currValue ->
    target.${key}.RemoveHandler prevValue
    target.${key}.AddHandler currValue
```