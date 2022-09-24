namespace HttpSecurity.AspNetCore;

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
    /// Returns the value of the nonce created for this instance of the scoped service.
    /// </summary>
    /// <returns></returns>
    public string GetNonce();
}
