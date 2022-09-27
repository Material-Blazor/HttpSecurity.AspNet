namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowTopNavigation()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowTopNavigationAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-top-navigation'";
}
