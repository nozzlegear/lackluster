using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Img")]
    public class Image : Element<Image>
    {
        public override string TagName => "image";

        [Helper]
        public Image(string src, string alt = null)
        {
            ElementAttributes.ChainSet("src", src).ChainSet("alt", alt);   
        }
        
        public override Task<string> RenderToStaticMarkup()
        {
            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}