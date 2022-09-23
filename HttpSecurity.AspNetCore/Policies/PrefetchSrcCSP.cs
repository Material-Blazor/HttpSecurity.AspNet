namespace HttpSecurity.AspNetCore;


/// <summary>
/// prefetch-src policy.
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
public sealed partial class PrefetchSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// prefetch-src policy.
/// </summary>
[ContentSecurityPolicy("prefetch-src")]
public sealed partial class PrefetchSrcCSP : ContentSecurityPolicyBase
{
}
