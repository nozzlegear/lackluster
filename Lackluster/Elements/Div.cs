using System.Collections.Generic;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Div : Element
    {
        public override string TagName => "div";

        public Div(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }
}