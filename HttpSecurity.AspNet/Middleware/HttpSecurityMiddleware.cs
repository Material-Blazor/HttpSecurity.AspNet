using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;

namespace HttpSecurity.AspNet;


/// <summary>
/// Http security middleware.
/// </summary>
public sealed class HttpSecurityMiddleware
{
    private readonly RequestDelegate _next;


    public HttpSecurityMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
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

        foreach (var header in ((HttpSecurityService)service).GetSecurityHeaders(context))
        {
            context.Response.Headers[header.Key] = header.Value;
        }

        var osHeaders = ((HttpSecurityService)service).GetOnStartingSecurityHeaders(context);

        if (osHeaders.Any())
        {
            context.Response.OnStarting(() =>
            {
                foreach (var osh in osHeaders)
                {
                    context.Response.Headers.Append(osh.Key, osh.Value);
                }

                return Task.CompletedTask;
            });
        }

        return _next(context);
    }
}
