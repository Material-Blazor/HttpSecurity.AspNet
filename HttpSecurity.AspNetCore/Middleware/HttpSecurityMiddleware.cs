using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HttpSecurity.AspNetCore.Middleware;


/// <summary>
/// Http security middleware.
/// </summary>
public sealed class HttpSecurityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IOptions<HttpSecurityOptions> _options;


    public HttpSecurityMiddleware(RequestDelegate next, IOptions<HttpSecurityOptions> options)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }


    /// <summary>
    /// Adds security headers and policies to the context response. Place this immediately after <see cref="HttpsPolicyBuilderExtensions.UseHttpsRedirection()"/>
    /// to enable this middleware to over-ride with your values any headers that may have been set by subsequent middleware.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Invoke(HttpContext context, IHttpSecurityService service)
    {
        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;

        foreach (var header in ((HttpSecurityService)service).GetSecurityHeaders(baseUri, baseDomain))
        {
            context.Response.Headers[header.Key] = header.Value;
        }

        return _next(context);
    }
}
