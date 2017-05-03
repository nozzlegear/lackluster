using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Link : Element<Link>
    {
        public override string TagName => "link";

        [Helper]
        public Link(string relType, string href)
        {
            ElementAttributes.ChainSet("rel", relType).ChainAdd("href", href);
        }
        
        public override Task<string> RenderToStaticMarkup()
        {
            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}