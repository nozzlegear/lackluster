using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Code : Element<Code>
    {
        public override string TagName => "code";

        public Code(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Code(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Code(string text) : base(null, null, null, new Text(text)) { }
    }
}