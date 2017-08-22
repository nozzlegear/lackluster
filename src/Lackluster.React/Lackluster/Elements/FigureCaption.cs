using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    [ElementShortName("Figcaption")]
    public class FigureCaption : Element<FigureCaption>
    {
        public override string TagName => "figcaption";

        public FigureCaption(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public FigureCaption(params BaseObject[] children) : base(null, null, null, children) { }

        [Helper]
        public FigureCaption(string caption) : base(null, null, null, new Text(caption)) { }
    }
}