using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Blockquote : Element<Blockquote>
    {
        public override string TagName => "blockquote";

        public Blockquote(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Blockquote(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public Blockquote(string text) : base(null, null, null, new Text(text)) { }
    }
}