using Microsoft.AspNetCore.Http;

namespace HttpSecurity.AspNet;


/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
internal sealed class HttpSecurityService : IHttpSecurityService
{
    private readonly HttpSecurityOptions _options;
    private readonly HttpSecurityOptions _onStartingOptions;
    private readonly IServiceProvider _serviceProvider;
    private readonly DefaultStaticFileService _staticFileService;
    private readonly FileHashDataset _fileHashDataset;
    private readonly string _nonceValue;


    /// <inheritdoc/>
    public IGeneratedHashesProvider DefaultGeneratedHashesProvider => _staticFileService;


   /// <inheritdoc/>
    public HttpSecurityService(HttpSecurityOptions options, HttpSecurityOptions onStartingOptions, DefaultStaticFileService staticFileService, IServiceProvider serviceProvider)
    {
        _options = options;
        _onStartingOptions = onStartingOptions;
        _serviceProvider = serviceProvider;
        _staticFileService = staticFileService;

        _fileHashDataset = (options.GeneratedHashesProviderBuilder?.Invoke(_serviceProvider) ?? _staticFileService).GetFileHashDataset(_serviceProvider);
        _nonceValue = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }


    /// <inheritdoc/>
    public List<KeyValuePair<string, string>> GetSecurityHeaders(HttpContext context)
    {
        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;

        return _options.GetHeaders(this, _nonceValue, baseUri, baseDomain);
    }


    /// <inheritdoc/>
    public List<KeyValuePair<string, string>> GetOnStartingSecurityHeaders(HttpContext context)
    {
        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;

        return _onStartingOptions.GetHeaders(this, _nonceValue, baseUri, baseDomain);
    }


    /// <inheritdoc/>
    public string GetNonce()
    {
        return _nonceValue;
    }


    /// <inheritdoc/>
    public string GetFileHashString(string fileName)
    {
        return _fileHashDataset.GetHashString(fileName);
    }


    /// <inheritdoc/>
    string IHttpSecurityService.GetCSPHashesSubsting(StaticFileExtension staticFileExtension)
    {
        return _fileHashDataset.GetCSPSubstring(staticFileExtension);
    }


    /// <summary>
    /// Returns a dictionary of security headers.
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    //private Dictionary<string, string> BuildSecurityHeaders(HttpContext context, string baseUri, string baseDomain)
    //{
    //    Dictionary<string, string> headers = new();

    //    string csp = _options.GetContentSecurityPolicy(this, _nonceValue, baseUri, baseDomain);

    //    if (!string.IsNullOrWhiteSpace(csp))
    //    {
    //        headers["Content-Security-Policy"] = csp;
    //    }

    //    if (!string.IsNullOrWhiteSpace(_options.AccessControlAllowOrigin))
    //    {
    //        headers["Access-Control-Allow-Origin"] = _options.AccessControlAllowOrigin;
    //    }

    //    if (!string.IsNullOrWhiteSpace(_options.CacheControl))
    //    {
    //        headers["Cache-Control"] = _options.CacheControl;
    //    }

    //    if (!string.IsNullOrWhiteSpace(_options.Expires))
    //    {
    //        headers["Expires"] = _options.Expires;
    //    }

    //    if (_options.ReferrerPolicyDirective is not null)
    //    {
    //        headers["Referrer-Policy"] = _options.ReferrerPolicyDirective switch
    //        {
    //            ReferrerPolicyDirective.NoReferrer => "no-referrer",
    //            ReferrerPolicyDirective.NoReferrerWhenDowngrade => "no-referrer-when-downgrade",
    //            ReferrerPolicyDirective.Origin => "origin",
    //            ReferrerPolicyDirective.OriginWhenCrossOrigin => "origin-when-cross-origin",
    //            ReferrerPolicyDirective.SameOrigin => "same-origin",
    //            ReferrerPolicyDirective.StrictOrigin => "strict-origin",
    //            ReferrerPolicyDirective.StrictOriginWhenCrossOrigin => "strict-origin-when-cross-origin",
    //            ReferrerPolicyDirective.UnsafeUrl => "unsafe-url",
    //            _ => throw new NotImplementedException(),
    //        };
    //    }

    //    if (_options.StrictTransportSecurityMaxAgeExpireTime > 0)
    //    {
    //        headers["Strict-Transport-Security"] = $"max-age={_options.StrictTransportSecurityMaxAgeExpireTime}{(_options.StrictTransportSecurityIncludeSubDomains ? " includeSubDomains" : "")}";
    //    }

    //    if (!string.IsNullOrWhiteSpace(_options.PermissionsPolicy))
    //    {
    //        headers["Permissions-Policy"] = _options.PermissionsPolicy;
    //    }

    //    if (!string.IsNullOrWhiteSpace(_options.XClientId))
    //    {
    //        headers["X-Client-Id"] = _options.XClientId;
    //    }

    //    if (_options.XContentTypeOptionsNoSniff)
    //    {
    //        headers["X-Content-Type-Options"] = "nosniff";
    //    }

    //    if (_options.XFrameOptionsDirective is not null)
    //    {
    //        headers["X-Frame-Options"] = ((XFrameOptionsDirective)_options.XFrameOptionsDirective).ToString().ToUpper();
    //    }

    //    if (_options.XPermittedCrossDomainPoliciesDirective is not null)
    //    {
    //        headers["X-Permitted-Cross-Domain-Policies"] = _options.XPermittedCrossDomainPoliciesDirective switch
    //        {
    //            XPermittedCrossDomainPoliciesDirective.All => "all",
    //            XPermittedCrossDomainPoliciesDirective.ByContentOnly => "by-content-only",
    //            XPermittedCrossDomainPoliciesDirective.ByFtpOnly => "by-ftp-only",
    //            XPermittedCrossDomainPoliciesDirective.MasterOnly => "master-only",
    //            XPermittedCrossDomainPoliciesDirective.None => "none",
    //            _ => throw new NotImplementedException(),
    //        };
    //    }

    //    if (_options.XXssProtectionDirective is not null)
    //    {
    //        headers["X-XSS-Protection"] = ((XXssProtectionDirective)_options.XXssProtectionDirective) switch
    //        {
    //            XXssProtectionDirective.Zero => "0",
    //            XXssProtectionDirective.One => "1",
    //            XXssProtectionDirective.OneModeBlock => "1; mode=block",
    //            XXssProtectionDirective.OneReportWithUri => $"1; report={_options.XXssProtectionReportingUri}",
    //            _ => throw new NotImplementedException(),
    //        };
    //    }

    //    return headers;
    //}
}
