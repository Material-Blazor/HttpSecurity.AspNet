using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContentSecurityPolicy.AspNetCore;


/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
public class ContentSecurityPolicyService
{
    private readonly ILogger logger;
    private readonly IOptions<ContentSecurityPolicyOptions> options;


    /// <inheritdoc/>
    public ContentSecurityPolicyService(ILogger<ContentSecurityPolicyService> logger, IOptions<ContentSecurityPolicyOptions> options)
    {
        this.logger = logger;
        this.options = options;
    }


    /// <summary>
    /// Returns the content security policy string.
    /// </summary>
    public string GetContentSecurityPolicy()
    {
        return options.Value.GetContentSecurityPolicy();
    }
}
