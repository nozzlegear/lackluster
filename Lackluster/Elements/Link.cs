using System.Threading.Tasks;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Link : Element
    {
        public override string TagName => "link";

        private string RelType { get; set; }

        private string Href { get; set; }

        public Link(string relType, string href)
        {
            RelType = relType;
            Href = href;
        }
        
        public override Task<string> RenderToStaticMarkup()
        {
            ElementAttributes.ChainSet("rel", RelType).ChainSet("href", Href);

            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}