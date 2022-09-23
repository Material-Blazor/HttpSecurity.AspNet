namespace HttpSecurity.AspNetCore;


/// <summary>
/// Options for content security policy.
/// </summary>
public sealed partial class HttpSecurityOptions
{
    private List<ContentSecurityPolicyBase> Policies { get; set; } = new();


    private string PolicyString { get; set; } = string.Empty;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal XFrameOptionsDirectives? XFrameOptionsDirective { get; private set; } = null;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal bool XContentTypeOptionsNoSniff { get; private set; } = false;


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


    /// <summary>
    /// Adds an X-Content-Type-Options directive of "nosniff".
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddXContentTypeOptionsNoSniff()
    {
        XContentTypeOptionsNoSniff = true;
        return this;
    }


    /// <summary>
    /// Adds an X-Frame-Options directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddXFrameOptionsDirective(XFrameOptionsDirectives xFrameOptionsDirective)
    {
        XFrameOptionsDirective = xFrameOptionsDirective;
        return this;
    }
}
