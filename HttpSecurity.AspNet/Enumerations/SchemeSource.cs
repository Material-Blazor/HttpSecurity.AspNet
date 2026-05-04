namespace HttpSecurity.AspNet;

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


    /// <summary>
    /// ws: source (unencrypted WebSocket).
    /// </summary>
    Ws,


    /// <summary>
    /// wss: source (encrypted WebSocket).
    /// </summary>
    Wss,
}
