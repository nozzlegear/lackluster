using System.Collections.Generic;
using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Hr")]
    public class HorizontalRule : Element<HorizontalRule>
    {
        public override string TagName => "hr";

        public override Task<string> RenderToStaticMarkup()
        {
            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}