using System.Collections.Generic;
using Lackluster.Attributes;
using Lackluster.Infrastructure;

namespace Lackluster.Elements
{
    public class Title : Element<Title>
    {
        public override string TagName => "title";

        [Helper]
        public Title(string title) : base(null, null, null, new Text(title)) { }
    }
}