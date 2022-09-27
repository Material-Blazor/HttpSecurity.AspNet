namespace HttpSecurity.AspNet;


/// <summary>
/// base-uri policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddHashValue]
[AddHostSource]
[AddNone]
[AddNonce]
[AddReportSample]
[AddSelf]
[AddSchemeSource]
[AddUnsafeEval]
[AddUnsafeHashes]
[AddUri]
public sealed partial class BaseUriCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// base-uri policy.
/// </summary>
[ContentSecurityPolicy("base-uri")]
public sealed partial class BaseUriCSP : ContentSecurityPolicyBase
{
}
