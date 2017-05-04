using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Address : Element<Address>
    {
        public override string TagName => "address";

        public Address(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Address(params BaseObject[] children) : base(null, null, null, children) { }
    }
}