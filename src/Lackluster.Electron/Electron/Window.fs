namespace Lackluster

open Lackluster.Commands
open Lackluster.Electron

type ElectronWindow (id, mailbox: MailboxProcessor<MessageToNode>) =
    member x.Id: System.Guid = id
    member x.Close() =
        let id = string x.Id
        let msg = MessageToNode (ToNodeType.CloseWindow, (DataString id))

        mailbox.Post msg