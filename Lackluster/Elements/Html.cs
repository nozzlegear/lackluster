using System.Collections.Generic;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Html : Element
    {
        public override string TagName => "html";

        public Html(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }
}