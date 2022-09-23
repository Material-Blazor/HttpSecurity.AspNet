namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowPopupsToEscapeSandboxLock()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowPopupsToEscapeSandboxAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-popups-to-escape-sandbox'";
}
