namespace HttpSecurity.AspNet;

/// <summary>
/// All policies inherit from this base class.
/// </summary>
public abstract class ContentSecurityPolicyOptionsBase
{
    /// <summary>
    /// The policy's name.
    /// </summary>
    internal readonly List<Func<string, string, string, string>> PolicyValueBuilders = new();


    /// <summary>
    /// Returns a generated hashes substring for the given satic file extension.
    /// </summary>
    /// <param name="httpSecurityService"></param>
    /// <returns></returns>
    internal virtual string GetCSPSubstring(IHttpSecurityService httpSecurityService)
    {
        return "";
    }
}
