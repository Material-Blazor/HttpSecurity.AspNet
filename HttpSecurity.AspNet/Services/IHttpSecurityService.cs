namespace HttpSecurity.AspNet;

/// <summary>
/// Implementation of <see cref="IAlternativeFileProvider"/> for compressed files such as CSS or JS.
/// </summary>
public interface IHttpSecurityService
{
    /// <summary>
    /// Returns a dictionary of security headers.
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="baseDomain"></param>
    /// <returns></returns>
    public Dictionary<string, string> GetSecurityHeaders();


    /// <summary>
    /// Returns the default <see cref="IGeneratedHashesProvider"/>.
    /// </summary>
    /// <returns></returns>
    public IGeneratedHashesProvider DefaultGeneratedHashesProvider { get; }


    /// <summary>
    /// Returns the value of the nonce created for this instance of the scoped service.
    /// </summary>
    /// <returns></returns>
    public string GetNonce();


    /// <summary>
    /// Returns a hash string for CSP use.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string GetFileHashString(string fileName);


    /// <summary>
    /// Returns a CSP substring containing all generated hashes for the given static file extentsion.
    /// </summary>
    /// <param name="staticFileExtension"></param>
    /// <returns></returns>
    internal string GetCSPHashesSubsting(StaticFileExtension staticFileExtension);
}
