namespace Lackluster
module internal Logger =
    open Suave.Logging

    let private logger = Log.create "Lackluster"

    let log message = logger.info (Message.eventX message)

    let logError message = logger.error (Message.eventX message)

    let logVerbose message = logger.verbose (Message.eventX message)