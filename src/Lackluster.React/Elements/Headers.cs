using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class H1 : Element<H1>
    {
        public override string TagName => "h1";

        public H1(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H1(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H1(string text) : base (null, null, null, new Text(text)) { }
    }

    public class H2 : Element<H2>
    {
        public override string TagName => "h2";

        public H2(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H2(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H2(string text) : base (null, null, null, new Text(text)) { }
    }

    public class H3 : Element<H3>
    {
        public override string TagName => "h3";

        public H3(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H3(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H3(string text) : base (null, null, null, new Text(text)) { }
    }

    public class H4 : Element<H4>
    {
        public override string TagName => "h4";

        public H4(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H4(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H4(string text) : base (null, null, null, new Text(text)) { }
    }

    public class H5 : Element<H5>
    {
        public override string TagName => "h5";

        public H5(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H5(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H5(string text) : base (null, null, null, new Text(text)) { }
    }

    public class H6 : Element<H6>
    {
        public override string TagName => "h6";

        public H6(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public H6(params BaseObject[] children) : base (null, null, null, children) { }

        [Helper]
        public H6(string text) : base (null, null, null, new Text(text)) { }
    }
}
