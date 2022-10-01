namespace HttpSecurity.AspNet;


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
public sealed partial class FontSrcOptions : ContentSecurityPolicyOptionsBase
{
}


/// <summary>
/// font-src policy.
/// </summary>
[ContentSecurityPolicy("font-src")]
public sealed partial class FontSrc : ContentSecurityPolicyBase
{
}
