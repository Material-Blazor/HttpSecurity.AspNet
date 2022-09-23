namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowTopNavigationToCustomProtocols()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowTopNavigationToCustomProtocolsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-top-navigation-to-custom-protocols'";
}
