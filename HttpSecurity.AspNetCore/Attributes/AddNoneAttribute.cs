namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Creates an <c>AddNone()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddNoneAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'none'";
}
