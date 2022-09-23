namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowPresentation()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowPresentationAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-presentation'";
}
