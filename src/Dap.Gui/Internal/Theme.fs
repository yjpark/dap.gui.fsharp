[<AutoOpen>]
module Dap.Gui.Internal.Theme

open System

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Gui

let private typeIPrefab = typeof<IPrefab>

let private isPrefabInterface (type' : Type) =
    if type' = typeIPrefab then
        false
    else
        typeIPrefab.IsAssignableFrom (type')

let private getWidgetClasses (type' : Type) =
    let mutable result = []
    let mutable t = type'
    while t <> null do
        result <- t :: result
        t <- t.BaseType
    result

type StyleFactory = IPrefab -> IStyle

type internal Theme (logging : ILogging, key : string, param : obj) =
    inherit EmptyContext (logging, GuiThemeKind)
    let mutable styles : Map<string, StyleFactory list> = Map.empty
    let mutable decorators : Map<string, IDecorator list> = Map.empty
    member __.Styles = styles
    member __.Decorators = decorators

    member private this.CreateStyles' (logMissing : bool) (prefab : IPrefab) (kind : string) : IStyle list =
        match Map.tryFind kind styles with
        | Some factories ->
            factories
            |> List.rev
            |> List.map (fun factory ->
                let style = factory prefab
                logWarn this "Style_Created" kind (prefab, style)
                style
            )
        | None ->
            if logMissing then
                logWarn this "Style_Not_Registered" kind (prefab)
            []

    member private this.GetDecorators' (logMissing : bool) (kind : string) : IDecorator list =
        Map.tryFind kind decorators
        |> Option.defaultWith (fun () ->
            if logMissing then
                logWarn this "Decorator_Not_Registered" kind ()
            []
        )

    member private this.GetDecorators (widget : obj) (kinds : string list) : IDecorator list =
        let classDecorators =
            widget.GetType ()
            |> getWidgetClasses
            |> List.map (fun type' ->
                this.GetDecorators' false type'.FullName
            )
        let kindDecorators =
            kinds
            |> List.map (fun kind ->
                this.GetDecorators' true kind
            )
        classDecorators @ kindDecorators
        |> List.concat

    (*
     * Note: Not have 'style :> IStyle<'prefab> on purpose
     * so IStyle<IPrefab> can be apply to any 'prefab :> IPrefab
     *)
    member private this.RegisterStyle<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle>
            (allowMultiple : bool) (clearExists : bool) (kind : string) (param : obj list) : unit =
        let factory = fun (prefab : IPrefab) ->
            match prefab with
            | :? 'prefab ->
                Activator.CreateInstance (typeof<'style>, List.toArray ((kind :> obj) :: (prefab :> obj) :: param))
                :?> IStyle
            | _ ->
                logWarn prefab "Theme.RegisterStyle" "Type_Mismatched"
                    (typeof<'style>.FullName, typeof<'prefab>.FullName, prefab.GetType().FullName)
                new InvalidStyle (kind, prefab) :> IStyle
        match Map.tryFind kind styles with
        | None ->
            logInfo this "Style_Registered" kind factory
            styles <- styles |> Map.add kind [ factory ]
        | Some factories ->
            if clearExists then
                logWarn this "Style_Overridden" kind (factories, factory)
                styles <- styles |> Map.add kind [ factory ]
            else
                if allowMultiple  then
                    logInfo this "Style_Registered" kind factory
                    styles <- styles |> Map.add kind (factory :: factories)
                else
                    logError this "Style_Not_Allow_Multiple" kind (factories, factory)


    member private this.RegisterDecorator
            (allowMultiple : bool) (clearExists : bool) (kind : string) (decorator : IDecorator) : unit =
        decorator.Setup' kind
        match Map.tryFind kind decorators with
        | None ->
            logInfo this "Decorator_Registered" kind decorator
            decorators <- decorators |> Map.add kind [ decorator ]
        | Some decorators' ->
            if clearExists then
                logWarn this "Decorator_Overridden" kind (decorators', decorator)
                decorators <- decorators |> Map.add kind [ decorator ]
            else
                if allowMultiple  then
                    logInfo this "Decorator_Registered" kind decorator
                    decorators <- decorators |> Map.add kind (decorator :: decorators')
                else
                    logError this "Decorator_Not_Allow_Multiple" kind (decorators, decorator)
    interface ITheme with
        member __.Key = key
        member __.Param0 = param

        member this.CreateStyles (prefab : IPrefab) (kind : string) : IStyle list =
            this.CreateStyles' true prefab kind

        member this.InitStyles (prefab : IPrefab) : IStyle list =
            //TODO: Also check parent and key for more complex rules
            let type' = prefab.GetType ()
            type'.GetInterfaces ()
            |> Array.toList
            |> List.filter isPrefabInterface
            |> List.map (fun type' ->
                this.CreateStyles' false prefab type'.FullName
            )|> List.concat

        member this.DecorateWidget (widget : obj, kinds : string list) : unit =
            kinds
            |> this.GetDecorators widget
            |> List.iter (fun decorator ->
                try
                    decorator.Decorate0 widget
                with e ->
                    logException this "DecorateWidget" "Exception_Raised" (decorator.Kind, decorator) e
            )

        member this.AddStyle<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
            this.RegisterStyle<'prefab, 'style> true false kind param

        member this.AddNewStyle<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
            this.RegisterStyle<'prefab, 'style> false false kind param

        member this.AddForceStyle<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (kind : string) (param : obj list) : unit =
            this.RegisterStyle<'prefab, 'style> false true kind param

        member this.AddClassStyle<'prefab, 'style when 'prefab :> IPrefab and 'style :> IStyle> (param : obj list) : unit =
            if not typeof<'prefab>.IsInterface then
                failWith "Must_Be_Interface" (typeof<'prefab>.FullName)
            this.RegisterStyle<'prefab, 'style> true false (typeof<'prefab>.FullName) param
        member this.AddDecorator (kind : string) (decorator : IDecorator) : unit =
            this.RegisterDecorator true false kind decorator

        member this.AddNewDecorator (kind : string) (decorator : IDecorator) : unit =
            this.RegisterDecorator false false kind decorator

        member this.AddForceDecorator (kind : string) (decorator : IDecorator) : unit =
            this.RegisterDecorator false true kind decorator

        member this.AddClassDecorator<'widget> (decorator : IDecorator<'widget>) : unit =
            if typeof<'widget>.IsInterface then
                failWith "Must_Not_Be_Interface" (typeof<'widget>.FullName)
            this.RegisterDecorator true false (typeof<'widget>.FullName) decorator
