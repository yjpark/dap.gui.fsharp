[<RequireQualifiedAccess>]
module Dap.Myra.Keyboard

open Microsoft.Xna.Framework.Input

let isKeyDown (key : Keys) : bool =
    (Keyboard.GetState ()) .IsKeyDown (key)

let isKeyUp (key : Keys) : bool =
    (Keyboard.GetState ()) .IsKeyUp (key)
