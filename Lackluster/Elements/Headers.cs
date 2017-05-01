using System.Collections.Generic;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class H1 : Element
    {
        public override string TagName => "h1";

        public H1(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }

    public class H2 : Element
    {
        public override string TagName => "h2";

        public H2(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }

    public class H3 : Element
    {
        public override string TagName => "h3";

        public H3(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }

    public class H4 : Element
    {
        public override string TagName => "h4";

        public H4(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }

    public class H5 : Element
    {
        public override string TagName => "h5";

        public H5(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }

    public class H6 : Element
    {
        public override string TagName => "h6";

        public H6(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }
    }
}