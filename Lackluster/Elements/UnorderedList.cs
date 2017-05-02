using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Ul")]
    public class UnorderedList : Element<UnorderedList>
    {
        public override string TagName => "ul";

        public UnorderedList(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public UnorderedList(params BaseObject[] children) : base(null, null, null, children) { }
    }
}