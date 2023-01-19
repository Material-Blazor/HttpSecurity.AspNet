using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace HttpSecurity.AspNet;


/// <summary>
/// Options for http security.
/// </summary>
public sealed class HttpSecurityOptions
{
    internal readonly List<KeyValuePair<string, Func<IHttpSecurityService, string, string, string, string>>> HeaderBuilders = new();


    /// <summary>
    /// The built content security policy.
    /// </summary>
    internal ContentSecurityPolicyOptions ContentSecurityPolicy { get; set; } = null;


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
        return ContentSecurityPolicy is null ? "" : string.Join(' ', ContentSecurityPolicy.Policies.Select(x => x.GetPolicyValue(httpSecurityService, nonceValue, baseUri, baseDomain)).OrderBy(x => x));
    }


    /// <summary>
    /// Adds a content security policy policy.
    /// </summary>
    /// <param name="configureOptions">Configures the content security policy</param>
    /// <returns></returns>
    public HttpSecurityOptions AddContentSecurityOptions(Action<ContentSecurityPolicyOptions> configureOptions)
    {
        ContentSecurityPolicyOptions options = new();
        
        configureOptions(options);

        HeaderBuilders.Add(new(
            "Content-Security-Policy", 
            (IHttpSecurityService httpSecurityService, string nonceValue, string baseUri, string baseDomain) => string.Join(' ', options.Policies.Select(x => x.GetPolicyValue(httpSecurityService, nonceValue, baseUri, baseDomain)).OrderBy(x => x))));

        return this;
    }


    /// <summary>
    /// Adds an Cache-Control directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddCacheControl(string cacheControl)
    {
        HeaderBuilders.Add(new("Cache-Control", (_, _, _, _) => cacheControl));
        return this;
    }


    /// <summary>
    /// Adds an Expires directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddExpires(string expires)
    {
        HeaderBuilders.Add(new("Expires", (_, _, _, _) => expires));
        return this;
    }


    /// <summary>
    /// Adds an Referrer-Policy directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddReferrerPolicy(ReferrerPolicyDirective referrerPolicyDirective)
    {
        var value = referrerPolicyDirective switch
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

        HeaderBuilders.Add(new("Referrer-Policy", (_, _, _, _) => value));

        return this;
    }


    /// <summary>
    /// Adds an Permissions-Policy directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddPermissionsPolicy(string permissionsPolicy)
    {
        HeaderBuilders.Add(new("Permissions-Policy", (_, _, _, _) => permissionsPolicy));
        return this;
    }


    /// <summary>
    /// Adds an Strict-Transport-Security directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddStrictTransportSecurity(ulong maxAgeExpireTime, bool includeSubDomains = false)
    {
        HeaderBuilders.Add(new("Strict-Transport-Security", (_, _, _, _) => $"max-age={maxAgeExpireTime}{(includeSubDomains ? " includeSubDomains" : "")}"));
        return this;
    }


    /// <summary>
    /// Adds an X-Client-Id directive with the value supplied.
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddXClientId(string clientId)
    {
        HeaderBuilders.Add(new("X-Client-Id", (_, _, _, _) => clientId));
        return this;
    }


    /// <summary>
    /// Adds an X-Content-Type-Options directive of "nosniff".
    /// </summary>
    /// <returns></returns>
    public HttpSecurityOptions AddXContentTypeOptionsNoSniff()
    {
        HeaderBuilders.Add(new("X-Content-Type-Options", (_, _, _, _) => "nosniff"));
        return this;
    }


    /// <summary>
    /// Adds an X-Frame-Options directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddXFrameOptionsDirective(XFrameOptionsDirective xFrameOptionsDirective)
    {
        HeaderBuilders.Add(new("X-Frame-Options", (_, _, _, _) => xFrameOptionsDirective.ToString().ToUpper()));
        return this;
    }


    /// <summary>
    /// Adds an X-Permitted-Cross-Domain-Policies directive.
    /// </summary>
    /// <param name="xFrameOptionsDirective"></param>
    /// <returns></returns>
    public HttpSecurityOptions AddXPermittedCrossDomainPoliciesDirective(XPermittedCrossDomainPoliciesDirective xPermittedCrossDomainPoliciesDirective)
    {
        var value = xPermittedCrossDomainPoliciesDirective switch
        {
            XPermittedCrossDomainPoliciesDirective.All => "all",
            XPermittedCrossDomainPoliciesDirective.ByContentOnly => "by-content-only",
            XPermittedCrossDomainPoliciesDirective.ByFtpOnly => "by-ftp-only",
            XPermittedCrossDomainPoliciesDirective.MasterOnly => "master-only",
            XPermittedCrossDomainPoliciesDirective.None => "none",
            _ => throw new NotImplementedException(),
        };

        HeaderBuilders.Add(new("X-Permitted-Cross-Domain-Policies", (_, _, _, _) => value));
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
        var value = xXssProtectionDirective switch
        {
            XXssProtectionDirective.Zero => "0",
            XXssProtectionDirective.One => "1",
            XXssProtectionDirective.OneModeBlock => "1; mode=block",
            XXssProtectionDirective.OneReportWithUri => $"1; report={reportingUri}",
            _ => throw new NotImplementedException(),
        };

        HeaderBuilders.Add(new("X-XSS-Protection", (_, _, _, _) => value));
        return this;
    }


    internal List<KeyValuePair<string, string>> GetHeaders(IHttpSecurityService httpSecurityService, string nonceValue, string baseUri, string baseDomain)
    {
        return HeaderBuilders.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Invoke(httpSecurityService, nonceValue, baseUri, baseDomain))).ToList();
    }
}
