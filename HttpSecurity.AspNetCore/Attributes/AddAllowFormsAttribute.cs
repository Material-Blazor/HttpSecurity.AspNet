namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Creates an <c>AddAllowForms()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowFormsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-forms'";
}
