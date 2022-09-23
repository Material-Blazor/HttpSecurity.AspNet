namespace ContentSecurityPolicy.AspNetCore;

/// <summary>
/// Hash algorithms available for content security policies.
/// </summary>
public enum HashAlgorithm
{
    /// <summary>
    /// sha256 algorithm.
    /// </summary>
    SHA256,


    /// <summary>
    /// sha2284 algorithm.
    /// </summary>
    SHA384,


    /// <summary>
    /// sha512 algorithm.
    /// </summary>
    SHA512,
}
