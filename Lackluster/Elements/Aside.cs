using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Aside : Element<Aside>
    {
        public override string TagName => "aside";

        public Aside(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Aside(params BaseObject[] children) : base(null, null, null, children) { }
    }
}