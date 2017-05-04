using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Dl")]
    public class DictionaryList : Element<DictionaryList>
    {
        public override string TagName => "dl";

        public DictionaryList(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public DictionaryList(params BaseObject[] children) : base(null, null, null, children) { }
    }
}