namespace HttpSecurity.AspNetCore;


/// <summary>
/// media-src policy.
/// </summary>
[ContentSecurityPolicyOptions]
[AddHashValue]
[AddHostSource]
[AddNone]
[AddNonce]
[AddReportSample]
[AddSelf]
[AddSchemeSource]
[AddStrictDynamic]
[AddUnsafeEval]
[AddUnsafeHashes]
[AddUnsafeInline]
[AddUri]
public sealed partial class MediaSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// media-src policy.
/// </summary>
[ContentSecurityPolicy("media-src")]
public sealed partial class MediaSrcCSP : ContentSecurityPolicyBase
{
}
