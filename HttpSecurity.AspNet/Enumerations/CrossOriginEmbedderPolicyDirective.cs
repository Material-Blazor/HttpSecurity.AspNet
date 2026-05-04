namespace HttpSecurity.AspNet;

/// <summary>
/// Directives for the Cross-Origin-Embedder-Policy header.
/// </summary>
public enum CrossOriginEmbedderPolicyDirective
{
    /// <summary>
    /// unsafe-none — allows the document to fetch cross-origin resources without giving explicit permission (default).
    /// </summary>
    UnsafeNone,

    /// <summary>
    /// require-corp — prevents loading of cross-origin resources that don't explicitly grant permission via CORS or CORP.
    /// </summary>
    RequireCorp,

    /// <summary>
    /// credentialless — allows cross-origin no-cors requests to be sent without credentials.
    /// </summary>
    Credentialless,
}
