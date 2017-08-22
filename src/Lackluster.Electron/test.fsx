
let mb = MailboxProcessor<string>.Start(fun inbox ->
    let rec messageLoop() = async {
        let! msg = inbox.Receive()

        printfn "Inbox received message %s" msg

        return! messageLoop()
    }

    messageLoop()
)

mb.Post "Hello world"
mb.Post "Hello world #2"

System.Console.ReadKey true