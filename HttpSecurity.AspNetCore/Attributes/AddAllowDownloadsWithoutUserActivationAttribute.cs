namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowDownloadsWithoutUserActivation()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowDownloadsWithoutUserActivationAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-downloads-without-user-activation'";
}
