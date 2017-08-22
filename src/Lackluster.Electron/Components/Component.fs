namespace Lackluster.Components

[<AbstractClass>]
type Component () =
    abstract member Render: unit -> string
    abstract member ComponentDidMount: unit -> string