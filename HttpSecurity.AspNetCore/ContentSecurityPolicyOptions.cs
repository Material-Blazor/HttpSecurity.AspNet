namespace HttpSecurity.AspNetCore;


/// <summary>
/// Options for content security policy.
/// </summary>
public sealed partial class ContentSecurityPolicyOptions
{
    private List<ContentSecurityPolicyBase> Policies { get; set; } = new();


    private string PolicyString { get; set; } = string.Empty;


    /// <summary>
    /// Returns the content security policy string.
    /// </summary>
    internal string GetContentSecurityPolicy(string baseUri, string baseDomain)
    {
        if (string.IsNullOrWhiteSpace(PolicyString))
        {
            PolicyString = string.Join(' ', Policies.Select(x => x.GetPolicyValue(baseUri, baseDomain)).OrderBy(x => x));
        }

        return PolicyString;
    }
}
