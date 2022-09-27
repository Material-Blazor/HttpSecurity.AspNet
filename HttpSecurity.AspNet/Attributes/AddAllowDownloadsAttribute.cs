namespace HttpSecurity.AspNet;


/// <summary>
/// Creates an <c>AddAllowDownloads()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddAllowDownloadsAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'allow-downloads'";
}
