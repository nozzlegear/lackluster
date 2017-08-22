using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Dd")]
    public class DictionaryDefition : Element<DictionaryDefition>
    {
        public override string TagName => "dd";

        public DictionaryDefition(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public DictionaryDefition(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public DictionaryDefition(string text) : base(null, null, null, new Text(text)) { }
    }
}