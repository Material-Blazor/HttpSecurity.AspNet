namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowTopNavigationAccessByUserActivation()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowTopNavigationAccessByUserActivationAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-top-navigation-by-user-activation'";
}
