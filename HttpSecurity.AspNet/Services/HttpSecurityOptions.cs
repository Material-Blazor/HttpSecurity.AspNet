namespace HttpSecurity.AspNet;


/// <summary>
/// Options for http security.
/// </summary>
public sealed partial class HttpSecurityOptions
{
    private List<ContentSecurityPolicyBase> Policies { get; set; } = new();


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal string CacheControl { get; private set; } = string.Empty;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal string Expires { get; private set; } = string.Empty;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal ReferrerPolicyDirective? ReferrerPolicyDirective { get; private set; } = null;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal string PermissionsPolicy { get; private set; } = string.Empty;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal ulong StrictTransportSecurityMaxAgeExpireTime { get; private set; } = 0;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal bool StrictTransportSecurityIncludeSubDomains { get; private set; } = false;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal string XClientId { get; private set; } = string.Empty;


    /// <summary>
    /// The requested directive.
    /// </summary>
    internal bool XContentTypeOptionsNoSniff { get; private set; } = false;


    /// <summary>
    /// The requested X-Frame-Options directive.
    /// </summary>
    internal XFrameOptionsDirective? XFrameOptionsDirective { get; private set; } = null;


    /// <summary>
    /// The requested XPermittedCrossDomainPoliciesDirective directive.
    /// </summary>
    internal XPermittedCrossDomainPoliciesDirective? XPermittedCrossDomainPoliciesDirective { get; private set; } = null;


    /// <summary>
    /// The requested X-XSS-Protection directive.
    /// </summary>
    internal XXssProtectionDirective? XXssProtectionDirective { get; private set; } = null;


    /// <summary>
    /// The requested X-XSS-Protection directive.
    /// </summary>
    internal string XXssProtectionReportingUri { get; private set; } = string.Empty;


    /// <summary>
    /// An optional <see cref="IGeneratedHashesProvider"/> builder. If null, <see cref="IHttpSecurityService.DefaultGeneratedHashesProvider"/>
    /// </summary>
    internal Func<IServiceProvider, IGeneratedHashesProvider>? GeneratedHashesProviderBuilder { get; set; } = null;


    /// <summary>
    /// An optional <see cref="IGeneratedHashesProvider"/>. If null, <see cref="IHttpSecurityService.DefaultGeneratedHashesProvider"/> is used.
    /// </summary>
    public HttpSecurityOptions SetGeneratedHashesProvider(Func<IServiceProvider, IGeneratedHashesProvider> func)
    {
        GeneratedHashesProviderBuilder = func;
        return this;
    }


    /// <summary>
    /// Returns the content security policy string.
    /// </summary>
    internal string GetContentSecurityPolicy(IHttpSecurityService httpSecurityService, string nonceValue, string baseUri, string baseDomain)
    {
        return string.Join(' ', Policies.Select(x => x.GetPolicyValue(httpSecurityService, nonceValue, baseUri, baseDomain)).OrderBy(x => x));
    }


    /// <summary>
    /// Adds an Cache-Control directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddCacheControl(string cacheControl)
    {
        CacheControl = cacheControl;
        return this;
    }


    /// <summary>
    /// Adds an Expires directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddExpires(string expires)
    {
        Expires = expires;
        return this;
    }


    /// <summary>
    /// Adds an Referrer-Policy directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddReferrerPolicy(ReferrerPolicyDirective referrerPolicyDirective)
    {
        ReferrerPolicyDirective = referrerPolicyDirective;
        return this;
    }


    /// <summary>
    /// Adds an Permissions-Policy directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddPermissionsPolicy(string permissionsPolicy)
    {
        PermissionsPolicy = permissionsPolicy;
        return this;
    }


    /// <summary>
    /// Adds an Strict-Transport-Security directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddStrictTransportSecurity(ulong maxAgeExpireTime, bool includeSubDomains = false)
    {
        StrictTransportSecurityMaxAgeExpireTime = maxAgeExpireTime;
        StrictTransportSecurityIncludeSubDomains = includeSubDomains;
        return this;
    }


    /// <summary>
    /// Adds an X-Client-Id directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddXClientId(string clientId)
    {
        XClientId = clientId;
        return this;
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
    public HttpSecurityOptions AddXFrameOptionsDirective(XFrameOptionsDirective xFrameOptionsDirective)
    {
        XFrameOptionsDirective = xFrameOptionsDirective;
        return this;
    }


    /// <summary>
    /// Adds an xPermittedCrossDomainPoliciesDirective directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddXPermittedCrossDomainPoliciesDirective(XPermittedCrossDomainPoliciesDirective xPermittedCrossDomainPoliciesDirective)
    {
        XPermittedCrossDomainPoliciesDirective = xPermittedCrossDomainPoliciesDirective;
        return this;
    }


    /// <summary>
    /// Adds an X-XSS-Protection directive.
    /// </summary>
    /// <param name="xXssProtectionDirective"></param>
    /// <param name="reportingUri">Ignored without <see cref="XXssProtectionDirective.OneReportWithUri"/></param>
    /// <returns></returns>
    public HttpSecurityOptions AddXXssProtectionDirective(XXssProtectionDirective xXssProtectionDirective, string reportingUri = "")
    {
        XXssProtectionDirective = xXssProtectionDirective;
        XXssProtectionReportingUri = reportingUri;
        return this;
    }
}
