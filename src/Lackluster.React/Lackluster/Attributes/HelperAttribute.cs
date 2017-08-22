using System;
using Lackluster.Infrastructure;

namespace Lackluster.Attributes
{
    /// <summary>
    /// Indicates that the decorated constructor should be used to autogenerate helper functions in the abstract <see cref="Lackluster.Infrastructure.Component" /> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class HelperAttribute : System.Attribute
    {
        public HelperAttribute()
        {
            
        }
    }
}