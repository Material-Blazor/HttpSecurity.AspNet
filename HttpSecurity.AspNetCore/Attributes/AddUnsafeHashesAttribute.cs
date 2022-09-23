namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Creates an <c>AddUnsafeHashes()</c> generated function.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AddUnsafeHashesAttribute : Attribute
{
    /// <summary>
    /// The policy value.
    /// </summary>
    internal const string PolicyValue = "'unsafe-hashes'";
}
