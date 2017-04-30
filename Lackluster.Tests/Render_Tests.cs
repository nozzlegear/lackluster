using System;
using System.Threading.Tasks;
using Xunit;

namespace Lackluster.Tests
{
    [Trait("Category", "Render")]
    public class Render_Tests
    {
        [Fact]
        public async Task Renders_Components()
        {
            MainComponent component = new MainComponent();
            string html = await component.RenderToStaticMarkup();
            string expected = "<html test=\"test value\" id=\"My-Html-Document\" class=\"html-1 html-2 test-class\"><head><link rel=\"stylesheet\" href=\"https://nozzlegear.com/css/theme.css\"/><meta name=\"robots\" content=\"index,follow\"/></head><body data-test=\"test value\" id=\"document-body\"><section class=\"test\"><div><p>I&#39;m a paragraph.</p></div><div><p>&lt;a href=&quot;test&quot;&gt;HTML text is escaped.&lt;/a&gt;</p></div><div><div><p>Hello world! It&#39;s your boy the ChildComponent.</p></div><p>I&#39;m another paragraph!</p></div></section></body></html>";

            Assert.Equal(expected, html);
        }
    }
}
