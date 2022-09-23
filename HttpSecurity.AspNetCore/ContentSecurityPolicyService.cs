using Microsoft.Extensions.Logging;

namespace HttpSecurity.AspNetCore;


/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
public class ContentSecurityPolicyService
{
    private readonly ContentSecurityPolicyOptions _options;


    /// <inheritdoc/>
    public ContentSecurityPolicyService(ContentSecurityPolicyOptions options)
    {
        _options = options;
    }


    /// <summary>
    /// Returns the content security policy string.
    /// </summary>
    public string GetContentSecurityPolicy(string baseUri, string baseDomain)
    {
        return _options.GetContentSecurityPolicy(baseUri, baseDomain);
    }
}
