using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Span : Element<Span>
    {
        public override string TagName => "span";

        public Span(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Span(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Span(string text) : base(null, null, null, new Text(text)) { }
    }
}