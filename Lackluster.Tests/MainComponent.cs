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
}