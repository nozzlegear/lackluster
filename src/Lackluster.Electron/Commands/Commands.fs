namespace Lackluster.Commands

open System
open Newtonsoft.Json

type CommandType =
    | Log
    | Render
    | CreateWindow
    | CloseWindow

type WindowConfig = {
    html: string
    title: string
    height: int
    width: int
    openDevTools: bool
}

type InteropDataType =
    | Data of String
    | Window of WindowConfig

type InteropCommand (id, commandType, data) =
    [<JsonConstructor>]
    new ((data: InteropDataType), (id: Guid), (commandType: CommandType)) = InteropCommand (id, commandType, data)
    new (commandType, data) = InteropCommand (Guid.NewGuid(), commandType, data)
    member x.id: Guid = id
    member x.commandType: CommandType = commandType
    member x.data: InteropDataType = data