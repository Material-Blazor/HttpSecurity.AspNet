namespace HttpSecurity.AspNetCore;

/// <summary>
/// Scheme sources available for content security policies.
/// </summary>
public enum SchemeSource
{
    /// <summary>
    /// blob: source.
    /// </summary>
    Blob,


    /// <summary>
    /// data: source.
    /// </summary>
    Data,


    /// <summary>
    /// filesystem: source.
    /// </summary>
    Filesystem,


    /// <summary>
    /// http: source.
    /// </summary>
    Http,


    /// <summary>
    /// https: source.
    /// </summary>
    Https,


    /// <summary>
    /// mediastream: source.
    /// </summary>
    Mediastream,
}
