using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Li")]
    public class ListItem : Element<ListItem>
    {
        public override string TagName => "li";

        public ListItem(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public ListItem(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public ListItem(string text) : base(null, null, null, new Text(text)) { }
    }
}