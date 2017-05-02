using System;
using Lackluster.Infrastructure;

namespace Lackluster.Attributes
{
    /// <summary>
    /// An attribute used to autogenerate the helper functions of the abstract <see cref="Lackluster.Infrastructure.Component" /> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentHelper : System.Attribute
    {
        public string MethodName { get; }

        public bool HasTextChild { get; }

        public ComponentHelper(bool hasTextChild = false, string methodName = null)
        {
            MethodName = methodName;
            HasTextChild = hasTextChild;
        }
    }
}