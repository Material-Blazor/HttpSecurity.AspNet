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
    /// <param name="httpSecurityService"></param>
    /// <param name="nonceValue"></param>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    public abstract string GetPolicyValue(IHttpSecurityService httpSecurityService, string nonceValue, string baseUri, string baseDomain);
}
