using System;
using Lackluster.Infrastructure;

namespace Lackluster.Attributes
{
    /// <summary>
    /// Describes an element's short name (not it's HTML name). Used when autogenerating the helper functions of the abstract <see cref="Lackluster.Infrastructure.Component" /> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ElementShortNameAttribute : System.Attribute
    {
        public string ShortName { get; }

        public ElementShortNameAttribute(string shortName)
        {
            ShortName = shortName;
        }
    }
}