using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HttpSecurity.AspNetCore;


/// <summary>
/// Http security middleware.
/// </summary>
public class HttpSecurityMiddleware
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
    public async Task Invoke(HttpContext context, HttpSecurityService service)
    {
        await _next(context);

        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;
        
        foreach (var header in service.GetSecurityHeaders(baseUri, baseDomain))
        {
            context.Response.Headers[header.Key] = header.Value;
        }
    }
}
