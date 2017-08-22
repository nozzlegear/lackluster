using System.Collections.Generic;
using System.Linq;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Style : Element<Style>
    {
        public override string TagName => "style";

        [Helper]
        public Style(string styleText) : base(null, null, null, new Text(styleText)) { }

        [Helper]
        public Style(params string[] styles) : base(null, null, null, styles.Select(s => new Text(s)).ToArray()) { }
    }
}