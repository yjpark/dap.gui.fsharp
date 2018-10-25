module Dap.Forms.Meta

open Microsoft.FSharp.Quotations

open Dap.Prelude
open Dap.Context
open Dap.Context.Meta
open Dap.Context.Meta.Util
open Dap.Platform.Meta

type M with
    static member formsView (packModelMsg : string, args : string, ?kind : Kind, ?key : Key, ?aliases : ModuleAlias list) =
        let kind = defaultArg kind Dap.Forms.View.Types.Kind
        let aliases = defaultArg aliases []
        let alias = "FormsViewTypes", "Dap.Forms.View.Types"
        let args = CodeArgs (sprintf "FormsViewTypes.Args<%s>" packModelMsg) args
        let type' = sprintf "FormsViewTypes.View<%s>" packModelMsg
        let spec = "Dap.Forms.View.Logic.spec"
        M.agent (args, type', spec, kind, ?key = key, aliases = alias :: aliases)
