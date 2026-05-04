namespace HttpSecurity.AspNet;

/// <summary>
/// Directives for the Cross-Origin-Resource-Policy header.
/// </summary>
public enum CrossOriginResourcePolicyDirective
{
    /// <summary>
    /// same-site — only requests from the same site can read the resource.
    /// </summary>
    SameSite,

    /// <summary>
    /// same-origin — only requests from the same origin can read the resource.
    /// </summary>
    SameOrigin,

    /// <summary>
    /// cross-origin — requests from any origin can read the resource.
    /// </summary>
    CrossOrigin,
}
