namespace HttpSecurity.AspNet;

/// <summary>
/// Directives for the Cross-Origin-Opener-Policy header.
/// </summary>
public enum CrossOriginOpenerPolicyDirective
{
    /// <summary>
    /// unsafe-none — allows the document to be added to its opener's browsing context group (default).
    /// </summary>
    UnsafeNone,

    /// <summary>
    /// same-origin-allow-popups — retains references to newly opened windows or tabs that either don't set COOP or opt out.
    /// </summary>
    SameOriginAllowPopups,

    /// <summary>
    /// same-origin — isolates the browsing context group to same-origin documents only.
    /// </summary>
    SameOrigin,
}
