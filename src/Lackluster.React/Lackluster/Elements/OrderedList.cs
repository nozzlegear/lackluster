using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Ol")]
    public class OrderedList : Element<OrderedList>
    {
        public override string TagName => "ol";

        public OrderedList(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public OrderedList(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public OrderedList(string text) : base(null, null, null, new Text(text)) { }
    }
}