namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowSameOrigin()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowSameOriginAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-same-origin'";
}
