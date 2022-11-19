[<AutoOpen>]
module Dap.Gui.Helper

open System.IO
open System.Text
open System.Reflection
open System.Threading
open System.Threading.Tasks

open Dap.Prelude
open Dap.Context
open Dap.Platform
open Dap.Local
open Dap.Gui.Internal

// List of supported language and region codes
// https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c

let private decodeLocaleFromStream<'param> (decoder : JsonDecoder<'param>) (stream : Stream) =
    use reader = new StreamReader (stream, Encoding.UTF8)
    reader.ReadToEnd ()
    |> decodeJson decoder

type IGuiApp with
    static member HasInstance = GuiApp.HasInstance
    static member Instance = GuiApp.Instance :> IGuiApp
    member this.AddDefaultLocale<'param> (param : 'param) =
        this.AddLocale<'param> NoKey param
    member this.LoadLocalesFromEmbeddedResource<'param> (prefix : string, decoder : JsonDecoder<'param>, ?assembly : Assembly) =
        let assembly = assembly |> Option.defaultValue (Assembly.GetCallingAssembly ())
        EmbeddedResource.DecodeMultiple<'param> (prefix, decoder, logger = this, assembly = assembly)
        |> Array.iter (fun (key, param) ->
            let key = key.Replace (".json", "")
            this.AddLocale<'param> key param
        )
    member this.SwitchLanguage (language : string) =
        if Map.containsKey language this.Locales then
            this.SwitchLocale language
        else
            this.SwitchLocale NoKey
    member this.SwitchRegion (language : string, region : string) =
        let key = sprintf "%s-%s" language region
        if Map.containsKey key this.Locales then
            this.SwitchLocale key
        else
            this.SwitchLanguage language

type ILocale with
    member this.TextForSwitch =
        let nativeName = Locale.getNativeName this.Culture
        let englishName = this.Culture.EnglishName
        let detail = if nativeName = englishName then "" else englishName
        nativeName, detail, Locale.getSwitchText this.Culture

type IRunner<'runner when 'runner :> IRunner> with
    member this.RunGuiFunc (func : Func<'runner, unit>) : unit =
        runGuiFunc (fun () -> func this.Runner)

type IRunner with
    member this.RunGuiFunc0 (func : Func<IRunner, unit>) : unit =
        runGuiFunc (fun () -> func this)

type IRunner with
    member this.SetGuiValue (setter : 'v -> unit, v : 'v) =
        runGuiFunc (fun () -> setter v)
    member this.SetGuiValue (prop : IVarProperty<'v>, v : 'v) =
        this.SetGuiValue (prop.SetValue, v)

type IAsyncHandler<'req, 'res>  with
    member this.SetupGuiHandler' (handler' : 'req -> Task<'res>) =
        fun (req : 'req) ->
            getGuiTask (fun () -> handler' req)
        |> this.SetupHandler'
    member this.SetupGuiHandler (handler : 'req -> Task<'res>) =
        this.SetupGuiHandler' handler
        this.Seal ()

type IRunner<'runner when 'runner :> IRunner> with
    member this.GetGuiTask (getTask : GetTask<'runner, 'res>) : Task<'res> =
        getGuiTask (fun () -> getTask this.Runner)
    member this.RunGuiTask (onFailed : OnFailed<'runner>) (getTask : GetTask<'runner, unit>) : unit =
        this.RunTask onFailed (fun _ -> this.GetGuiTask getTask)

type IRunner with
    member this.GetGuiTask0 (getTask : GetTask<IRunner, 'res>) : Task<'res> =
        getGuiTask (fun () -> getTask this)
    member this.RunGuiTask0 (onFailed : OnFailed<IRunner>) (getTask : GetTask<IRunner, unit>) : unit =
        this.RunTask0 onFailed (fun _ -> this.GetGuiTask0 getTask)

