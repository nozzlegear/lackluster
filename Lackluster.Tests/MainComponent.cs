using System.Collections.Generic;
using System.Threading.Tasks;
using Lackluster.Infrastructure;

namespace Lackluster.Tests
{
    public class MainComponent : Component
    {
        public override Task<BaseObject> Render()
        {
            return Task.FromResult<BaseObject>(
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
                                P("I'm a paragraph."),
                                P(
                                    A("Link to Google", "https://google.com")
                                )
                            ),
                            Div(
                                P("<a href=\"test\">HTML text is escaped.</a>")
                            ),
                            Div(
                                new ChildComponent(),
                                P("I'm another paragraph!")
                            )
                        ),
                        Article().ClassName("main-article").Children(
                            H1("My Sacrifice"),
                            H3("By Nickelback"),
                            P("Hello my friend we meet again; It's been a while, where should we begin; Feels like forever"),
                            P("Within my heart are memories; Of perfect love that you gave to me; Oh, I remember")
                        )
                    )
                )
            );
        }
    }
}