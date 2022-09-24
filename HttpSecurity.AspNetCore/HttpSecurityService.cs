namespace HttpSecurity.AspNetCore;


/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
internal sealed class HttpSecurityService : IHttpSecurityService
{
    private readonly HttpSecurityOptions _options;

    private string BaseUri { get; set; } = "";
    private string BaseDomain { get; set; } = "";
    private string NonceValue { get; set; }


    /// <inheritdoc/>
    public HttpSecurityService(HttpSecurityOptions options)
    {
        _options = options;
        NonceValue = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }


    /// <inheritdoc/>
    public Dictionary<string, string> GetSecurityHeaders()
    {
        return BuildSecurityHeaders(BaseUri, BaseDomain);
    }


    /// <inheritdoc/>
    public string GetNonce()
    {
        return NonceValue;
    }


    /// <summary>
    /// Returns a dictionary of security headers.
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    internal Dictionary<string, string> GetSecurityHeaders(string baseUri, string baseDomain)
    {
        BaseUri = baseUri;
        BaseDomain = baseDomain;

        return GetSecurityHeaders();
    }


    /// <summary>
    /// Returns a dictionary of security headers.
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    private Dictionary<string, string> BuildSecurityHeaders(string baseUri, string baseDomain)
    {
        Dictionary<string, string> headers = new();

        string csp = _options.GetContentSecurityPolicy(NonceValue, baseUri, baseDomain);

        if (!string.IsNullOrWhiteSpace(csp))
        {
            headers["Content-Security-Policy"] = csp;
        }

        if (!string.IsNullOrWhiteSpace(_options.CacheControl))
        {
            headers["Cache-Control"] = _options.CacheControl;
        }

        if (!string.IsNullOrWhiteSpace(_options.Expires))
        {
            headers["Expires"] = _options.Expires;
        }

        if (_options.ReferrerPolicyDirective is not null)
        {
            headers["Referrer-Policy"] = ((ReferrerPolicyDirective)_options.ReferrerPolicyDirective) switch
            {
                ReferrerPolicyDirective.NoReferrer => "no-referrer",
                ReferrerPolicyDirective.NoReferrerWhenDowngrade => "no-referrer-when-downgrade",
                ReferrerPolicyDirective.Origin => "origin",
                ReferrerPolicyDirective.OriginWhenCrossOrigin => "origin-when-cross-origin",
                ReferrerPolicyDirective.SameOrigin => "same-origin",
                ReferrerPolicyDirective.StrictOrigin => "strict-origin",
                ReferrerPolicyDirective.StrictOriginWhenCrossOrigin => "strict-origin-when-cross-origin",
                ReferrerPolicyDirective.UnsafeUrl => "unsafe-url",
                _ => throw new NotImplementedException(),
            };
        }

        if (_options.StrictTransportSecurityMaxAgeExpireTime > 0)
        {
            headers["Strict-Transport-Security"] = $"max-age={_options.StrictTransportSecurityMaxAgeExpireTime}{(_options.StrictTransportSecurityIncludeSubDomains ? " includeSubDomains" : "")}";
        }

        if (!string.IsNullOrWhiteSpace(_options.PermissionsPolicy))
        {
            headers["Permissions-Policy"] = _options.PermissionsPolicy;
        }

        if (!string.IsNullOrWhiteSpace(_options.XClientId))
        {
            headers["X-Client-Id"] = _options.XClientId;
        }

        if (_options.XContentTypeOptionsNoSniff)
        {
            headers["X-Content-Type-Options"] = "nosniff";
        }

        if (_options.XFrameOptionsDirective is not null)
        {
            headers["X-Frame-Options"] = ((XFrameOptionsDirective)_options.XFrameOptionsDirective).ToString().ToUpper();
        }

        if (_options.XPermittedCrossDomainPoliciesDirective is not null)
        {
            headers["X-Permitted-Cross-Domain-Policies"] = ((XPermittedCrossDomainPoliciesDirective)_options.XPermittedCrossDomainPoliciesDirective) switch
            {
                XPermittedCrossDomainPoliciesDirective.All => "all",
                XPermittedCrossDomainPoliciesDirective.ByContentOnly => "by-content-only",
                XPermittedCrossDomainPoliciesDirective.ByFtpOnly => "by-ftp-only",
                XPermittedCrossDomainPoliciesDirective.MasterOnly => "master-only",
                XPermittedCrossDomainPoliciesDirective.None => "none",
                _ => throw new NotImplementedException(),
            };
        }

        if (_options.XXssProtectionDirective is not null)
        {
            headers["X-XSS-Protection"] = ((XXssProtectionDirective)_options.XXssProtectionDirective) switch
            {
                XXssProtectionDirective.Zero => "0",
                XXssProtectionDirective.One => "1",
                XXssProtectionDirective.OneModeBlock => "1; mode=block",
                XXssProtectionDirective.OneReportWithUri => $"1; report={_options.XXssProtectionReportingUri}",
                _ => throw new NotImplementedException(),
            };
        }

        return headers;
    }
}
