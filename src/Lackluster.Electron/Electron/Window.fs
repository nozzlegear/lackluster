namespace Lackluster

open Lackluster.Commands

type ElectronWindow (id, mailbox: MailboxProcessor<InteropCommand>) =
    member x.Id: System.Guid = id
    member x.Close() =
        let id = string x.Id
        let command = InteropCommand (CommandType.CloseWindow, (Data id))

        mailbox.Post command