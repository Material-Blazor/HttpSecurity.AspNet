namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Options for content security policy.
/// </summary>
public sealed partial class ContentSecurityPolicyOptions
{
    private List<PolicyBase> Policies { get; set; } = new();


    private string PolicyString { get; set; } = string.Empty;


    /// <summary>
    /// Returns the content security policy string.
    /// </summary>
    internal string GetContentSecurityPolicy()
    {
        if (string.IsNullOrWhiteSpace(PolicyString))
        {
            PolicyString = string.Join(' ', Policies.OrderBy(x => x).Select(x => x.GetPolicyValue()));
        }

        return PolicyString;
    }
}
