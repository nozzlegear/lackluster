using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Dt")]
    public class DictionaryTerm : Element<DictionaryTerm>
    {
        public override string TagName => "dt";

        public DictionaryTerm(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public DictionaryTerm(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public DictionaryTerm(string text) : base(null, null, null, new Text(text)) { }
    }
}