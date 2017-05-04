using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Figure : Element<Figure>
    {
        public override string TagName => "figure";

        public Figure(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Figure(params BaseObject[] children) : base(null, null, null, children) { }
    }
}