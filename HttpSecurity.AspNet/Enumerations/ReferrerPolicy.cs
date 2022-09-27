namespace HttpSecurity.AspNet;

/// <summary>
/// Referrer-Policy directives.
/// </summary>
public enum ReferrerPolicyDirective
{
    /// <summary>
    /// no-referrer
    /// </summary>
    NoReferrer,


    /// <summary>
    /// no-referrer-when-downgrade
    /// </summary>
    NoReferrerWhenDowngrade,


    /// <summary>
    /// origin
    /// </summary>
    Origin,


    /// <summary>
    /// origin-when-cross-origin
    /// </summary>
    OriginWhenCrossOrigin,


    /// <summary>
    /// same-origin
    /// </summary>
    SameOrigin,


    /// <summary>
    /// strict-origin
    /// </summary>
    StrictOrigin,


    /// <summary>
    /// strict-origin-when-cross-origin
    /// </summary>
    StrictOriginWhenCrossOrigin,


    /// <summary>
    /// unsafe-url
    /// </summary>
    UnsafeUrl,
}
