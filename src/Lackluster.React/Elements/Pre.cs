using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Pre : Element<Pre>
    {
        public override string TagName => "pre";

        public Pre(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Pre(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Pre(string text) : base(null, null, null, new Text(text)) { }
    }
}