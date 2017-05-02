using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ComponentHelper]
    public class Meta : Element<Meta>
    {
        public override string TagName => "meta";

        private string Name { get; set; }

        private string Content { get; set; }

        public Meta(string name, string content)
        {
            Name = name;
            Content = content;
        }
        
        public override Task<string> RenderToStaticMarkup()
        {
            ElementAttributes.ChainSet("name", Name).ChainSet("content", Content);

            // Self closing elements never have children, so we won't iterate over them.
            string tag = FormatTagNameWithAttributes(true);

            return Task.FromResult(tag);
        }
    }
}