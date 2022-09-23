﻿using Microsoft.AspNetCore.Http;
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
    /// Processes a request to determine if it matches a known file, and if so, serves it. If there is an appropriate
    /// compressed alternative file, it is served instead.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context, HttpSecurityService service)
    {
        var baseUri = context.Request.Host.ToUriComponent();
        var baseDomain = context.Request.Host.Host;
        
        foreach (var header in service.GetSecurityHeaders(baseUri, baseDomain))
        {
            context.Response.Headers.Add(header.Key, header.Value);
        }

        await _next(context);
    }
}
