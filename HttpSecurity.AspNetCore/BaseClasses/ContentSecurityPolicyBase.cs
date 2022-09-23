namespace HttpSecurity.AspNetCore;

/// <summary>
/// Base interface for a policy.
/// </summary>
public abstract class ContentSecurityPolicyBase
{
    /// <summary>
    /// The policy's name.
    /// </summary>
    private protected abstract string PolicyName { get; }


    /// <summary>
    /// Returns the full policy value string.
    /// </summary>
    /// <returns></returns>
    public abstract string GetPolicyValue(string baseUri, string baseDomain);
}
