namespace Lackluster
module Electron =
    type ToNodeType =
        | Log
        | Render
        | CreateWindow
        | CloseWindow

    type FromNodeType =
        | Log
        | SomethingElse