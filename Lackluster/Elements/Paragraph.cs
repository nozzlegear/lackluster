using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("P")]
    public class Paragraph : Element<Paragraph>
    {
        public override string TagName => "p";

        public Paragraph(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Paragraph(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Paragraph(string text) : base(null, null, null, new Text(text)) { }
    }
}