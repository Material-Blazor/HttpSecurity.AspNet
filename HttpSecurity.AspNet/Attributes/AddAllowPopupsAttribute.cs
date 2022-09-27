namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowPopupsLock()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowPopupsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-popups'";
}
