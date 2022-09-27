namespace HttpSecurity.AspNet;


/// <summary>
/// Creates standard policy option properties and functions.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ContentSecurityPolicyAttribute : Attribute
{
    /// <summary>
    /// The name of the policy
    /// </summary>
    public readonly string PolicyName;


    public ContentSecurityPolicyAttribute(string policyName)
    { 
        PolicyName = policyName;
    }
}
