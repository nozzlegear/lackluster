using System.Collections.Generic;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Head : Element<Head>
    {
        public override string TagName => "head";

        public Head(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }
}