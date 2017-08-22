using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Small : Element<Small>
    {
        public override string TagName => "small";

        public Small(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        public Small(params BaseObject[] children) : base(null, null, null, children) { }

        public Small(string text) : base(null, null, null, new Text(text)) { }
    }
}