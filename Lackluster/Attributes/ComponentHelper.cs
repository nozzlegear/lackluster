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

        public Type TargetType { get; }

        public ComponentHelper(Type targetType, string methodName = null, bool hasTextChild = false)
        {
            MethodName = methodName;
            HasTextChild = hasTextChild;
            TargetType = targetType;
        }
    }
}