using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("A")]
    public class Anchor : Element<Anchor>
    {
        public override string TagName => "a";

        public Anchor(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Anchor(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Anchor(string href, string text)
        {
            Attribute("href", href).Children(new Text(text));
        }
    }
}