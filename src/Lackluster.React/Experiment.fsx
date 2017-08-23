open System

type BaseObject() =
    abstract member RenderToHtmlString: unit -> string
    /// <summary>
    /// Renders the component and all child components, then converts them to a static HTML string.
    /// </summary>
    default x.RenderToHtmlString () =
        let componentName = x.GetType().Name
        let ex =
            sprintf "You must override the x.RenderToHtmlString method of your component. Check the implementation of class %s." componentName
            |> NotImplementedException
        raise ex

    abstract member RenderToJsxString: unit -> string
    /// <summary>
    /// Renders the component and all child components, then converts them to a React-compatible JSX string.
    /// </summary>
    default x.RenderToJsxString () =
        let componentName = x.GetType().Name
        let ex =
            sprintf "You must override the x.RenderToJsxString method of your component. Check the implementation of class %s." componentName
            |> NotImplementedException
        raise ex

type Element() =
    inherit BaseObject()
    abstract member TagName: string
    default x.TagName =
        let componentName = x.GetType().Name
        let ex =
            sprintf "You must override the TagName property of your element. Check the implementation of class %s." componentName
            |> NotImplementedException

        raise ex

type Component() =
    inherit BaseObject()

    abstract member Render: unit -> BaseObject
    /// <summary>
    /// Renders the component and all child components.
    /// </summary>
    default x.Render() =
        let componentName = x.GetType().Name
        let ex =
            sprintf "You must override the Render method of your component. Check the implementation of class %s." componentName
            |> NotImplementedException
        raise ex

type h1() =
    inherit Element()
    override x.TagName = "h1"
    override x.RenderToHtmlString() =
        let tag = x.TagName
        sprintf "<%s>H1 was rendered!</%s>" x.TagName x.TagName

    override x.RenderToJsxString() =
        "R.h1('something goes here?')"

type MyComponent() =
    inherit Component()

    override x.Render() =
        h1 () :> BaseObject

type Render =
    | RenderToJsx of (unit -> string)
    | RenderToHtml of (unit -> string)

type ReactElement = Render * Render

let baseElement (tagName: string) (selfClosing: bool) (attributeList: obj list) (children: ReactElement list): ReactElement =
    let toHtml = RenderToHtml (fun _ -> "RenderToHtml is not implemented")
    let toJsx = RenderToJsx (fun _ -> "RenderToJsx is not implemented")

    toHtml, toJsx

let h2 attributes children =
    baseElement "h2" false attributes children

let tag = h1()
let renderedH2 =
    h2 [] [
        h2 [] [
            h2 [] []
        ]
    ]

match renderedH2 with
| (RenderToHtml toHtml, RenderToJsx toJsx) -> toHtml() |> printfn "%s"
| (RenderToJsx toJsx, RenderToHtml toHtml) -> toJsx() |> printfn "%s"
| _ -> failwith "Element or component must return one RenderToJsx function and one RenderToHtml function."

tag.RenderToHtmlString()
    |> printfn "%s"