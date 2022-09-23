using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HttpSecurity.AspNetCore;


/// <summary>
/// Compressed static files middleware.
/// </summary>
public class ContentSecurityPolicyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IOptions<ContentSecurityPolicyOptions> _options;


    public ContentSecurityPolicyMiddleware(
        RequestDelegate next,
        IOptions<ContentSecurityPolicyOptions> options)
    {
        if (next == null)
        {
            throw new ArgumentNullException(nameof(next));
        }

        _next = next;

        _options = options ?? throw new ArgumentNullException(nameof(options));
    }


    /// <summary>
    /// Processes a request to determine if it matches a known file, and if so, serves it. If there is an appropriate
    /// compressed alternative file, it is served instead.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context, ContentSecurityPolicyService service)
    {
        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;
        
        context.Response.Headers.Add("X-Frame-Options", "DENY");
        context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
        context.Response.Headers.Add("X-ClientId", "dioptra");
        context.Response.Headers.Add("Referrer-Policy", "no-referrer");
        context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
        context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");
        context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");

        context.Response.Headers.Add("Content-Security-Policy", service.GetContentSecurityPolicy(baseUri, baseDomain));

        await _next(context);
    }
}
