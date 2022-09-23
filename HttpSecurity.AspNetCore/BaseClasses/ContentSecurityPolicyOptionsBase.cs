namespace HttpSecurity.AspNetCore;

/// <summary>
/// All policies inherit from this base class.
/// </summary>
public abstract class ContentSecurityPolicyOptionsBase
{
    /// <summary>
    /// The policy's name.
    /// </summary>
    internal readonly List<Func<string, string, string>> PolicyValueBuilders = new();


    /// <summary>
    /// The nonce value.
    /// </summary>
    private protected string NonceValue { get; init; } = "";
}
