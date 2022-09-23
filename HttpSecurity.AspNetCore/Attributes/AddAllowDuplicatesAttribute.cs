namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowDuplicates()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowDuplicatesAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-duplicates'";
}
