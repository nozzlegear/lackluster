namespace Lackluster.Commands

open System
open Newtonsoft.Json
open Lackluster.Electron

type WindowConfig = {
    html: string
    title: string
    height: int
    width: int
    openDevTools: bool
}

type MessageData =
    | DataString of String
    | Window of WindowConfig

type MessageToNode (id, messageType, data) =
    [<JsonConstructor>]
    new ((data: MessageData), (id: Guid), (messageType: ToNodeType)) = MessageToNode (id, messageType, data)
    new (messageType, data) = MessageToNode (Guid.NewGuid(), messageType, data)
    member x.id: Guid = id
    member x.messageType: ToNodeType = messageType
    member x.data: MessageData = data

type MessageFromNode = {
    messageType: FromNodeType
    data: MessageData
}