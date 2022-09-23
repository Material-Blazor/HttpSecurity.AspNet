namespace HttpSecurity.AspNetCore;


/// <summary>
/// Creates standard policy option properties and functions.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class PolicyAttribute : Attribute
{
    /// <summary>
    /// The name of the policy
    /// </summary>
    public readonly string PolicyName;


    public PolicyAttribute(string policyName)
    { 
        PolicyName = policyName;
    }
}
