namespace Lackluster.Commands
module Helpers =
    open Newtonsoft.Json

    let toJson command = JsonConvert.SerializeObject command
    let ofJson command = JsonConvert.DeserializeObject<MessageFromNode> command