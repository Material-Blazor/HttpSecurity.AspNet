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
    string IHttpSecurityService.GetCSPHashesSubstring(StaticFileExtension staticFileExtension)
    {
        return _fileHashDataset.GetCSPSubstring(staticFileExtension);
    }

}
