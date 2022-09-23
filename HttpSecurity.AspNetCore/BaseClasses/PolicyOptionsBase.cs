namespace HttpSecurity.AspNetCore;

/// <summary>
/// All policies inherit from this base class.
/// </summary>
public abstract class PolicyOptionsBase
{
    /// <summary>
    /// The policy's name.
    /// </summary>
    internal readonly List<string> PolicyValues = new();


    /// <summary>
    /// The nonce value.
    /// </summary>
    private protected string NonceValue { get; init; } = "";
}
