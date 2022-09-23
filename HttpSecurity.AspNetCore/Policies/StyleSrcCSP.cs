namespace HttpSecurity.AspNetCore;


/// <summary>
/// style-src policy.
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
public sealed partial class StyleSrcCSPOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// style-src policy.
/// </summary>
[ContentSecurityPolicy("style-src")]
public sealed partial class StyleSrcCSP : ContentSecurityPolicyBase
{
}
