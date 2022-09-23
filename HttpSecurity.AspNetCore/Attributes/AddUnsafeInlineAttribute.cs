namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddUnsafeInline()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddUnsafeInlineAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'unsafe-inline'";
}
