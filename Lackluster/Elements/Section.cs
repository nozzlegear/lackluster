using System.Collections.Generic;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Section : Element
    {
        public override string TagName => "section";

        public Section(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }
}