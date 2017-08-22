import * as cp from 'child_process';
import * as electron from 'electron';
import * as os from 'os';
import * as WebSocket from 'ws';
import { v4 as guid } from 'node-uuid';

interface WindowConfig {
    html: string;
    title: string;
    height: number;
    width: number;
    openDevTools: boolean;
}

type DataWindowConfig = {
    Case: "Window"
    Fields: WindowConfig[]
}

type DataStringConfig = {
    Case: "Data";
    Fields: string[]
}

type InteropDataType = DataStringConfig | DataWindowConfig

interface InteropCommand {
    id: string;
    commandType: {
        Case: "Log" | "Render" | "CreateWindow" | "CloseWindow"
    }
    data: InteropDataType
}

function isWindowData(data: InteropDataType): data is DataWindowConfig {
    return data.Case === "Window"
}

function isStringData(data: InteropDataType): data is DataStringConfig {
    return data.Case === "Data"
}

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let windows: { [id: string]: Electron.BrowserWindow } = {}

function createWindow(command: InteropCommand) {
    const configData = command.data;

    if (!isWindowData(configData) || configData.Fields.length === 0) {
        throw new Error(`Could not create window with command data type "${configData.Case}".`)
    }

    const config = configData.Fields[0];

    // Create the browser window.
    const win = new electron.BrowserWindow({
        width: config.width,
        height: config.height,
        title: config.title,
    })

    // Load raw html
    win.webContents.loadURL("data:text/html," + config.html)

    if (config.openDevTools) {
        win.webContents.openDevTools()
    }

    win.showInactive()

    // Emitted when the window is closed.
    win.on('closed', () => {
        delete windows[command.id]
    })

    windows[command.id] = win
}

function closeWindow(command: InteropCommand) {
    const configData = command.data;

    if (!isStringData(configData) || configData.Fields.length === 0) {
        throw new Error(`Could not close window with command data type "${configData.Case}".`)
    }

    const win = windows[configData.Fields[0]];

    win.close()
}

function electronReady() {
    function handleCommand(command: InteropCommand) {
        if (!isCommand(command)) {
            console.error("Command is invalid.");

            return;
        }

        switch (command.commandType.Case) {
            case "Log":
                console.log("Received log command:", command.data.Fields[0])
                break;

            case "CreateWindow":
                createWindow(command)
                break;

            case "CloseWindow":
                closeWindow(command)
                break;

            case "Render":
                console.log("Received a render command. React data is:", command.data)
                break;

            default:
                console.error(`Received unknown command ${command.commandType.Case} with data:`, command.data)
                break;
        }
    }

    function sendCommand(command: InteropCommand) {
        electronSocket.send(JSON.stringify(command))
    }

    const electronSocket = new WebSocket("ws://127.0.0.1:12345/electron")
    electronSocket.on("open", () => {
        console.log("/electron websocket opened")

        // Lackluster is waiting for a ping to determine when Electron is ready to start.
        electronSocket.ping()

        sendCommand({
            id: guid(),
            commandType: {
                Case: "Log"
            },
            data: {
                Case: "Data",
                Fields: ["Hello world, this was a log command sent from Electron after websocket connection was established."]
            }
        })
    })
    electronSocket.on("message", data => {
        let command: InteropCommand;

        try {
            command = JSON.parse(data.toString())
        } catch (e) {
            console.error("Failed to parse data to JSON.", e)

            return;
        }

        // TODO: If the message contains a response to one sent by Node to Lackluster, find its
        // handler and call it.

        handleCommand(command)
    })

}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
electron.app.on('ready', electronReady)

// Quit when all windows are closed.
electron.app.on('window-all-closed', () => {
    // On macOS it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if (process.platform !== 'darwin') {
        electron.app.quit()
    }
})

function isCommand(obj: InteropCommand): obj is InteropCommand {
    return obj && obj.commandType && !!obj.commandType.Case
}