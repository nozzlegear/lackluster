// Learn more about F# at http://fsharp.org
namespace Lackluster
module Electron =

    open Suave
    open Suave.Http
    open Suave.Operators
    open Suave.Filters
    open Suave.Successful
    open Suave.Files
    open Suave.RequestErrors
    open Suave.Logging
    open Suave.Utils
    open Suave.Sockets
    open Suave.Sockets.Control
    open Suave.WebSocket

    open System
    open System.Net
    open System.Threading
    open Newtonsoft.Json

    open Lackluster.Electron
    open Lackluster.Commands
    open Lackluster.Commands.Helpers
    open Lackluster.Commands.Handlers

    let private getString bytes = System.Text.Encoding.UTF8.GetString bytes

    let private getBytes (str: String) = System.Text.Encoding.UTF8.GetBytes str

    let private toResponseBytes data =
        data
        |> toJson
        |> getBytes
        |> ByteSegment

    let socket connectionStatusChanged (webSocket: WebSocket) (context: HttpContext) =
        let toNodeMailbox = MailboxProcessor<MessageToNode>.Start(fun inbox ->
            let rec messageLoop() = async {
                let! msg = inbox.Receive()
                let responseBytes = msg |> toResponseBytes
                let! sendResponse = webSocket.send Text responseBytes true

                match sendResponse with
                | Choice1Of2 x -> Logger.log "Sent message to Electron."
                | Choice2Of2 x -> Logger.logError <| sprintf "Error sending %A message to Electron." msg.messageType

                return! messageLoop()
            }

            messageLoop()
        )

        socket {
            // if `loop` is set to false, the server will stop receiving messages
            let mutable loop = true

            while loop do
                // the server will wait for a message to be received without blocking the thread
                let! msg = webSocket.read()

                // the message has type (Opcode * byte [] * bool)
                // Opcode type:
                //   type Opcode = Continuation | Text | Binary | Reserved | Close | Ping | Pong
                // byte [] contains the actual message
                // the last element is the FIN byte
                match msg with
                | (Text, data, true) ->
                    let message =
                        getString data
                        |> ofJson

                    match handle message with
                    | None -> ()
                    | Some response ->
                        let responseBytes = response |> toResponseBytes

                        do! webSocket.send Text responseBytes true

                    // TODO: Check if the message contained a response to a message sent from Lackluster.
                    // If so, call its event (or whatever method we end up using to do so.)
                | (Close, _, _) ->
                    connectionStatusChanged None

                    let emptyResponse = [||] |> ByteSegment
                    do! webSocket.send Close emptyResponse true

                    // after sending a Close message, stop the loop
                    loop <- false

                | (Ping, _, _) ->
                    do! webSocket.send Pong ([||] |> ByteSegment) true
                    connectionStatusChanged (Some toNodeMailbox)
                | _ -> ()
        }

    let mutable private running = false

    let start cancellationToken = async {
        match running with
        | true -> failwith "Lackluster has already been started."
        | false -> running <- true

        let mutable toNodeMailbox: MailboxProcessor<MessageToNode> option = None
        let serverConfig =
            { defaultConfig with
                bindings = [HttpBinding.createSimple Protocol.HTTP "127.0.0.1" 12345]
            }
        let socketServer = socket (fun mb -> toNodeMailbox <- mb)
        let server : WebPart =
            choose [
                path "/electron" >=> handShake socketServer
                NOT_FOUND "No websocket handlers were found at this path."
            ]

        let listening, server = startWebServerAsync serverConfig server

        Async.Start (server, cancellationToken)

        // Start Electron itself.
        // TODO: Package the Electron program so we can just run a single executable without args
        let startInfo = System.Diagnostics.ProcessStartInfo ("./node_modules/.bin/electron.cmd", "./main.js")
        let electronProcess = System.Diagnostics.Process.Start(startInfo)

        // Don't return until electron has started and connected to lackluster
        while toNodeMailbox.IsNone do
            ()

        let createWindow (windowConfig: WindowConfig) =
            match toNodeMailbox with
            | None -> failwith "Electron websocket is not connected, command cannot be sent."
            | Some mb ->
                let data = Window windowConfig
                let command = MessageToNode (ToNodeType.CreateWindow, data)

                mb.Post command
                ElectronWindow (command.id, mb)

        return createWindow
    }

    [<EntryPoint>]
    let main argv =
        let token = new CancellationTokenSource()
        let createWindow =
            start token.Token
            |> Async.RunSynchronously

        // Load the html from index.html and create a window with it
        let windowConfig =
            {
                html = System.IO.File.ReadAllText "index.html"
                title = "Hello from Lackluster"
                height = 600
                width = 800
                openDevTools = true
            }

        let window = createWindow windowConfig

        Logger.log "Lackluster has been started and the web server is running. Press any key to stop."

        Console.ReadKey true |> ignore

        token.Cancel ()

        0 // return an integer exit code