namespace HttpSecurity.AspNetCore;


/// <summary>
/// font-src policy.
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
public sealed partial class FontSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// font-src policy.
/// </summary>
[ContentSecurityPolicy("font-src")]
public sealed partial class FontSrcCSP : ContentSecurityPolicyBase
{
}
