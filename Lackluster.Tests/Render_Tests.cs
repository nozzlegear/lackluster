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
            string expected = "<html test=\"test value\" id=\"My-Html-Document\" class=\"html-1 html-2 test-class\"><head><link rel=\"stylesheet\" href=\"https://nozzlegear.com/css/theme.css\"/><meta name=\"robots\" content=\"index,follow\"/></head><body data-test=\"test value\" id=\"document-body\"><section class=\"test\"><div><p>I&#39;m a paragraph.</p><p><a href=\"https://google.com\">Link to Google</a></p></div><div><p>&lt;a href=&quot;test&quot;&gt;HTML text is escaped.&lt;/a&gt;</p></div><div><div><p>Hello world! It&#39;s your boy the ChildComponent.</p></div><p>I&#39;m another paragraph!</p></div></section><article class=\"main-article\"><h1>My Sacrifice</h1><h3>By Nickelback</h3><p>Hello my friend we meet again; It&#39;s been a while, where should we begin; Feels like forever</p><p>Within my heart are memories; Of perfect love that you gave to me; Oh, I remember</p></article></body></html>";

            Assert.Equal(expected, html);
        }
    }
}
