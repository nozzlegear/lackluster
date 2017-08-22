using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    /// <summary>
    /// Represents a <base> tag. https://developer.mozilla.org/en-US/docs/Web/HTML/Element/base
    /// </summary>
    public class Base : Element<Base>
    {
        public override string TagName => "base";

        [Helper]
        public Base(string baseUrl) : base(null, null, null, new Text(baseUrl)) { }
    }
}