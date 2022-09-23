namespace HttpSecurity.AspNetCore;


/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
public class HttpSecurityService
{
    private readonly HttpSecurityOptions _options;


    /// <inheritdoc/>
    public HttpSecurityService(HttpSecurityOptions options)
    {
        _options = options;
    }


    /// <summary>
    /// Returns a sorted list of security headers.
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    public SortedDictionary<string, string> GetSecurityHeaders(string baseUri, string baseDomain)
    {
        SortedDictionary<string, string> headers = new();

        string csp = _options.GetContentSecurityPolicy(baseUri, baseDomain);

        if (!string.IsNullOrWhiteSpace(csp))
        {
            headers["Content-Security-Policy"] = csp;
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
