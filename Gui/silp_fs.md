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

# MAC_OPENS #
```F#
open Foundation
open AppKit
//SILP: COMMON_OPENS
```

# GTK_OPENS #
```F#
open Dap.Gui.Gtk
//SILP: COMMON_OPENS
```

# MYRA_OPENS #
```F#
open Dap.Gui.Myra
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

