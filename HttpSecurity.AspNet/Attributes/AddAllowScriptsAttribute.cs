namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowScriptsLock()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowScriptsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-scripts'";
}
