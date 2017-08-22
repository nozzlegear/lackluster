using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Nav : Element<Nav>
    {
        public override string TagName => "nav";

        public Nav(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Nav(params BaseObject[] children) : base(null, null, null, children) { }
    }
}