using System.Threading.Tasks;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Text : Element
    {
        public override string TagName => "";
        
        private string TextValue { get; set; }

        public Text(string text)
        {
            TextValue = text;
        }

        public override Task<string> RenderToStaticMarkup()
        {
            return Task.FromResult(EscapeString(TextValue));
        }
    }
}