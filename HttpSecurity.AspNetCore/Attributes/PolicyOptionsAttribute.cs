namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Creates standard policy option properties and functions.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class PolicyOptionsAttribute : Attribute
{
}
