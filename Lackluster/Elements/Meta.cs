using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Meta : Element<Meta>
    {
        public override string TagName => "meta";

        [Helper]
        public Meta(string name, string content)
        {
            ElementAttributes.ChainSet("name", name).ChainSet("content", content);
        }
        
        public override Task<string> RenderToStaticMarkup()
        {
            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}