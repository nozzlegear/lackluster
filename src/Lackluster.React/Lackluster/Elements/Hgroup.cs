using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    /// <summary>
    /// The HTML hgroup element represents a multi-level heading for a section of a document. It groups a set of h1–h6 elements.
    /// </summary>
    public class Hgroup : Element<Hgroup>
    {
        public override string TagName => "hgroup";

        public Hgroup(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        ) : base(id, classNames, attributes, children) { }

        [Helper]
        public Hgroup(params BaseObject[] children) : base(null, null, null, children) { }
    }
}