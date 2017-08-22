namespace Lackluster.Commands
module Handlers =
    open Lackluster.Logger
    open Lackluster.Electron

    let handleLogCommand data =
        log data

        None

    let handleLogCommandWithUnknownDataType data =
        log
        <| sprintf "Received Log command with invalid data type %s" (data.GetType().FullName)

        None

    let handleUnknownCommand commandType =
        let message = sprintf "Unsupported command type %A" commandType

        logError message
        failwith message

        None

    let handle (message: MessageFromNode): MessageToNode option =
        match (message.messageType, message.data) with
        | (Log, DataString s) -> handleLogCommand s
        | (Log, x) -> handleLogCommandWithUnknownDataType x
        | (commandType, _) -> handleUnknownCommand commandType
