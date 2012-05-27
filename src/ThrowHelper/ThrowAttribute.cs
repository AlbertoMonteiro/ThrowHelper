using System;

namespace ThrowHelper
{
    /// <summary>
    /// This attribute  will inject behavior to throw exception before method begin to be executed if some argument is null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ThrowAttribute : Attribute { }
}