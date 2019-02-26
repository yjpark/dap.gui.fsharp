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

# PREFAB_HEADER(prefab) #
```F#
type ${prefab} (logging : ILogging) =
    inherit BasePrefab<${prefab}, ${prefab}Props, ${prefab}Widget>
        (${prefab}Kind, ${prefab}Props.Create, logging, new ${prefab}Widget ())
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
    do (
        let kind = ${prefab}Kind
        let owner = base.AsOwner
        let model = base.Model
        let widget = base.Widget
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

# CONTAINER_HEADER_MIDDLE(container, widget) #
```F#
//SILP: CONTAINER_HEADER(${container}, ${widget})
    do (
        let kind = ${container}Kind
        let owner = base.AsOwner
        let widget = base.Widget
```

# CONTAINER_FOOTER(container) #
```F#
static member Create l = new ${container} (l)
static member Create () = new ${container} (getLogging ())
override this.Self = this
override __.Spawn l = ${container}.Create l
interface IFallback
```

# GUI_PLATFORM_FOOTER(type, output_type, output_value) #
```F#
interface IGuiPlatform with
    member __.Param0 = param :> obj
    member __.Display = display.Value
    member this.Init param' =
        if param.IsSome then
            failWith "Already_Init" (param, param')
        this.DoInit param'
    member this.Setup presenter' =
        if display.IsSome then
            failWith "Already_Setup" (display, presenter')
        this.DoSetup presenter'
        let display' = new Display<'presenter, ${output_type}> (${output_value})
        display'.SetPresenter presenter'
        display <- Some (display' :> IDisplay)
        display' :> IDisplay<'presenter>
    member this.Run () = this.Run ()
member this.AsGuiPlatform = this :> IGuiPlatform
interface IContext with
    member __.Dispose () = failWith "${type}" "Can_Not_Dispose"
    member __.Spec0 = context.Spec0
    member __.Properties0 = context.Properties0
    member __.Channels = context.Channels
    member __.Handlers = context.Handlers
    member __.AsyncHandlers = context.AsyncHandlers
    member __.Clone0 l = failWith "${type}" "Can_Not_Clone"
interface IOwner with
    member __.Luid = ""
    member __.Disposed = false
interface IJson with
    member __.ToJson () = toJson context
interface ILogger with
    member __.Log evt = context.Log evt
```
