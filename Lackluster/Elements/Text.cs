using System.Threading.Tasks;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ComponentHelper(true)]
    public class Text : Element<Text>
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