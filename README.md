# Lackluster
Lackluster is an experiment in building a React-like HTML renderer in C#. My goal with Lackluster is to replace all HTML files in a simple static website (my blog) with Lackluster components. 

Rather than working with Razor view files, React server-side rendering, or other view engines, I should be able to quickly set up Lackluster components and describe each page's markup with C#.

Like React, Lackluster components are reusable. For example, you could create `Navbar`, `Header` and `Footer` components to reuse throughout your website. 

Right now Lackluster only supports static, server-side rendering. There are no plans (beyond perhaps my own curiousity) to build any sort of serious client-side framework that would interact with Lackluster in the same way that client-side React can interact with server-rendered React.

**This project is a work in progress**.

## Example

Documentation will be expanded on as Lackluster nears completion. For now, here's a quick example of composing a simple web page with Lackluster:

```cs
public class MainComponent : Component
{
    public override async Task<BaseObject> Render()
    {
        return (
            Html()
            .Id("My-Html-Document")
            .ClassNames("html-1", "html-2", "test-class")
            .Attributes(new Dictionary<string, string>() 
            { 
                {"test", "test value"} 
            })
            .Children(
                Head(
                    Link("stylesheet", "https://nozzlegear.com/css/theme.css"),
                    Meta("robots", "index,follow")
                ),
                Body().Id("document-body").Attribute("data-test", "test value").Children(
                    Section().ClassNames("test").Children(
                        Div(
                            P("I'm a paragraph.")
                        ),
                        Div(
                            P("<a href=\"test\">HTML text is escaped.</a>")
                        ),
                        Div(
                            new ChildComponent(),
                            P("I'm another paragraph!")
                        )
                    )
                )
            )
        );
    }
}

public class ChildComponent : Component
{
    public override async Task<BaseObject> Render()
    {
        return (
            Div(
                P(
                    "Hello world! This is the ChildComponent."
                )
            )
        );
    }
}
```

You can then render your `MainComponent` to static HTML:

```cs
MainComponent component = new MainComponent();
string html = await component.RenderToStaticHtml();
```

Which puts out the following HTML (formatted for readability):

```html
<html test="test value" id="My-Html-Document" class="html-1 html-2 test-class">
    <head>
        <link rel="stylesheet" href="https://nozzlegear.com/css/theme.css"/>
        <meta name="robots" content="index,follow"/>
    </head>
    <body data-test="test value" id="document-body">
        <section class="test">
            <div>
                <p>I&#39;m a paragraph.</p>
            </div>
            <div>
                <p>&lt;a href=&quot;test&quot;&gt;HTML text is escaped.&lt;/a&gt</p>
            </div>
            <div>
                <div>
                    <p>Hello world! It&#39;s your boy the ChildComponent.</p>
                </div>
                <p>I&#39;m another paragraph!</p>
            </div>
        </section>
    </body>
</html>
```

#### What's with the name?

The name Lackluster *could* be a cutting quip on the notion that this library could ever be compared to a more full-featured framework like React, Vue or even Razor. But in reality, it doesn't have any significant meaning. 🙃 I just needed something unique and I happen to like the way the word sounds. 