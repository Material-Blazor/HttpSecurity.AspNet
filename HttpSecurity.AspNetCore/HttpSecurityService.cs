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

        if (_options.XFrameOptionsDirective is not null)
        {
            headers["X-Frame-Options"] = ((XFrameOptionsDirectives)_options.XFrameOptionsDirective).ToString().ToUpper();
        }

        string csp = _options.GetContentSecurityPolicy(baseUri, baseDomain);

        if (!string.IsNullOrWhiteSpace(csp))
        {
            headers["Content-Security-Policy"] = csp;
        }

        if (_options.XContentTypeOptionsNoSniff)
        {
            headers["X-Content-Type-Options"] = "nosniff";
        }

        return headers;
    }
}
